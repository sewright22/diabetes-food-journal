using Microsoft.Extensions.Options;
using Services;
using Services.External;

namespace WebApi.Features.Fitbit
{
    public class GetFitbitLink : EndpointWithoutRequest
    {
        public GetFitbitLink(IFitbitService fitbitService, IOptions<FitbitApiOptions> fitBitOptions)
        {
            this.FitbitService = fitbitService;
            this.FitbitOptions = fitBitOptions.Value;
        }

        public IFitbitService FitbitService { get; }
        public FitbitApiOptions FitbitOptions { get; }

        public override void Configure()
        {
            this.Get("/api/fitbit/link");
        }

        public override Task HandleAsync(CancellationToken ct)
        {
            return this.SendOkAsync(this.FitbitService.BuildAuthorizationUrl(this.FitbitOptions.ClientId, this.FitbitOptions.RedirectUrl, this.FitbitOptions.Scope));
        }
    }
}
