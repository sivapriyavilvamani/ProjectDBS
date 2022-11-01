using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DBS_services.Models
{
    public class CRegistration
    {
        public int CustId { get; set; }
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "FirstName is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Test is Required")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "LastName is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Test is Required")]
        public string? LastName { get; set; }
        public int? Age { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string? Address { get; set; }
        [Display(Name = "Phone Number")]
        [RegularExpression("^[0-9]*$",ErrorMessage = "10 digits Required")]
        public long? Phone { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        // [RegularExpression(@"^(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8})$")]


        //[Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
        [Display(Name = "EmailId")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "EmailId is Required")]
        public string? EmailId { get; set; }
    }
}
