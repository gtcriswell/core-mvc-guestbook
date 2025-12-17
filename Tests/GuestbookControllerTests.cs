using API.Controllers;
using Domain.Business;
using Domain.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests
{
    public class GuestbookControllerTests
    {
        private readonly Mock<IGBRepository> _mockRepository;
        private readonly GuestbookController _controller;

        public GuestbookControllerTests()
        {
            _mockRepository = new Mock<IGBRepository>();
            _controller = new GuestbookController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetEntries_WithEntries_ReturnsOkResult()
        {
            // Arrange
            var entries = new List<GuestBook>
            {
                new() { GuestId = 1, EmailAddress = "test1@example.com", Comment = "Test 1", CreatedDate = DateTime.Now },
                new() { GuestId = 2, EmailAddress = "test2@example.com", Comment = "Test 2", CreatedDate = DateTime.Now }
            };
            _mockRepository.Setup(x => x.GetEntries()).ReturnsAsync(entries);

            // Act
            var result = await _controller.GetEntries();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult!.Value.Should().BeEquivalentTo(entries);
            _mockRepository.Verify(x => x.GetEntries(), Times.Once);
        }

        [Fact]
        public async Task GetEntries_WithNoEntries_ReturnsNotFound()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetEntries()).ReturnsAsync(new List<GuestBook>());

            // Act
            var result = await _controller.GetEntries();

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            _mockRepository.Verify(x => x.GetEntries(), Times.Once);
        }

        [Fact]
        public async Task AddEntry_WithValidEntry_ReturnsOkResult()
        {
            // Arrange
            var guestBook = new GuestBook
            {
                EmailAddress = "test@example.com",
                Comment = "Test comment"
            };
            var addedEntry = new GuestBook
            {
                GuestId = 1,
                EmailAddress = "test@example.com",
                Comment = "Test comment",
                CreatedDate = DateTime.Now
            };
            _mockRepository.Setup(x => x.AddEntry(guestBook)).ReturnsAsync(addedEntry);

            // Act
            var result = await _controller.AddEntry(guestBook);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult!.Value.Should().BeEquivalentTo(addedEntry);
            _mockRepository.Verify(x => x.AddEntry(guestBook), Times.Once);
        }

        [Fact]
        public async Task AddEntry_WithNullResult_ReturnsNotFound()
        {
            // Arrange
            var guestBook = new GuestBook
            {
                EmailAddress = "test@example.com",
                Comment = "Test comment"
            };
            _mockRepository.Setup(x => x.AddEntry(guestBook)).ReturnsAsync((GuestBook)null!);

            // Act
            var result = await _controller.AddEntry(guestBook);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            _mockRepository.Verify(x => x.AddEntry(guestBook), Times.Once);
        }

        [Fact]
        public async Task UpdateEntry_WithValidEntry_ReturnsOkResult()
        {
            // Arrange
            var guestBook = new GuestBook
            {
                GuestId = 1,
                EmailAddress = "updated@example.com",
                Comment = "Updated comment"
            };
            _mockRepository.Setup(x => x.UpdateEntry(guestBook)).ReturnsAsync(guestBook);

            // Act
            var result = await _controller.UpdateEntry(guestBook);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult!.Value.Should().BeEquivalentTo(guestBook);
            _mockRepository.Verify(x => x.UpdateEntry(guestBook), Times.Once);
        }

        [Fact]
        public async Task RemoveEntry_WithValidId_ReturnsOkResult()
        {
            // Arrange
            int id = 1;
            _mockRepository.Setup(x => x.RemoveEntry(id)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.RemoveEntry(id);

            // Assert
            result.Should().BeOfType<OkResult>();
            _mockRepository.Verify(x => x.RemoveEntry(id), Times.Once);
        }
    }
}