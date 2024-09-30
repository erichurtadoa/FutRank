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
    public class ClubTest
    {
        public class ClubControllerTests
        {
            private readonly Mock<IClubService> _clubServiceMock;
            private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
            private readonly ClubController _controller;
            private readonly ClaimsPrincipal _userPrincipal;

            public ClubControllerTests()
            {
                _clubServiceMock = new Mock<IClubService>();
                _userManagerMock = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);

                _controller = new ClubController(_clubServiceMock.Object, _userManagerMock.Object);

                // Simulación de usuario autenticado
                _userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString())
                }, "mock"));

                _controller.ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = _userPrincipal }
                };
            }

            [Fact]
            public void GetClubs_WithAuthenticatedUser_ShouldCallGetClubsUserAsync()
            {
                // Arrange
                var filter = new ClubFilter();
                _clubServiceMock.Setup(service => service.GetClubsUserAsync(It.IsAny<Guid>(), filter))
                    .Returns(new List<ClubDto>());

                // Act
                var result = _controller.GetClubs(filter);

                // Assert
                _clubServiceMock.Verify(service => service.GetClubsUserAsync(It.IsAny<Guid>(), filter), Times.Once);
                _clubServiceMock.Verify(service => service.GetClubsAsync(filter), Times.Never);
            }

            [Fact]
            public void GetClubs_WithoutAuthenticatedUser_ShouldCallGetClubsAsync()
            {
                // Arrange: Usuario no autenticado
                _controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

                var filter = new ClubFilter();
                _clubServiceMock.Setup(service => service.GetClubsAsync(filter))
                    .Returns(new List<ClubDto>());

                // Act
                var result = _controller.GetClubs(filter);

                // Assert
                _clubServiceMock.Verify(service => service.GetClubsAsync(filter), Times.Once);
                _clubServiceMock.Verify(service => service.GetClubsUserAsync(It.IsAny<Guid>(), filter), Times.Never);
            }

            [Fact]
            public async Task GetUserClubs_ShouldReturnUserClubs()
            {
                // Arrange
                var userId = Guid.NewGuid();
                var clubs = new List<ClubDto> { new ClubDto() };

                _clubServiceMock.Setup(service => service.GetOnlyClubsUserAsync(userId))
                    .ReturnsAsync(clubs);

                // Act
                var result = await _controller.GetUserClubs(userId);

                // Assert
                Assert.Equal(clubs, result);
                _clubServiceMock.Verify(service => service.GetOnlyClubsUserAsync(userId), Times.Once);
            }

            [Fact]
            public void GetClubById_WithAuthenticatedUser_ShouldCallServiceWithUserId()
            {
                // Arrange
                var clubId = 1;
                var userGuid = Guid.NewGuid();

                // Simulamos una instancia de ClubDetailsDto con valores de prueba
                var expectedClubDetails = new ClubDetailsDto
                {
                    Id = clubId,
                    Name = "Test Club",
                    Code = "TC123",
                    Founded = 1900,
                    National = true,
                    Logo = "test_logo.png",
                    Popularity = 4.5f,
                    Country = "Test Country",
                    flag = "test_flag.png",
                    VenueName = "Test Venue",
                    VenueAddress = "123 Test Street",
                    VenueCapacity = 50000,
                    VenueSurface = "Grass",
                    VenueImage = "venue_image.png",
                    VenueCity = "Test City",
                    Favourite = true,
                    Upvote = false,
                    Standings = new List<StandingDto>()
                };

                // Configuramos el mock para que GetClubByIdAsync devuelva el objeto esperado
                _clubServiceMock.Setup(service => service.GetClubByIdAsync(clubId, It.IsAny<Guid>()))
                    .Returns(expectedClubDetails);

                // Act
                var result = _controller.GetClubById(clubId);

                // Assert
                Assert.NotNull(result); // Verificamos que no sea null
                Assert.Equal(expectedClubDetails.Id, result.Id);
                Assert.Equal(expectedClubDetails.Name, result.Name);
                Assert.Equal(expectedClubDetails.Code, result.Code);
                Assert.Equal(expectedClubDetails.Founded, result.Founded);
                Assert.Equal(expectedClubDetails.National, result.National);
                Assert.Equal(expectedClubDetails.Logo, result.Logo);
                Assert.Equal(expectedClubDetails.Popularity, result.Popularity);
                Assert.Equal(expectedClubDetails.Country, result.Country);
                Assert.Equal(expectedClubDetails.flag, result.flag);
                Assert.Equal(expectedClubDetails.VenueName, result.VenueName);
                Assert.Equal(expectedClubDetails.VenueAddress, result.VenueAddress);
                Assert.Equal(expectedClubDetails.VenueCapacity, result.VenueCapacity);
                Assert.Equal(expectedClubDetails.VenueSurface, result.VenueSurface);
                Assert.Equal(expectedClubDetails.VenueImage, result.VenueImage);
                Assert.Equal(expectedClubDetails.VenueCity, result.VenueCity);
                Assert.Equal(expectedClubDetails.Favourite, result.Favourite);
                Assert.Equal(expectedClubDetails.Upvote, result.Upvote);
                Assert.Equal(expectedClubDetails.Standings, result.Standings);
            }

            [Fact]
            public async Task VoteClub_ShouldCallServiceAndReturnOk()
            {
                // Arrange
                var clubId = 1;
                var upVote = true;
                var userId = _userPrincipal.FindFirstValue(ClaimTypes.Sid);

                _clubServiceMock.Setup(service => service.VoteClub(upVote, It.IsAny<Guid>(), clubId))
                    .Returns(Task.CompletedTask);

                // Act
                var result = await _controller.VoteClub(upVote, clubId);

                // Assert
                Assert.IsType<OkResult>(result);
                _clubServiceMock.Verify(service => service.VoteClub(upVote, It.IsAny<Guid>(), clubId), Times.Once);
            }

            [Fact]
            public async Task AddFavourite_ShouldCallServiceAndReturnOk()
            {
                // Arrange
                var clubId = 1;
                var userId = _userPrincipal.FindFirstValue(ClaimTypes.Sid);

                _clubServiceMock.Setup(service => service.AddFavourite(It.IsAny<Guid>(), clubId))
                    .Returns(Task.CompletedTask);

                // Act
                var result = await _controller.AddFavourite(clubId);

                // Assert
                Assert.IsType<OkResult>(result);
                _clubServiceMock.Verify(service => service.AddFavourite(It.IsAny<Guid>(), clubId), Times.Once);
            }

        }
    }
}
