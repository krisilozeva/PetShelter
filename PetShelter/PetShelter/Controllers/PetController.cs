using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using PetShelter.Services;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using PetShelter.ViewModels;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace PetShelter.Controllers
{
 
     [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, User")]

    public class PetController : BaseCrudController<PetDto, IPetRepository, IPetService, PetEditVM, PetDetailsVM>
    {

        private readonly IPetTypeService _petTypeService;
        private readonly IShelterService _shelterService;
        private readonly IBreedsService _breedService;
        private readonly IUserService _userService;


        public PetController(IPetService service, IMapper mapper, IPetService petService, IPetTypeService petTypeService, IBreedService breedService, IShelterService shelterService, IUserService userService) : base(service, mapper)

        {

            _breedService = breedService;

            _petTypeService = petTypeService;

            _shelterService = shelterService;

            _userService = userService;

        }

        protected override async Task<PetEditVM> PrePopulateVMAsync(PetEditVM editVM)

        {

            editVM.BreedList = (await _breedService.GetAllAsync())

            .Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            editVM.PetTypeList = (await _petTypeService.GetAllAsync())

           .Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            editVM.ShelterList = (await _shelterService.GetAllAsync())

            .Select(x => new SelectListItem(x.PetCapacity.ToString(), x.Id.ToString()));

            return editVM;

        }

        [HttpGet]

        public virtual async Task<IActionResult> GivePet()

        {

            var editVM = await PrePopulateVMAsync(new PetEditVM());

            return View(editVM);

        }

        [HttpPost]

        public virtual async Task<IActionResult> GivePet(PetEditVM editVM)

        {

            var errors = await Validate(editVM);

            if (errors != null)

            {

                return View(editVM);

            }

            string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;

            var user = await this._userService.GetByUsernameAsync(loggedUsername);

            var model = this._mapper.Map<PetDto>(editVM);

            await this._service.GivePetAsync(user.Id, model.ShelterId.Value, model);

            return await List();

        }

    }

}
