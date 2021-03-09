using Instituto.Datos.Interfaces;
using Instituto.EntidadesNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Instituto.Negocio.Pruebas
{
    [TestClass]
    public class PersonasNegocioPruebas
    {
        private PersonasNegocio objetoParaProbar;

        [TestInitialize]
        public void Initialize()
        {
            List<Persona> resultadoClaseNegocios = new List<Persona>()
            {
                new Persona(){ Id=1,Nombres="Persona",Apellidos="Uno",Mail="personauno@educacionit.com"},
                new Persona(){ Id=2,Nombres="Persona",Apellidos="Dos",Mail="personados@educacionit.com"},
                new Persona(){ Id=3,Nombres="Persona",Apellidos="Tres",Mail="personatres@educacionit.com"},
            };

            Mock<IPersonasDatos> mockPersonasDatos = new Mock<IPersonasDatos>();

            mockPersonasDatos
                .Setup(x => x.ObtenerTodas())
                .Returns(resultadoClaseNegocios);

            objetoParaProbar = new PersonasNegocio(mockPersonasDatos.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<Persona> listaDePersonas = objetoParaProbar.ObtenerTodasLasPersonas();

            Assert.IsNotNull(listaDePersonas);
            Assert.AreEqual(3, listaDePersonas.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMethod2()
        {
            objetoParaProbar.AgregarPersona(null);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod3()
        {
            Persona persona = new Persona();
            objetoParaProbar.AgregarPersona(persona);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod4()
        {
            Persona persona = new Persona()
            {
                Nombres = "Prueba",
                Apellidos = ""
            };
            objetoParaProbar.AgregarPersona(persona);
        }
    }0
}
