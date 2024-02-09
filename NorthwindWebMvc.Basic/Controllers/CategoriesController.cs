using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.Models.Dto;
using NorthwindWebMvc.Basic.Repository;
using NorthwindWebMvc.Basic.RepositoryContext;
using NorthwindWebMvc.Basic.Services;

namespace NorthwindWebMvc.Basic.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly RepositoryDbContext _context;

        private readonly IRepositoryBase<Category> _repositoryBase;
        private readonly ICategoryService<CategoryDto> _categoryService;

        public CategoriesController(ICategoryService<CategoryDto> categoryService)
        {
            _categoryService = categoryService;
        }

        //public CategoriesController(IRepositoryBase<Category> repositoryBase)
        //{
        //    _repositoryBase = repositoryBase;
        //}

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(_categoryService.GetAll());
              //return _context.Categories != null ? 
              //            View(await _context.Categories.ToListAsync()) :
              //            Problem("Entity set 'RepositoryDbContext.Categories'  is null.");
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = _categoryService.GetById(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);

            //if (id == null || _context.Categories == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (category == null)
            //{
            //    return NotFound();
            //}

            //return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName,Description,Photo")] CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(category);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
            //if (id == null || _context.Categories == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories.FindAsync(id);
            //if (category == null)
            //{
            //    return NotFound();
            //}
            //return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,Description,Photo")] CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Edit(id, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
            //if (id != category.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(category);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CategoryExists(category.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
            //if (id == null || _context.Categories == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (category == null)
            //{
            //    return NotFound();
            //}

            //return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
            //if (_context.Categories == null)
            //{
            //    return Problem("Entity set 'RepositoryDbContext.Categories'  is null.");
            //}
            //var category = await _context.Categories.FindAsync(id);
            //if (category != null)
            //{
            //    _context.Categories.Remove(category);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
