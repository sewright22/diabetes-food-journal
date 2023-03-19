using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.External
{
    public class TandemUser
    {
        public string Id { get; set; } = string.Empty;
        public string PatientObjectId { get; set; } = string.Empty;
        public string PatientObjectType { get; set; } = string.Empty;
    }
}
