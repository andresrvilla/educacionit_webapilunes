using AutoMapper;
using Instituto.DTO;
using Instituto.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.API
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaDTO>()
                .ForMember(dest => dest.Email, origen => origen.MapFrom(origen => origen.Mail))
                .ReverseMap();
        }
    }
}
