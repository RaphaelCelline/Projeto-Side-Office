using AutoMapper;
using SideOffice.Domain.Entities;
using SideOffice.Infra.CrossCutting.Identity.Models.RentViewModels;
using SideOffice.Infra.CrossCutting.Identity.Models.RoomViewModel;
using SideOffice.Infra.CrossCutting.Identity.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Application.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();

            CreateMap<Room, RoomViewModel>();

            CreateMap<Rent, RentViewModel>();
        }
    }
}
