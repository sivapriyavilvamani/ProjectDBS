using System;
using System.Collections.Generic;

namespace Api_DBS.Models
{
    public partial class Pricechart
    {
        public int PriceId { get; set; }
        public string? WeightInKg { get; set; }
        public double? PriceKg { get; set; }
        public string? DistanceInKm { get; set; }
        public double? PriceKm { get; set; }
    }
}
