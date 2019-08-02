using System;
using System.Blog.Entities;
using System.Blog.IBLL;
using System.Blog.Web.Models.Category;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace System.Blog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EntityDbContext _context;
        private readonly ICategoryBll _categoryBll;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(EntityDbContext context, ICategoryBll categoryBll, ILogger<CategoryController> logger)
        {
            _context = context;
            _categoryBll = categoryBll;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNew(AddCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var exists = _categoryBll.GetAllList().FirstOrDefault(x => x.Name == viewModel.Name);
                if (exists == null)
                {
                    await _categoryBll.AddAsync(new CategoryEntity()
                    {
                        Name = viewModel.Name
                    });
                    if (await _categoryBll.SaveToDBAsync())
                    {
                        return RedirectToAction(nameof(CategoryList));
                    }
                }
                else
                {                   
                    ModelState.AddModelError("", "Category Already Exists, please try Another one");
                    return View(viewModel);
                }
            }
            _logger.LogError($"Add Category Failed {viewModel.Name}");
            ModelState.AddModelError("", "Add category failed, please try again later");
            return View(viewModel);


        }
        /// <summary>
        /// get category list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var modelList = await _categoryBll.GetAllList().Select(x => new CategoryDetailViewModel() { Name = x.Name, Id = x.Id.ToString() }).ToListAsync();
            return View(modelList);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var category = _categoryBll.GetAllList().FirstOrDefault(c => c.Id.ToString() == id);
            if (category != null)
            {
                return View(new CategoryDetailViewModel() {  Id=id, Name=category.Name});
            }
            ModelState.AddModelError("", "Category does not exist");
            return RedirectToAction(nameof(CategoryList));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDetailViewModel viewModel)
        {
            var exists = _categoryBll.GetAllList().FirstOrDefault(x => x.Name == viewModel.Name);
            if (exists != null)
            {
                ModelState.AddModelError("", "Categroy name already exists, please change to another one");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    CategoryEntity entity = new CategoryEntity() { Id = new Guid(viewModel.Id), Name = viewModel.Name, ModifiedTime = DateTime.Now };
                    await _categoryBll.UpdateAsync(entity);
                    if (!await _categoryBll.SaveToDBAsync())
                    {
                        ModelState.AddModelError("", "Update failed, please try again later");
                        _logger.LogError($"Category update failed");
                      
                    }
                    return RedirectToAction(nameof(CategoryList));
                }
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            var category = _categoryBll.GetAllList().FirstOrDefault(c => c.Id.ToString() == id);
            if (category == null)
            {
                ModelState.AddModelError("", "Category does not exist");
                return RedirectToAction(nameof(CategoryList));
            }

            return View(new CategoryDetailViewModel() {  Id=id, Name=category.Name});
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var category = _categoryBll.GetAllList().FirstOrDefault(c => c.Id.ToString() == id);
            if (category == null)
            {
                ModelState.AddModelError("", "Category does not exist");
                return RedirectToAction(nameof(CategoryList));
            }

            return View(new CategoryDetailViewModel() { Id = id, Name = category.Name });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDetailViewModel viewModel)
        {
            var category = _categoryBll.GetAllList().FirstOrDefault(c => c.Id.ToString() == viewModel.Id);
            if (category != null)
            {
                await _categoryBll.DeleteAsync(viewModel.Id);
                if (!await _categoryBll.SaveToDBAsync())
                {
                    _logger.LogError("Delete Category failed");
                    ModelState.AddModelError("", "Delete failed");
                }
            }
            else
            {
                ModelState.AddModelError("", "Category does not exist");
                _logger.LogError("Try to delete not exist category");
            }
            return RedirectToAction(nameof(CategoryList));
        }

    }
}