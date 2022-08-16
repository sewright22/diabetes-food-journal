using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Services.EfCore
{
    public class UserService : IUserService
    {
        public UserService(sewright22_foodjournalContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            this.DbContext = dbContext;
            this.PasswordHasher = passwordHasher;
        }

        public sewright22_foodjournalContext DbContext { get; }
        public IPasswordHasher<User> PasswordHasher { get; }

        public async Task<User> AddUser(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (this.DbContext.Users.Any(x => x.Email == userName))
            {
                throw new ArgumentException("User already exists!");
            }

            var userToAdd = new User
            {
                Email = userName,
            };

            userToAdd.Userpassword = new Userpassword
            {
                Password = new Password
                {
                    Text = this.PasswordHasher.HashPassword(userToAdd, password),
                },
            };

            this.DbContext.Add(userToAdd);
            await this.DbContext.SaveChangesAsync().ConfigureAwait(false);
            return userToAdd;
        }

        public async Task<bool> ValidateCredentials(string userName, string password)
        {
            var user = await this.DbContext.Users.Include(x => x.Userpassword).ThenInclude(x => x.Password)
                .SingleOrDefaultAsync(x => x.Email == userName).ConfigureAwait(false);

            if (user == null)
            {
                throw new ArgumentException("Unknown user.");
            }

            var passwordVerificationResult = this.PasswordHasher.VerifyHashedPassword(user, user.Userpassword.Password.Text, password);

            return passwordVerificationResult.HasFlag(PasswordVerificationResult.Success);
        }
    }
}
