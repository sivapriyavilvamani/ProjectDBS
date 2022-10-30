using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DBS_services.Models
{
    public class EXRegistration
    {     
        
        public int ExecId { get; set; }
        [Display(Name = "Executive Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "ExecutivName is Required")]
        public string? ExecName { get; set; }
            public int? Age { get; set; }
            public string? Designation { get; set; }
            public string? Department { get; set; }
            public int? Experience { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "PhoneNumber is Required")]
        public long? Phone { get; set; }
        //[Display(Name = "Password")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
        [Display(Name = "EmailId")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "EmailId is Required")]
        public string? EmailId { get; set; }
        
    }
}
