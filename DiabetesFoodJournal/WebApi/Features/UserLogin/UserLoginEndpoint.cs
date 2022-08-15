using Services;

namespace WebApi.Features.UserLogin
{
    public class UserLoginEndpoint : Endpoint<LoginRequest, UserLoginResponse>
    {
        public UserLoginEndpoint(IConfiguration configuration, IUserService userService)
        {
            this.Configuration = configuration;
            this.UserService = userService;
        }

        public IConfiguration Configuration { get; }
        public IUserService UserService { get; }

        public override void Configure()
        {
            Post("/api/login");
            AllowAnonymous();
        }

        //public override Task HandleAsync(LoginRequest req, CancellationToken ct)
        //{
        //    if (this.Configuration is null)
        //    {
        //        throw new ArgumentNullException(nameof(this.Config));
        //    }

        //    // TODO: Inject IUthenticationService once business layer is setup.
        //    // if (await authService.CredentialsAreValid(req.Username, req.Password, ct))
        //    if (req.Username.Contains("test") && req.Password.Contains("test"))
        //    {
        //        var jwtToken = JWTBearer.CreateToken(
        //              signingKey: this.Configuration["Security:TokenSigningKey"],
        //              expireAt: DateTime.UtcNow.AddDays(1),
        //              claims: new[] { ("Username", req.Username), ("UserID", "001") },
        //              roles: new[] { "Admin", "Management" },
        //              permissions: new[] { "ManageInventory", "ManageUsers" });

        //        return this.SendAsync(new UserLoginResponse
        //        {
        //            Username = req.Username,
        //            Token = jwtToken
        //        });
        //    }
        //    else
        //    {
        //        this.ThrowError("The supplied credentials are invalid!");
        //        return null;
        //    }
        //}

        public override async Task<UserLoginResponse> ExecuteAsync(LoginRequest req, CancellationToken ct)
        {
            if (this.Configuration is null)
            {
                throw new ArgumentNullException(nameof(this.Config));
            }

            

            // TODO: Inject IUthenticationService once business layer is setup.
            // if (await authService.CredentialsAreValid(req.Username, req.Password, ct))
            if (await this.UserService.ValidateCredentials(req.Username, req.Password).ConfigureAwait(false))
            {
                var jwtToken = JWTBearer.CreateToken(
                      signingKey: this.Configuration["Security:TokenSigningKey"],
                      expireAt: DateTime.UtcNow.AddDays(1),
                      claims: new[] { ("Username", req.Username), ("UserID", "001") },
                      roles: new[] { "Admin", "Management" },
                      permissions: new[] { "ManageInventory", "ManageUsers" });

                return new UserLoginResponse
                {
                    Username = req.Username,
                    Token = jwtToken
                };
            }
            else
            {
                this.ThrowError("The supplied credentials are invalid!");
                return null;
            }
        }
    }
}
