using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Services;
using WebApi.Extensions;

namespace WebApi.Features.JournalSearch
{
    public class JournalSearchEndpoint : Endpoint<JournalSearchRequest, List<JournalSearchResponse>>
    {
        public JournalSearchEndpoint(sewright22_foodjournalContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }

        public sewright22_foodjournalContext DbContext { get; }
        public IMapper Mapper { get; }

        public override void Configure()
        {
            this.Get("api/journalEntries");
            this.AllowAnonymous();
        }

        public override async Task<List<JournalSearchResponse>> ExecuteAsync(JournalSearchRequest req, CancellationToken ct)
        {
            if (req.SearchValue == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            var journalSearchEntries = this.DbContext.Journalentries
                .SearchTitleAndTag(req.SearchValue)
                .ProjectTo<JournalSearchResponse>(this.Mapper.ConfigurationProvider);

            return journalSearchEntries.ToList();
        }
    }
}
