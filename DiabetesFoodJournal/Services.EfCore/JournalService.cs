using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EfCore
{
    public class JournalService : IJournalService
    {
        public Task<ICollection<Journalentry>> SearchEntries(string searchValue)
        {
            throw new NotImplementedException();
        }
    }
}
