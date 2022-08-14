namespace WebApi.Features.JournalSearch
{
    public class JournalSearchEndpoint : Endpoint<JournalSearchRequest, List<JournalSearchResponse>>
    {
        public override void Configure()
        {
            this.Get("api/journalEntries");
            this.AllowAnonymous();
        }

        public override Task HandleAsync(JournalSearchRequest req, CancellationToken ct)
        {
            return this.SendAsync(new List<JournalSearchResponse>
            {
                new JournalSearchResponse
                {
                    Id = 1,
                    Name = "Test",
                    CarbCount = 10,
                },
                new JournalSearchResponse
                {
                    Id = 2,
                    Name = "Test 2",
                    CarbCount = 20,
                },
            });
        }
    }
}
