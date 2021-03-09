using Instituto.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Instituto.Datos.Interfaces
{
    public interface IPersonasDatos
    {
        List<Persona> ObtenerTodas();

        Persona ObtenerPorId(int id);

        void Guardar(Persona persona);
    }
}
