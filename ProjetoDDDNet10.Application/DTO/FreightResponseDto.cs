using ProjetoDDDNet10.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.DTO
{
    public class FreightResponse
    {
        public Guid Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string Origin { get; set; } = string.Empty;

        public string Destination { get; set; } = string.Empty;

        public decimal ChargedAmount { get; set; }

        public decimal CostAmount { get; set; }

        public decimal Profit { get; set; }

        public FreightStatus Status { get; set; }

        public DateTime FreightDate { get; set; }
    }
}
