using Instituto.Datos.Interfaces;
using Instituto.EntidadesNegocio;
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

            personasDatos.Guardar(persona);
        }

        public List<Persona> ObtenerTodasLasPersonas()
        {
            return personasDatos.ObtenerTodas();
        }
    }
}
