using System;
using System.Collections.Generic;

namespace DataLayer.Data
{
    public partial class Journalentrytag
    {
        public int Id { get; set; }
        public int JournalEntryId { get; set; }
        public int TagId { get; set; }
    }
}
