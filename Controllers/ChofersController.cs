using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSindicato.Context;
using WebSindicato.Models;

namespace WebSindicato.Controllers
{
    public class ChofersController : Controller
    {
        private readonly MyContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ChofersController(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Chofers
        public async Task<IActionResult> Index()
        {
              return _context.Chofer != null ? 
                          View(await _context.Chofer.ToListAsync()) :
                          Problem("Entity set 'MyContext.Chofer'  is null.");
        }

        // GET: Chofers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chofer == null)
            {
                return NotFound();
            }

            var chofer = await _context.Chofer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chofer == null)
            {
                return NotFound();
            }

            return View(chofer);
        }

        // GET: Chofers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chofers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ci,Name,PhotoFile")] Chofer chofer)
        {
            if (ModelState.IsValid)
            {
              if(chofer.PhotoFile!=null)
                {
                    await SubirFoto(chofer);
                }
                _context.Add(chofer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chofer);
        }

       private async Task SubirFoto(Chofer chofer)
        {
            //create name of photo
            string wwRootPath = _webHostEnvironment.WebRootPath;
            string extension = Path.GetExtension(chofer.PhotoFile!.FileName);
            string nombreFoto = $"{chofer.Id}{extension}";

            chofer.Photo = nombreFoto;

            //copy photo in the server
            string path = Path.Combine($"{wwRootPath}/photos/",nombreFoto);
            var fileStream = new FileStream(path, FileMode.Create);
            await chofer.PhotoFile.CopyToAsync(fileStream);


        }

        // GET: Chofers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chofer == null)
            {
                return NotFound();
            }


            var chofer = await _context.Chofer.FindAsync(id);
            if (chofer == null)
            {
                return NotFound();
            }
            return View(chofer);
        }

        // POST: Chofers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ci,Name,PhotoFile")] Chofer chofer)
        {
            if (id != chofer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (chofer.PhotoFile != null)
                    {
                        await SubirFoto(chofer);
                    }
                    _context.Update(chofer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoferExists(chofer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chofer);
        }

        // GET: Chofers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chofer == null)
            {
                return NotFound();
            }

            var chofer = await _context.Chofer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chofer == null)
            {
                return NotFound();
            }

            return View(chofer);
        }

        // POST: Chofers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chofer == null)
            {
                return Problem("Entity set 'MyContext.Chofer'  is null.");
            }
            var chofer = await _context.Chofer.FindAsync(id);
            if (chofer != null)
            {
                _context.Chofer.Remove(chofer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoferExists(int id)
        {
          return (_context.Chofer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
