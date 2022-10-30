using System;
using System.Collections.Generic;

namespace Api_DBS.Models
{
    public partial class Cregistration
    {
        public int CustId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public long? Phone { get; set; }
        public string? Password { get; set; }
        public string? EmailId { get; set; }
    }
}
