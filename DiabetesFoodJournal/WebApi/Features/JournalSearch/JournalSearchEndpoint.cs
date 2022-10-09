using Services;
using Services.EfCore;

namespace WebApi.Features.JournalSearch
{
    public class JournalSearchEndpoint : Endpoint<JournalSearchRequest, List<JournalSearchResponse>>
    {
        public JournalSearchEndpoint(IJournalService journalService)
        {
            this.JournalService = journalService;
        }

        public IJournalService JournalService { get; }

        public override void Configure()
        {
            this.Get("api/journalEntries");
            this.AllowAnonymous();
        }

        public override async Task<List<JournalSearchResponse>> ExecuteAsync(JournalSearchRequest req, CancellationToken ct)
        {
            List<JournalSearchResponse> retVal = new List<JournalSearchResponse>();
            var journalSearchEntries = await this.JournalService.SearchEntries(req.SearchValue).ConfigureAwait(false);

            // Loop through journal search entries and create a list of journal serach response. 
            foreach (var journalSearchEntry in journalSearchEntries)
            {
                retVal.Add(new JournalSearchResponse
                {
                    Id = journalSearchEntry.Id,
                    Name = journalSearchEntry.Title,
                    CarbCount = journalSearchEntry.JournalEntryNutritionalInfo.Nutritionalinfo.Carbohydrates,
                });
             }

            return retVal;  
        }
    }
}
