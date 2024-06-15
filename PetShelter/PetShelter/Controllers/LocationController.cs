using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using PetShelter.Controllers;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using PetShelter.ViewModels;

[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, User")]
public class LocationController : BaseCrudController<LocationDto, ILocationRepository, ILocationService, LocationEditVM, LocationDetailsVM>
{
    public LocationController(ILocationService service, IMapper mapper) : base(service, mapper)
    {

    }
}
