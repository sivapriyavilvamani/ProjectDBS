using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DBS_services.Models
{
    public class Booking
    {
       
        public int OrderId { get; set; }
        public int? CustId { get; set; }
        public int? ExecId { get; set; }
        [Display(Name = "Zone")]
        [Required(ErrorMessage = "Zone is Required")]
        public string Zone { get; set; }
        [Display(Name = "Source")]
        [Required(ErrorMessage = "Source is Required")]
        public string? Source { get; set; }

        [Display(Name = "Destination")]
        [Required(ErrorMessage = "Destination is Required")]
        public string? Destination { get; set; }
        [Display(Name = "Delivery Date")]
        [Required(ErrorMessage = "DeliveryDate cannot be empty")]
        [DataType(DataType.DateTime)]
         
        public DateTime? DelivaryDate { get; set; }
        [Required(ErrorMessage = "PickUpTime cannot be empty")]
        public DateTime? PicKupTime { get; set; }
        [Required(ErrorMessage = "Weight is Required")]
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public int? PriceId { get; set; }
       
    }
}
