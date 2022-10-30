using System;
using System.Collections.Generic;

namespace Api_DBS.Models
{
    public partial class Eregistration
    {
        public int ExecId { get; set; }
        public string? ExecName { get; set; }
        public int? Age { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public int? Experience { get; set; }
        public long? Phone { get; set; }
        public string? Password { get; set; }
        public string? EmailId { get; set; }
    }
}
