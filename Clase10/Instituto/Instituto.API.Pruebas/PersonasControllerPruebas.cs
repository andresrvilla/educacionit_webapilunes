using AutoMapper;
using Instituto.API.Controllers;
using Instituto.DTO;
using Instituto.EntidadesNegocio;
using Instituto.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instituto.API.Pruebas
{
    [TestClass]
    public class PersonasControllerPruebas
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestCategory("PersonasController.Constructor")]
        public void PersonasController_ConstructorDebeFallarSiMapperEsNull()
        {
            //Arrange
            Mock<IPersonasNegocio> mockPersonasNegocio = new Mock<IPersonasNegocio>();
            //Act
            PersonasController controller = new PersonasController(null, mockPersonasNegocio.Object);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestCategory("PersonasController.Constructor")]
        public void PersonasController_ConstructorDebeFallarSiObjetoNegocioEsNull()
        {
            //Arrange
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            //Act
            PersonasController controller = new PersonasController(mockMapper.Object, null);
            //Assert
        }

        [TestMethod]
        [TestCategory("PersonasController.GetPersonas")]
        public async Task PersonasController_DeberiaDevolverLaListaDePersonas()
        {
            //TODO: Hacer que devuelva datos mockeados. 3 personas para que pase la prueba

            //Arrange
            Mock<IPersonasNegocio> mockPersonasNegocio = new Mock<IPersonasNegocio>();
            mockPersonasNegocio.Setup(x => x.ObtenerTodasLasPersonas()).Returns(new List<Persona>());
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            PersonasController controller = new PersonasController(mockMapper.Object, mockPersonasNegocio.Object);

            //Act
            var respuesta = await controller.GetPersonas();
            var okResult = respuesta as OkObjectResult;
            List<PersonaDTO> resultado = okResult.Value as List<PersonaDTO>;

            //Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(resultado);
            Assert.AreEqual(3, resultado.Count);
        }
    }
}
