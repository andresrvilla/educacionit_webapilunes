using Instituto.EntidadesNegocio;
using System;
using System.Collections.Generic;

namespace Instituto.Negocio.Interfaces
{
    public interface IPersonasNegocio
    {
        List<Persona> ObtenerTodasLasPersonas();

        void AgregarPersona(Persona persona);
    }
}
