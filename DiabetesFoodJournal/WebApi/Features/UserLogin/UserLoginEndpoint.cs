namespace WebApi.Features.UserLogin
{
    public class UserLoginEndpoint : Endpoint<LoginRequest>
    {
        public override void Configure()
        {
            Post("/api/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            if (this.Config is null)
            {
                throw new ArgumentNullException(nameof(this.Config));
            }

            // TODO: Inject IUthenticationService once business layer is setup.
            // if (await authService.CredentialsAreValid(req.Username, req.Password, ct))
            if (req.Username.Contains("test") && req.Password.Contains("test"))
            {
                var jwtToken = JWTBearer.CreateToken(
                      signingKey: this.Config["Security:TokenSigningKey"],
                      expireAt: DateTime.UtcNow.AddDays(1),
                      claims: new[] { ("Username", req.Username), ("UserID", "001") },
                      roles: new[] { "Admin", "Management" },
                      permissions: new[] { "ManageInventory", "ManageUsers" });

                await SendAsync(new
                {
                    Username = req.Username,
                    Token = jwtToken
                });
            }
            else
            {
                ThrowError("The supplied credentials are invalid!");
            }
        }
    }
}
