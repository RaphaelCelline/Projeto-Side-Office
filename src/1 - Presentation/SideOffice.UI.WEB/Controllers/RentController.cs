using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SideOffice.Application.Interfaces;
using SideOffice.Domain.Entities;
using SideOffice.Infra.CrossCutting.Identity.Models.RentViewModels;

namespace SideOffice.UI.WEB.Controllers
{
    public class RentController : Controller
    {
        private readonly IRentAppService rentApp;
        private readonly IUserAppService userApp;
        private readonly IRoomAppService roomApp;
        private readonly IMapper mapper;

        public RentController(IRentAppService _rentApp, IUserAppService _userApp, IRoomAppService _roomApp, IMapper _mapper)
        {
            rentApp = _rentApp;
            userApp = _userApp;
            roomApp = _roomApp;
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            var rentViewModel = mapper.Map<IEnumerable<Rent>,IEnumerable<RentViewModel>>(rentApp.GetAllWhitReferences());
            return View(rentViewModel);
        }

        public IActionResult Create()
        {
            ViewBag.User_id = userApp.GetAll().OrderBy(p => p.Name);
            ViewBag.Room_id = roomApp.GetAll().OrderBy(p => p.Name);
            return View();
        }

        [HttpPost]
        public IActionResult Create(RentViewModel rentViewModel)
        {
            var canRent = rentApp.CanRentOffice(rentViewModel.Start_datetime, rentViewModel.End_datetime, rentViewModel.Room_id);

            if (canRent)
            {
                var RentDomain = mapper.Map<Rent>(rentViewModel);
                rentApp.Add(RentDomain);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Esta sala já se econtra reservada neste periodo.";
                return RedirectToAction("Create");
            }
        }

        public IActionResult Delete(Guid id)
        {
            rentApp.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var RentViewModel = mapper.Map<RentViewModel>(rentApp.GetById(id));
            return View(RentViewModel);
        }

        public IActionResult Edit(Guid id)
        {
            var RentViewModel = mapper.Map<RentViewModel>(rentApp.GetById(id));
            return View(RentViewModel);
        }

        [HttpPost]
        public IActionResult Edit(RentViewModel RentViewModel)
        {
            var RentDomain = mapper.Map<Rent>(RentViewModel);
            rentApp.Update(RentDomain);
            return RedirectToAction("Index");
        }
    }
}