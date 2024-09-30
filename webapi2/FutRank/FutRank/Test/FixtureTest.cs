using FutRank.Controllers;
using FutRank.Dtos;
using FutRank.Models;
using FutRank.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace FutRank.Test
{
    public class FixtureTest
    {
        private readonly FixtureController _controller;
        private readonly Mock<IFixtureService> _fixtureServiceMock;
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;

        public FixtureTest()
        {
            _fixtureServiceMock = new Mock<IFixtureService>();
            _userManagerMock = new Mock<UserManager<IdentityUser>>(
                Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);

            _controller = new FixtureController(_fixtureServiceMock.Object, _userManagerMock.Object);
        }

        [Fact]
        public async Task GetFixtures_WithAuthenticatedUser_ShouldCallServiceWithUserId()
        {
            // Arrange
            var filter = new FixtureFilter();
            var userGuid = Guid.NewGuid();
            var expectedFixtures = new List<FixtureDto> { new FixtureDto() };

            // Simula el claim del usuario autenticado
            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Sid, userGuid.ToString())
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userClaims }
            };

            // Configura el mock para devolver el resultado esperado
            _fixtureServiceMock.Setup(s => s.GetFixturesUserAsync(userGuid, filter))
                .ReturnsAsync(expectedFixtures);

            // Act
            var result = await _controller.GetFixtures(filter);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedFixtures, result);
            _fixtureServiceMock.Verify(s => s.GetFixturesUserAsync(userGuid, filter), Times.Once);
        }

        [Fact]
        public async Task GetFixtures_WithoutAuthenticatedUser_ShouldCallServiceWithoutUserId()
        {
            // Arrange
            var filter = new FixtureFilter();
            var expectedFixtures = new List<FixtureDto> { new FixtureDto() };

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext() // Sin establecer un usuario en el contexto
            };

            // Configura el mock para devolver el resultado esperado sin usuario
            _fixtureServiceMock.Setup(s => s.GetFixturesAsync(filter))
                .ReturnsAsync(expectedFixtures);

            // Act
            var result = await _controller.GetFixtures(filter);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedFixtures, result);
            _fixtureServiceMock.Verify(s => s.GetFixturesAsync(filter), Times.Once);
        }

        [Fact]
        public async Task GetUserFixtures_ShouldReturnFixturesForUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var expectedFixtures = new List<FixtureDto> { new FixtureDto() };

            // Configura el mock para devolver el resultado esperado
            _fixtureServiceMock.Setup(s => s.GetOnlyFixturesUserAsync(userId))
                .ReturnsAsync(expectedFixtures);

            // Act
            var result = await _controller.GetUserFixtures(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedFixtures, result);
            _fixtureServiceMock.Verify(s => s.GetOnlyFixturesUserAsync(userId), Times.Once);
        }

        [Fact]
        public async Task GetFixtureById_WithAuthenticatedUser_ShouldCallServiceWithUserId()
        {
            // Arrange
            var fixtureId = 1;
            var userGuid = Guid.NewGuid();
            var expectedFixture = new FixtureDetailsDto();

            // Simula el claim del usuario autenticado
            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Sid, userGuid.ToString())
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userClaims }
            };

            // Configura el mock para devolver el resultado esperado
            _fixtureServiceMock.Setup(s => s.GetFixtureByIdAsync(fixtureId, userGuid))
                .ReturnsAsync(expectedFixture);

            // Act
            var result = await _controller.GetFixtureById(fixtureId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedFixture, result);
            _fixtureServiceMock.Verify(s => s.GetFixtureByIdAsync(fixtureId, userGuid), Times.Once);
        }

        [Fact]
        public async Task GetFixtureById_WithoutAuthenticatedUser_ShouldCallServiceWithoutUserId()
        {
            // Arrange
            var fixtureId = 1;
            var expectedFixture = new FixtureDetailsDto();

            // Aquí simulamos que no hay un usuario autenticado configurando un contexto vacío.
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext() // Sin establecer un usuario en el contexto
            };

            // Configura el mock para devolver el resultado esperado
            _fixtureServiceMock.Setup(s => s.GetFixtureByIdAsync(fixtureId, It.IsAny<Guid>()))
                .ReturnsAsync(expectedFixture);

            // Act
            var result = await _controller.GetFixtureById(fixtureId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedFixture, result);
            _fixtureServiceMock.Verify(s => s.GetFixtureByIdAsync(fixtureId, It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task VoteFixture_WithAuthenticatedUser_ShouldCallServiceWithVote()
        {
            // Arrange
            var vote = 1;
            var fixtureId = 123;
            var userGuid = Guid.NewGuid();

            // Simula el claim del usuario autenticado
            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Sid, userGuid.ToString())
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userClaims }
            };

            // Act
            var result = await _controller.VoteFixture(vote, fixtureId);

            // Assert
            Assert.IsType<OkResult>(result);
            _fixtureServiceMock.Verify(s => s.VoteFixture(vote, userGuid, fixtureId), Times.Once);
        }

        [Fact]
        public async Task CreateComment_WithAuthenticatedUser_ShouldReturnComment()
        {
            // Arrange
            var fixtureId = 1;
            var content = "Test comment";
            var userGuid = Guid.NewGuid();
            var expectedComment = new CommentFixtureDto();

            // Simula el claim del usuario autenticado
            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Sid, userGuid.ToString())
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userClaims }
            };

            // Configura el mock para devolver el comentario esperado
            _fixtureServiceMock.Setup(s => s.CreateCommentAsync(fixtureId, content, userGuid))
                .ReturnsAsync(expectedComment);

            // Act
            var result = await _controller.CreateComment(fixtureId, content);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedComment, result);
            _fixtureServiceMock.Verify(s => s.CreateCommentAsync(fixtureId, content, userGuid), Times.Once);
        }
    }
}
