using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using Services;
using Services.External;

namespace WebApi.Features.Fitbit
{
    public class FitbitCallbackEndpoint : FastEndpoints.Endpoint<FitbitCallbackRequest>
    {
        public FitbitCallbackEndpoint(IFitbitService fitbitService, IOptions<FitbitApiOptions> apiOptions)
        {
            this.FitbitService = fitbitService;
            this.ApiOptions = apiOptions.Value;
        }

        public IFitbitService FitbitService { get; }
        public FitbitApiOptions ApiOptions { get; }

        public override void Configure()
        {
            this.Get("/auth/fitbit/callback");
            this.AllowAnonymous();
        }

        public override async Task HandleAsync(FitbitCallbackRequest req, CancellationToken ct)
        {
            IResponseToken token = await this.FitbitService.GetAccessToken(this.ApiOptions.ClientId, this.ApiOptions.ClientSecret, req.Code, this.ApiOptions.RedirectUrl);

            await this.SendOkAsync(token).ConfigureAwait(false);
        }
    }
}
