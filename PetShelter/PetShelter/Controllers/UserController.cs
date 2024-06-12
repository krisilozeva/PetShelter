using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShelter.Services;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using PetShelter.ViewModels;

namespace PetShelter.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, User")]
    public class UserController : BaseCrudController<UserDto, IUserRepository, IUserService, UserEditVM, UserDetailsVM>
    {
        private readonly IRoleService _roleService;
        private readonly IShelterService _shelterService;


        public UserController(IUserService service, IMapper mapper, IRoleService _roleService, IShelterService _shelterService) : base(service, mapper)
        {

        }
        protected override async Task<UserEditVM> PrePopulateVMAsync(UserEditVM editVM)
        {
            editVM.ShelterList = (await _shelterService.GetAllAsync())
            .Select(x => new SelectListItem(x.PetCapacity.ToString(), x.Id.ToString()));

            editVM.RoleList = (await _roleService.GetAllAsync())
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return editVM;
        }
    }
}
