using DataLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EfCore
{
    public class JournalService : IJournalService
    {
        public JournalService(sewright22_foodjournalContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public sewright22_foodjournalContext DbContext { get; }

        public Task<List<Journalentry>> SearchEntries(string searchValue)
        {
            return this.DbContext.Journalentries
                .Include(x=>x.JournalEntryNutritionalInfo)
                .ThenInclude(x=>x.Nutritionalinfo)
                .Where(x => x.Title.ToLower().Contains(searchValue.ToLower())).ToListAsync();
        }
    }
}
