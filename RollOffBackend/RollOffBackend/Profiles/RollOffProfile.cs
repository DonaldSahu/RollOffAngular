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
            CreateMap<MasterTable, MasterTableDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RolloffForm, FormTableDTO>().ReverseMap();
            CreateMap<RolloffForm, UpdateFormDTO>().ReverseMap();
        }
    }
}
