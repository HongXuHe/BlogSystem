using System;
using System.Blog.Entities;
using System.Blog.IBLL;
using System.Blog.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static System.Collections.Specialized.BitVector32;

namespace System.Blog.Web.Controllers
{
    public class UserController : Controller
    {
        #region properties and ctor
        private readonly EntityDbContext _context;
        private readonly IUserBll _userBll;
        private readonly ILogger<UserController> _logger;
        public UserController(EntityDbContext context, IUserBll userBll, ILogger<UserController> logger)
        {
            _context = context;
            _userBll = userBll;
            _logger = logger;
        }
        #endregion

        #region Register and Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _userBll.AddAsync(new UserEntity()
                {
                    UserName = viewModel.UserName,
                    Password = viewModel.Password
                });
                if (await _userBll.SaveToDBAsync())
                {
                    _logger.LogInformation($"{viewModel.UserName} Register Success");
                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                ModelState.AddModelError("", "Register failed, please try again later");
            }
            return View(viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (await _userBll.Login(user.UserName, user.Password))
                {
                    if (user.RememberMe == true)
                    {
                        Response.Cookies.Append("userName", user.UserName);
                        Response.Cookies.Append("userPassword", user.Password);
                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTime.Now.AddDays(7);
                    }
                    _logger.LogInformation($"user {user.UserName} logged in");
                    return RedirectToAction("List", "Post");
                }
            }
            else
            {
                ModelState.AddModelError("", "User Name or Password incorrect");
            }
            return View(user);
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
          var data= await Task.Factory.StartNew(()=>_userBll.GetAllList().Select(t => new UserViewModel { UserName = t.UserName }).ToList());
            return View(data);
        }
    }
}