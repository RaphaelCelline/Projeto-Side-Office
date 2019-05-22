using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SideOffice.Application.Interfaces;
using SideOffice.Domain.Entities;
using SideOffice.Infra.CrossCutting.Identity.Models.RoomViewModel;
using SideOffice.Infra.CrossCutting.Identity.Models.UserViewModels;

namespace SideOffice.UI.WEB.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomAppService roomApp;
        private readonly IMapper mapper;

        public RoomController(IRoomAppService _roomApp, IMapper _mapper)
        {
            roomApp = _roomApp;
            mapper  = _mapper;
        }
        
        public IActionResult Index()
        {
            var roomViewModel = mapper.Map<IEnumerable<RoomViewModel>>(roomApp.GetAll());
            return View(roomViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
                var roomDomain = mapper.Map<Room>(roomViewModel);
                roomApp.Add(roomDomain);

                return RedirectToAction("Index");
            }
            return View(roomViewModel);
        }

        public IActionResult Delete(Guid id)
        {
            roomApp.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var roomVIewModel = mapper.Map<RoomViewModel>(roomApp.GetById(id));
            return View(roomVIewModel);
        }

        public IActionResult Edit(Guid id)
        {
            var roomViewModel = mapper.Map<RoomViewModel>(roomApp.GetById(id));
            return View(roomViewModel);
        }

        [HttpPost]
        public IActionResult Edit(RoomViewModel roomViewModel)
        {
            var roomDomain = mapper.Map<Room>(roomViewModel);
            roomApp.Update(roomDomain);
            return RedirectToAction("Index");
        }        
    }
}