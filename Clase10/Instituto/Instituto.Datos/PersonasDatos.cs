using Instituto.Datos.Interfaces;
using Instituto.EntidadesNegocio;
using System;
using System.Collections.Generic;

namespace Instituto.Datos
{
    public class PersonasDatos : IPersonasDatos
    {
        public List<Persona> PersonasFijas { get; set; } = new List<Persona>()
        {
            new Persona() { Id=1,Nombres="Andres", Apellidos="Villa"},
            new Persona() { Id=2,Nombres="Laura", Apellidos="Suarez"},
            new Persona() { Id=3,Nombres="Estefania", Apellidos="Gimenez"},
            new Persona() { Id=4,Nombres="Carlos", Apellidos="Gomez"}
        };

        public void Guardar(Persona persona)
        {
            //TODO: Implementar
        }

        public Persona ObtenerPorId(int id)
        {
            return PersonasFijas[0];
        }

        public List<Persona> ObtenerTodas()
        {
            return PersonasFijas;
        }
    }
}
