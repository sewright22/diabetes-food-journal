using AutoFixture;
using AutoFixture.AutoMoq;
using FastEndpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Features.UserLogin;

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
            mockConfig.Setup(x => x["Security:TokenSigningKey"]).Returns("0000000000000000");

            var endpoint = Factory.Create<UserLoginEndpoint>(mockConfig.Object);

            var req = new LoginRequest
            {
                Username = "test",
                Password = "test"
            };

            // Act
            var response = await endpoint.ExecuteAsync(req, default);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(endpoint.ValidationFailed);
            Assert.IsNotNull(response.Token);
        }

        [TestMethod]
        public void LoginFailure()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockConfig = fixture.Freeze<Mock<IConfiguration>>();
            var mockLogger = fixture.Freeze<Mock<ILogger<UserLoginEndpoint>>>();
            mockConfig.Setup(x => x["Security:TokenSigningKey"]).Returns("0000000000000000");

            var endpoint = Factory.Create<UserLoginEndpoint>(mockConfig.Object);

            var req = new LoginRequest
            {
                Username = "invalidUsername",
                Password = "test"
            };

            // Act
            Assert.ThrowsException<ValidationFailureException>(() => endpoint.ExecuteAsync(req, default));
        }
    }
}