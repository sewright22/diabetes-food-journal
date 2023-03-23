using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFitbitService
    {
        string BuildAuthorizationUrl(string? clientId, string? redirectUrl, string? scope);
        Task<IResponseToken> GetAccessToken(string? clientId, string? clientSecret, string? code, string? redirectUrl);
    }
}