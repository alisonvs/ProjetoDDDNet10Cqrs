using ProjetoDDDNet10.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.DTO
{
    public class CreateFreightRequest
    {
        public Guid CustomerId { get; set; }

        public string Origin { get; set; } = string.Empty;

        public string Destination { get; set; } = string.Empty;

        public decimal ChargedAmount { get; set; }

        public decimal CostAmount { get; set; }

        public VehicleType VehicleType { get; set; }

        public DateTime FreightDate { get; set; }
    }
}
