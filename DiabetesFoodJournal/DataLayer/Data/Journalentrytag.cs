﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DataLayer.Data
{
    public partial class Journalentrytag
    {
        public int Id { get; set; }
        public int JournalEntryId { get; set; }
        public int TagId { get; set; }

        // TODO: Add Navigation property to JournalEntry.

        // TODO: Add Navigation property to Tag.
    }
}
