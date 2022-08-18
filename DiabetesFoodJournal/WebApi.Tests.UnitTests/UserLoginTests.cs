using AutoFixture;
using AutoFixture.AutoMoq;
using FastEndpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Services;
using WebApi.Features.UserLogin;
using FluentAssertions;
using FluentAssertions.Common;

namespace WebApi.Tests.UnitTests
{
    [TestClass]
    public class UserLoginTests
    {
        [TestMethod]
        public async Task LoginSuccess()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockConfig = fixture.Freeze<Mock<IConfiguration>>();
            var mockLogger = fixture.Freeze<Mock<ILogger<UserLoginEndpoint>>>();
            var mockUserService = fixture.Freeze<Mock<IUserService>>();
            mockConfig.Setup(x => x["Security:TokenSigningKey"]).Returns("0000000000000000");

            var endpoint = Factory.Create<UserLoginEndpoint>(mockConfig.Object, mockUserService.Object);

            var req = new LoginRequest
            {
                Username = "test",
                Password = "test"
            };

            mockUserService.Setup(x => x.ValidateCredentials(req.Username, req.Password)).ReturnsAsync(true);

            // Act
            var response = await endpoint.ExecuteAsync(req, default);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(endpoint.ValidationFailed);
            Assert.IsNotNull(response.Token);
        }

        [TestMethod]
        public async Task LoginFailure()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockConfig = fixture.Freeze<Mock<IConfiguration>>();
            var mockLogger = fixture.Freeze<Mock<ILogger<UserLoginEndpoint>>>();
            var mockUserService = fixture.Freeze<Mock<IUserService>>();
            mockConfig.Setup(x => x["Security:TokenSigningKey"]).Returns("0000000000000000");

            var endpoint = Factory.Create<UserLoginEndpoint>(mockConfig.Object, mockUserService.Object);

            var req = new LoginRequest
            {
                Username = "invalidUsername",
                Password = "test"
            };

            mockUserService.Setup(x => x.ValidateCredentials(req.Username, req.Password)).ReturnsAsync(false);

            // Act
            var actual = async () => await endpoint.ExecuteAsync(req, default).ConfigureAwait(false);

            await actual.Should().ThrowAsync<ValidationFailureException>();
        }
    }
}