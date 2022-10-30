namespace DBS_services.Models
{
    public class CancelHistory
    {
        public int OrderId { get; set; }
        public int? CustId { get; set; }
        public int? ExecId { get; set; }
        public string? Source { get; set; }
        public string? Destination { get; set; }
        public DateTime? DelivaryDate { get; set; }
        public DateTime? PicKupTime { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public int? PriceId { get; set; }
    }
}
