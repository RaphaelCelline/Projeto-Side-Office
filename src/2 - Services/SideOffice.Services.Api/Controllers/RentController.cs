using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SideOffice.Application.Interfaces;
using SideOffice.Infra.CrossCutting.Identity.Models.RentViewModels;

namespace SideOffice.Services.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RentController : Controller
    {
        private readonly IRentAppService _rentAppService;
        private readonly IMapper _mapper;

        public RentController(IMapper mapper, IRentAppService rentAppService)
        {
            _mapper = mapper;
            _rentAppService = rentAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Users = _rentAppService.GetAll();
            var RentViewModels = _mapper.Map<IEnumerable<RentViewModel>>(Users);
            return StatusCode(200, RentViewModels);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rent = _mapper.Map<Domain.Entities.Rent>(registerViewModel);

                    _rentAppService.Add(rent);
                    return StatusCode(200);
                }
                catch (Exception e)
                {
                    return StatusCode(400, e.Message);
                }
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] Guid Rent_id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _rentAppService.Remove(Rent_id);
                    return StatusCode(200);
                }
                catch (Exception e)
                {
                    return StatusCode(400, e.Message);
                }
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}