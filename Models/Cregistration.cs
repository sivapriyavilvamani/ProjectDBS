using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DBS_services.Models
{
    public class CRegistration
    {
        public int CustId { get; set; }
        [Display(Name = "FirstName")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "FirstName is Required")]
        public string? FirstName { get; set; }
        [Display(Name = "LastName")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "LastName is Required")]
        public string? LastName { get; set; }
        public int? Age { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string? Address { get; set; }
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
