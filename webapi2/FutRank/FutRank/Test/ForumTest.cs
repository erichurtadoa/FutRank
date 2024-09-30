using FutRank.Controllers;
using FutRank.Dtos;
using FutRank.Models;
using FutRank.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace FutRank.Test
{
    public class ForumTest
    {
        private readonly ForumController _controller;
        private readonly Mock<IForumService> _forumServiceMock;

        public ForumTest()
        {
            _forumServiceMock = new Mock<IForumService>();

            _controller = new ForumController(_forumServiceMock.Object);
        }

        [Fact]
        public async Task GetThreads_ShouldReturnListOfThreads()
        {
            // Arrange
            var expectedThreads = new List<ForumThreadDto>
        {
            new ForumThreadDto { Id = 1, Title = "Test Thread 1" },
            new ForumThreadDto { Id = 2, Title = "Test Thread 2" }
        };

            _forumServiceMock.Setup(s => s.GetForumAsync())
                .ReturnsAsync(expectedThreads);

            // Act
            var result = await _controller.GetThreads();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedThreads, result);
            _forumServiceMock.Verify(s => s.GetForumAsync(), Times.Once);
        }

        [Fact]
        public async Task GetThread_ShouldReturnThreadById()
        {
            // Arrange
            var threadId = 1;
            var expectedThread = new ForumThreadDto { Id = threadId, Title = "Test Thread" };

            _forumServiceMock.Setup(s => s.GetThreadByIdAsync(threadId))
                .ReturnsAsync(expectedThread);

            // Act
            var result = await _controller.GetThread(threadId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedThread, result);
            _forumServiceMock.Verify(s => s.GetThreadByIdAsync(threadId), Times.Once);
        }

        [Fact]
        public async Task CreateThread_WithAuthenticatedUser_ShouldReturnCreatedThread()
        {
            // Arrange
            var title = "New Thread";
            var userGuid = Guid.NewGuid();
            var expectedThread = new ForumThreadDto { Id = 1, Title = title };

            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Sid, userGuid.ToString())
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userClaims }
            };

            _forumServiceMock.Setup(s => s.CreateThreadAsync(title, userGuid))
                .ReturnsAsync(expectedThread);

            // Act
            var result = await _controller.CreateThread(title);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedThread, result);
            _forumServiceMock.Verify(s => s.CreateThreadAsync(title, userGuid), Times.Once);
        }

        [Fact]
        public async Task CreateThread_WithoutAuthenticatedUser_ShouldThrowException()
        {
            // Arrange
            var title = "New Thread";

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext() // Sin usuario autenticado
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _controller.CreateThread(title));

            _forumServiceMock.Verify(s => s.CreateThreadAsync(It.IsAny<string>(), It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task CreateComment_WithAuthenticatedUser_ShouldReturnCreatedComment()
        {
            // Arrange
            var threadId = 1;
            var content = "Test comment";
            var userGuid = Guid.NewGuid();
            var expectedComment = new CommentDto { Id = 1, Content = content };

            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Sid, userGuid.ToString())
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userClaims }
            };

            _forumServiceMock.Setup(s => s.CreateCommentAsync(threadId, content, userGuid))
                .ReturnsAsync(expectedComment);

            // Act
            var result = await _controller.CreateComment(threadId, content);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedComment, result);
            _forumServiceMock.Verify(s => s.CreateCommentAsync(threadId, content, userGuid), Times.Once);
        }

        [Fact]
        public async Task CreateComment_WithoutAuthenticatedUser_ShouldThrowException()
        {
            // Arrange
            var threadId = 1;
            var content = "Test comment";

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext() // Sin usuario autenticado
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _controller.CreateComment(threadId, content));

            _forumServiceMock.Verify(s => s.CreateCommentAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Guid>()), Times.Never);
        }
    }
}
