using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SideOffice.Application.Interfaces;
using SideOffice.Domain.Entities;
using SideOffice.Infra.CrossCutting.Identity.Models;
using SideOffice.Infra.CrossCutting.Identity.Models.UserViewModels;

namespace SideOffice.UI.WEB.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserAppService userApp;
        private readonly IMapper mapper;

        public UserController(IUserAppService _userApp, IMapper _mapper)
        {
            userApp = _userApp;
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            var userViewModel = mapper.Map<IEnumerable<UserViewModel>>(userApp.GetAll());
            return View(userViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userDomain = mapper.Map<User>(user);
                userApp.Add(userDomain);

                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Delete(Guid id)
        {
            userApp.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var userViewModel = mapper.Map<UserViewModel>(userApp.GetById(id));
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel)
        {
            var userDomain = mapper.Map<User>(userViewModel);
            userApp.Update(userDomain);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var userViewModel = mapper.Map<UserViewModel>(userApp.GetById(id));
            return View(userViewModel);
        }
    }
}