using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SideOffice.Application.Interfaces;
using SideOffice.Domain.Entities;
using SideOffice.Infra.CrossCutting.Identity.Models.RoomViewModel;

namespace SideOffice.Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomAppService _roomAppService;
        private readonly IMapper _mapper;

        public RoomController(IMapper mapper, IRoomAppService userAppService)
        {
            _mapper = mapper;
            _roomAppService = userAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Users = _roomAppService.GetAll();
            var RoomViewModels = _mapper.Map<IEnumerable<RoomViewModel>>(Users);
            return StatusCode(200, RoomViewModels);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var room = _mapper.Map<Room>(registerViewModel);

                    _roomAppService.Add(room);
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
        public IActionResult Delete([FromQuery] Guid room_id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _roomAppService.Remove(room_id);
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