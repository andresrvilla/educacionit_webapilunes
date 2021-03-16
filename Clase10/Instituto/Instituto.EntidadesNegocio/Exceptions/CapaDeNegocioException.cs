using System;
using System.Collections.Generic;
using System.Text;

namespace Instituto.EntidadesNegocio.Exceptions
{
    public class CapaDeNegocioException : Exception
    {
        public CapaDeNegocioException(CapaDeDatosException ex): base("Error de la capa de negocios",ex)
        {
        }
    }
}
