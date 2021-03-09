using System;

namespace Instituto.EntidadesNegocio
{
    public class Persona
    {
        public int Id { get; set; }

        public string Apellidos { get; set; }

        public string Nombres { get; set; }

        public int Creador { get; set; }

        public string Mail { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int Modificador { get; set; }

        public DateTime FechaModificacion { get; set; }
    }
}
