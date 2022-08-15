using System;
using System.Collections.Generic;

namespace DataLayer.Data
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }

        public virtual Userpassword? Userpassword { get; set; }
    }
}
