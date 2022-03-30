using Moq;
using TheDigitalToolbox.Controllers.Domain;
using TheDigitalToolbox.Models;
using Xunit;

namespace TheDigitalToolboxTests.ControllerTests
{
    public class CommentControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            //arrange
            var ctxFake = new Mock<ToolboxContext>();
            var controller = new Mock<CommentsController>(ctxFake.Object);

            //act


            //assert
    }
}
}
