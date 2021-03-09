using Instituto.Datos.Interfaces;
using Instituto.EntidadesNegocio;
using Instituto.EntidadesNegocio.Exceptions;
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
        [TestCategory("PersonasNegocio.ObtenerTodasLasPersonas")]
        public void ObtenerTodasLasPersonas_DeberiaDevolverLasPersonasEsperadas()
        {
            List<Persona> listaDePersonas = objetoParaProbar.ObtenerTodasLasPersonas();

            Assert.IsNotNull(listaDePersonas);
            Assert.AreEqual(3, listaDePersonas.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(CapaDeNegocioException))]
        [TestCategory("PersonasNegocio.ObtenerTodasLasPersonas")]
        public void ObtenerTodasLasPersonas_DeberiaFallarSiLaCapaDeDatosFalla()
        {
            // Patrón "Arrange-Act-Assert"

            // Arrange: Configurar todo el caso por ejemplo los mocks, el objeto a probar, etc
            Mock<IPersonasDatos> mockCapaDatos = new Mock<IPersonasDatos>();
            mockCapaDatos.Setup(x => x.ObtenerTodas()).Throws(new CapaDeDatosException());

            PersonasNegocio capaNegocio = new PersonasNegocio(mockCapaDatos.Object);
            // Act: El motivo de la prueba. Es decir, corro lo que quiero probar
            capaNegocio.ObtenerTodasLasPersonas();

            // Assert: La verificacion de que lo que probé funciono correctamente
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestCategory("PersonasNegocio.AgregarPersona")]
        public void AgregarPersona_DeberiaFallarSiLePasoComoParametroNull()
        {
            objetoParaProbar.AgregarPersona(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("PersonasNegocio.AgregarPersona")]
        public void AgregarPersona_DeberiaFallarSiLePasoUnaPersonaVacia()
        {
            Persona persona = new Persona();
            objetoParaProbar.AgregarPersona(persona);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("PersonasNegocio.AgregarPersona")]
        public void AgregarPersona_DeberiaFallarSiLePasoUnaPersonaSinApellido()
        {
            Persona persona = new Persona()
            {
                Nombres = "Prueba",
                Apellidos = string.Empty
            };
            objetoParaProbar.AgregarPersona(persona);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("PersonasNegocio.AgregarPersona")]
        public void AgregarPersona_DeberiaFallarSiLePasoUnaPersonaConApellidoNulo()
        {
            Persona persona = new Persona()
            {
                Nombres = "Prueba",
                Apellidos = null
            };
            objetoParaProbar.AgregarPersona(persona);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("PersonasNegocio.AgregarPersona")]
        public void AgregarPersona_DeberiaFallarSiLePasoUnaPersonaConApellidoSoloEspacios()
        {
            Persona persona = new Persona()
            {
                Nombres = "Prueba",
                Apellidos = "           "
            };
            objetoParaProbar.AgregarPersona(persona);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("PersonasNegocio.AgregarPersona")]
        public void AgregarPersona_DeberiaFallarSiLePasoUnaPersonaSinNombre()
        {
            Persona persona = new Persona()
            {
                Nombres = string.Empty,
                Apellidos = "Algo"
            };
            objetoParaProbar.AgregarPersona(persona);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("PersonasNegocio.AgregarPersona")]
        public void AgregarPersona_DeberiaFallarSiLePasoUnaPersonaConNombreNulo()
        {
            Persona persona = new Persona()
            {
                Nombres = null,
                Apellidos = "Algo"
            };
            objetoParaProbar.AgregarPersona(persona);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCategory("PersonasNegocio.AgregarPersona")]
        public void AgregarPersona_DeberiaFallarSiLePasoUnaPersonaConNombreSoloEspacios()
        {
            Persona persona = new Persona()
            {
                Nombres = "         ",
                Apellidos = "Algo"
            };
            objetoParaProbar.AgregarPersona(persona);
        }

        [TestMethod]
        [ExpectedException(typeof(CapaDeNegocioException))]
        [TestCategory("PersonasNegocio.AgregarPersona")]
        public void AgregarPersona_DeberiaFallarSiLaCapaDeDatosFalla()
        {
            //Arrange
            Persona persona = new Persona()
            {
                Nombres = "Nombre",
                Apellidos = "Apellido"
            };

            Mock<IPersonasDatos> mockCapaDatos = new Mock<IPersonasDatos>();
            mockCapaDatos.Setup(x => x.Guardar(persona)).Throws(new CapaDeDatosException());

            PersonasNegocio personasNegocio = new PersonasNegocio(mockCapaDatos.Object);
            //Act
            personasNegocio.AgregarPersona(persona);

            //Assert
        }

    }
}
