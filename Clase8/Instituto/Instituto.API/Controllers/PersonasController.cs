using AutoMapper;
using Instituto.DTO;
using Instituto.EntidadesNegocio;
using Instituto.Negocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IMapper mapper;

        public readonly IPersonasNegocio personasNegocio;

        public PersonasController(IMapper mapper, IPersonasNegocio personasNegocio)
        {
            this.mapper = mapper;
            this.personasNegocio = personasNegocio;
        }

        public async Task<IActionResult> GetPersonas()
        {
            // Le pido a la clase de negocios la lista de personas

            List<Persona> resultadoClaseNegocios = personasNegocio.ObtenerTodasLasPersonas();

            List<PersonaDTO> resultado = new List<PersonaDTO>();

            foreach (var persona in resultadoClaseNegocios)
            {
                PersonaDTO personaDTO = mapper.Map<PersonaDTO>(persona);
                resultado.Add(personaDTO);
            }

            return Ok(resultado);
        }

        [Route("inverso")]
        public async Task<IActionResult> GetPersonasBussiness()
        {
            PersonaDTO dto = new PersonaDTO()
            {
                Id = 99,
                Nombres = "Inverso",
                Apellidos = "Mapeo",
                Email = "mapeo@inverso.com"
            };

            Persona resultado = mapper.Map<Persona>(dto);
            return Ok(resultado);
        }

        [Route("sinautomapper")]
        public async Task<IActionResult> GetPersonasSinAutomapper()
        {
            // Le pido a la clase de negocios la lista de personas

            List<Persona> resultadoClaseNegocios = new List<Persona>()
            {
                new Persona(){ Id=1,Nombres="Persona",Apellidos="Uno"},
                new Persona(){ Id=2,Nombres="Persona",Apellidos="Dos"},
                new Persona(){ Id=3,Nombres="Persona",Apellidos="Tres"},
            };

            List<PersonaDTO> resultado = new List<PersonaDTO>();

            foreach (var persona in resultadoClaseNegocios)
            {
                PersonaDTO personaDTO = new PersonaDTO()
                {
                    Id = persona.Id,
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos
                };

                resultado.Add(personaDTO);
            }

            return Ok(resultado);
        }
    }
}
