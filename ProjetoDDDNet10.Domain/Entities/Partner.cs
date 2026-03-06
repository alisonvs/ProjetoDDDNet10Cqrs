using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Domain.Entities
{
    
        public class Partner
        {
            public Guid Id { get; set; }

            public string Name { get; set; } = string.Empty;

            public string? Phone { get; set; }

            public decimal? AveragePricePerKm { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        }
    }

