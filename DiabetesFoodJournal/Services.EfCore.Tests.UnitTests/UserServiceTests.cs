using AutoFixture;
using AutoFixture.AutoMoq;
using DataLayer.Data;
using EntityFrameworkCore.AutoFixture.InMemory;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Services.EfCore.Tests.UnitTests
{
    [TestClass]
    public class UserServiceTests : VerifyBase
    {
        [TestMethod]
        public async Task CreateUserTest()
        {
            var fixture = new Fixture().Customize(new InMemoryCustomization()).Customize(new AutoMoqCustomization());
            fixture.Freeze<sewright22_foodjournalContext>();
            var mockHasher = fixture.Freeze<Mock<IPasswordHasher<User>>>();

            mockHasher.Setup(x => x.HashPassword(It.IsAny<User>(), "password")).Returns("encryptedPassword");

            var userService = fixture.Create<UserService>();

            var actual = await userService.AddUser("username", "password").ConfigureAwait(false);

            await this.Verify(actual).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task UserAlreadyExists()
        {
            var fixture = new Fixture().Customize(new InMemoryCustomization()).Customize(new AutoMoqCustomization());
            var dbContext = fixture.Freeze<sewright22_foodjournalContext>();

            dbContext.Add(new User
            {
                Email = "username",
            });

            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            var userService = fixture.Create<UserService>();

            var addUserAction = async () => { await userService.AddUser("username", "password").ConfigureAwait(false); };
            await addUserAction.Should().ThrowAsync<ArgumentException>().WithMessage("User already exists!").ConfigureAwait(false);
        }

        [TestMethod]
        public async Task NullUsernameIsGivenToCreateUser()
        {
            var fixture = new Fixture().Customize(new InMemoryCustomization()).Customize(new AutoMoqCustomization());
            fixture.Freeze<sewright22_foodjournalContext>();

            var userService = fixture.Create<UserService>();

            var addUserAction = async () => { await userService.AddUser(null, "password").ConfigureAwait(false); };
            await addUserAction.Should().ThrowAsync<ArgumentNullException>().WithParameterName("userName").ConfigureAwait(false);
        }

        [TestMethod]
        public async Task NullPasswordIsGivenToCreateUser()
        {
            var fixture = new Fixture().Customize(new InMemoryCustomization()).Customize(new AutoMoqCustomization());
            fixture.Freeze<sewright22_foodjournalContext>();

            var userService = fixture.Create<UserService>();

            var addUserAction = async () => { await userService.AddUser("username", null!).ConfigureAwait(false); };
            await addUserAction.Should().ThrowAsync<ArgumentNullException>().WithParameterName("password").ConfigureAwait(false);
        }
    }
}