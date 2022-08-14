using System;
using System.Collections.Generic;

namespace DataLayer.Data
{
    public partial class Journalentry
    {
        public int Id { get; set; }
        public DateTime Logged { get; set; }
        public string? Notes { get; set; }
        public string? Title { get; set; }
    }
}
