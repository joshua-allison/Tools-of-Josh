using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Xunit;
using Moq;
using TheDigitalToolbox.Models;
using TheDigitalToolbox.Controllers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TheDigitalToolboxTests.ControllerTests
{
    public class EmbeddedTests
    {
        #region Setup Tests
        private IHttpContextAccessor http { get; set; }
        public Mock<ITheDigitalToolBoxDBUnitOfWork> SetupRep()
        {
            var rep = new Mock<ITheDigitalToolBoxDBUnitOfWork>();
            rep.Setup(m => m.Embeddeds.Get(It.Is<int>(i => i > 0))).Returns(new Embedded());
            rep.Setup(m => m.Comments.Get(It.Is<int>(i => i > 0))).Returns(new Comment());
            rep.Setup(m => m.Users.Get(It.Is<int>(i => i > 0))).Returns(new User());
            return rep;
        }
        public Embedded SetupModelObject(Mock<ITheDigitalToolBoxDBUnitOfWork> rep)
        {
            return rep.Object.Embeddeds.Get(1);
        }
        #endregion Setup Tests

        #region GET Tests
        [Fact]
        public void GET_IndexActionMethod_ReturnsViewResult()
        {
            //arrange
            var rep = SetupRep();
            var controller = new EmbeddedController(rep.Object, http);

            //act
            var result = controller.Index();

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void GET_DetailsActionMethod_ReturnsTaskActionResult()
        {
            //arrange
            var rep = SetupRep();
            var controller = new EmbeddedController(rep.Object, http);
            var e = SetupModelObject(rep);

            //act
            var result = controller.Details(e.EmbeddedId);

            //assert
            Assert.IsType<Task<ActionResult>>(result);
        }

        [Fact]
        public void GET_CreateActionMethod_ReturnsTaskViewResult()
        {
            //arrange
            var rep = SetupRep();
            var controller = new EmbeddedController(rep.Object, http);

            //act
            var result = controller.Create();

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void GET_UpdateActionMethod_ReturnsViewResult()
        {
            //arrange
            var rep = SetupRep();
            var controller = new EmbeddedController(rep.Object, http);
            var e = SetupModelObject(rep);

            //act
            var result = controller.Update(e.EmbeddedId);

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void GET_RemoveActionMethod_ReturnsViewResult()
        {
            //arrange
            var rep = SetupRep();
            var controller = new EmbeddedController(rep.Object, http);
            var e = SetupModelObject(rep);

            //act
            var result = controller.Remove(e.EmbeddedId);

            //assert
            Assert.IsType<ViewResult>(result);
        }

        #endregion GET Tests

        #region POST Tests

        [Fact]
        public void POST_CreateActionMethod_ReturnsRedirectToActionResult()
        {
            //arrange
            var rep = SetupRep();
            var controller = new EmbeddedController(rep.Object, http);
            var e = SetupModelObject(rep);

            //act
            var result = controller.Create(e);

            //assert
            //In the Create() method, there are two possible outcomes. Create() only returns a RedirectToActionResult if the Update/Create is successful.
            Assert.IsType<RedirectToActionResult>(result);
            Assert.IsNotType<ViewResult>(result);   //functionally unecessary syntatic sugar (if the Create/Update is not successful)
        }
        [Fact]
        public void POST_RemoveActionMethod_ReturnsRedirectToActionResult()
        {
            //arrange
            var rep = SetupRep();
            var controller = new EmbeddedController(rep.Object, http);
            var e = SetupModelObject(rep);

            //act
            var result = controller.Remove(e);

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        #endregion POST Tests

    }
}
