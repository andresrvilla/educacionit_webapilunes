using Instituto.Datos.Interfaces;
using Instituto.EntidadesNegocio;
using Instituto.EntidadesNegocio.Exceptions;
using Instituto.Negocio.Interfaces;
using System;
using System.Collections.Generic;

namespace Instituto.Negocio
{
    public class PersonasNegocio: IPersonasNegocio
    {
        private readonly IPersonasDatos personasDatos;

        public PersonasNegocio(IPersonasDatos personasDatos)
        {
            this.personasDatos = personasDatos;
        }

        public void AgregarPersona(Persona persona)
        {
            if (persona == null)
            {
                throw new ArgumentNullException("persona");
            }

            if(string.IsNullOrWhiteSpace(persona.Nombres))
            {
                throw new ArgumentException("El nombre es requerido");
            }

            if (string.IsNullOrWhiteSpace(persona.Apellidos))
            {
                throw new ArgumentException("El nombre es requerido");
            }

            try
            {
                personasDatos.Guardar(persona);
            }
            catch(CapaDeDatosException ex)
            {
                throw new CapaDeNegocioException(ex);
            }
            
        }

        public List<Persona> ObtenerTodasLasPersonas()
        {
            try
            {
                return personasDatos.ObtenerTodas();
            }
            catch(CapaDeDatosException ex)
            {
                CapaDeNegocioException capaDeNegocioException = new CapaDeNegocioException(ex);
                throw capaDeNegocioException;
            }            
        }
    }
}
