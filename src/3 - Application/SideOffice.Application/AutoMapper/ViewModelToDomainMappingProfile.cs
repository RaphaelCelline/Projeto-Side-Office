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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Infra.CrossCutting.Identity.Models.UserViewModels.RegisterViewModel, User>()
                .ConstructUsing(c => new User(c.Name, c.Last_name, c.Email, c.Password, c.Document, c.Country_code));

            CreateMap<Infra.CrossCutting.Identity.Models.RoomViewModel.RegisterViewModel, Room>();

            CreateMap<RoomViewModel, Room>();
            CreateMap<RentViewModel, Rent>();
        }
    }
}
