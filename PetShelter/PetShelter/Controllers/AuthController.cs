using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PetShelter.Shared.Services.Contracts;
using PetShelter.ViewModels;
using System.Security.Claims;

namespace PetShelter.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IMapper mapper;

        public AuthController(
            IUserService userService, 
            IRoleService roleService, 
            IMapper mapper)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginVM model)
        {
            string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;

            if (loggedUsername != null) 
            { 
                return Forbid();
            }

            if (!await this.userService.CanUserLoginAsync(model.Username, model.Passwod))
            {
                return BadRequest(Constants.InvalidCredentials);
            }
            await LoginUser(model.Username);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
