using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetShelter.Services.Services.Contracts;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.ViewModels;

namespace PetShelter.Controllers
{
    public abstract class BaseCrudController<TModel,TRepository,TService,TEditVM,TDetailsVM> : Controller
        where TModel : BaseModel
        where TRepository : IBaseRepository<TModel>
        where TService : IBaseCrudService<TModel,TRepository>
        where TEditVM : BaseVM, new()
        where TDetailsVM : BaseVM

    {
        protected readonly TService _service;
        protected readonly IMapper _mapper;
        protected BaseCrudController(TService service, IMapper mapper)
        {
            this._service = service;
            _mapper = mapper;
        }

        protected const int DefaultPageSize = 10;
        protected const int DefaultPageNumber = 1;

        protected virtual Task<string?> Validate(TEditVM editVM)
        {
            return Task.FromResult<string?>(null);
        }

        protected virtual Task<TEditVM> PrePopulateVMAsync()
        {
            return Task.FromResult(new TEditVM());
        }

        [HttpGet]

        public virtual async Task<IActionResults> List(int pageSize = DefaultPageSize,int pageNumber = DefaultPageNumber)

    }
}
