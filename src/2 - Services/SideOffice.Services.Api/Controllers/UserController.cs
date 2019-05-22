using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SideOffice.Application.AppServices;
using SideOffice.Application.Interfaces;
using SideOffice.Domain;
using SideOffice.Domain.Entities;
using SideOffice.Infra.CrossCutting.Identity.Models.UserViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SideOffice.Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserAppService userAppService)
        {
            _mapper = mapper;
            _userAppService = userAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Users = _userAppService.GetAll();
            var UserViewModels = _mapper.Map<IEnumerable<UserViewModel>>(Users);
            return StatusCode(200, UserViewModels);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var User = _mapper.Map<User>(registerViewModel);

                    _userAppService.Add(User);
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
        public IActionResult Delete([FromQuery] Guid user_id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userAppService.Remove(user_id);
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
