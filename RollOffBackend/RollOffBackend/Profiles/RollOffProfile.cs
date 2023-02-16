using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RollOffBackend.DTO;
using RollOffBackend.Models;

namespace RollOffBackend.Profiles
{
    public class RollOffProfile : Profile
    { 
        public RollOffProfile()
        {
            CreateMap<RollOffTable, RollOffTableDTO>().ReverseMap();
            CreateMap<LoginTable, LoginTableDTO>().ReverseMap();
            CreateMap<FormTable, FormTableDTO>().ReverseMap();
            CreateMap<FormTable, UpdateFormDTO>().ReverseMap();
        }
    }
}
