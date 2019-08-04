using System;
using System.Blog.Entities;
using System.Blog.IBLL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace System.Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly EntityDbContext _context;
        private readonly IPostBll _postBll;
        private readonly ILogger<PostController> _logger;
        public PostController(EntityDbContext context, IPostBll postBll, ILogger<PostController> logger)
        {
            _context = context;
            _postBll = postBll;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _postBll.GetCategoryList();
            return View();
        }
    }
}