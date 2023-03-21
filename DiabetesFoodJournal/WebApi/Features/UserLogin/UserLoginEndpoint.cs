using Core.Models;
using Core.Requests;
using Core.Responses;
using Services;

namespace WebApi.Features.UserLogin
{
    public class UserLoginEndpoint : Endpoint<LoginRequest, LoginResponse>
    {
        public UserLoginEndpoint(IConfiguration configuration, IUserService userService)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.SigningKey = configuration["TokenSigningKeys:Application"];
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        public IUserService UserService { get; }
        public string? SigningKey { get; }

        public override void Configure()
        {
            Post("/api/login");
            AllowAnonymous();
        }

        public override async Task<LoginResponse> ExecuteAsync(LoginRequest req, CancellationToken ct)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
            {
                this.AddError("The username and password are required!");
            }

            if (this.SigningKey is null)
            {
                this.AddError("The signing key is not configured!");
            }

            this.ThrowIfAnyErrors();

            bool credentialsAreValid = await this.UserService.ValidateCredentials(req!.Username!, req!.Password!).ConfigureAwait(false);

            if (credentialsAreValid == false)
            {
                this.ThrowError("The supplied credentials are invalid!");
            }

            var jwtToken = JWTBearer.CreateToken(
                      signingKey: this.SigningKey!,
                      expireAt: DateTime.UtcNow.AddDays(1),
                      claims: new[] { ("Username", req.Username!), ("UserID", "001") },
                      roles: new[] { "Admin", "Management" },
                      permissions: new[] { "ManageInventory", "ManageUsers" });

            return new LoginResponse
            {
                UserInformation = new UserInformation
                {
                    UserName = req.Username!,
                    Token = jwtToken,
                }
            };
        }
    }
}
