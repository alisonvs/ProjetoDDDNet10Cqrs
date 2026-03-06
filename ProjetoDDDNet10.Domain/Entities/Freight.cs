using ProjetoDDDNet10.Domain.Common;
using ProjetoDDDNet10.Domain.Enums;
using ProjetoDDDNet10.Domain.Events;
using ProjetoDDDNet10.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Domain.Entities
{
    public class Freight : BaseEntity
    {
           public Guid CustomerId { get; set; }

            public Customer Customer { get; set; } = null!;

            public string Origin { get; set; } = string.Empty;

            public string Destination { get; set; } = string.Empty;

            public decimal ChargedAmount { get; set; }

            public decimal CostAmount { get; set; }

            public VehicleType VehicleType { get; set; }

            public FreightStatus Status { get; set; }

            public DateTime FreightDate { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            // cálculo derivado
            public decimal Profit => ChargedAmount - CostAmount;       

            public Freight()
                {
                    // Empty constructor for EF or serialization
                }

                public Freight(
                    Guid id,
                    Guid customerId,
                    Customer customer,
                    string origin,
                    string destination,
                    decimal chargedAmount,
                    decimal costAmount,
                    VehicleType vehicleType,
                    FreightStatus status,
                    DateTime freightDate
                    )
                {
            SetId(id);
            SetCustomer(customerId, customer);
            SetOrigin(origin);
            SetDestination(destination);
            SetChargedAmount(chargedAmount);
            SetCostAmount(costAmount, chargedAmount);
            SetVehicleType(vehicleType);
            SetStatus(status);
            SetFreightDate(freightDate);

            AddDomainEvent(new FreightCreateEvent(Id));
        }
        private void SetId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty.");
            Id = id;
        }

        private void SetCustomer(Guid customerId, Customer customer)
        {
            if (customerId == Guid.Empty)
                throw new DomainException("CustomerId cannot be empty.");
            if (customer == null)
                throw new DomainException("Customer cannot be null.");
            CustomerId = customerId;
            Customer = customer;
        }

        private void SetOrigin(string origin)
        {
            if (string.IsNullOrWhiteSpace(origin))
                throw new DomainException("Origin is required.");
            Origin = origin;
        }

        private void SetDestination(string destination)
        {
            if (string.IsNullOrWhiteSpace(destination))
                throw new DomainException("Destination is required.");
            Destination = destination;
        }

        private void SetChargedAmount(decimal chargedAmount)
        {
            if (chargedAmount <= 0)
                throw new DomainException("Charged amount must be greater than zero.");
            ChargedAmount = chargedAmount;
        }

        private void SetCostAmount(decimal costAmount, decimal chargedAmount)
        {
            if (costAmount < 0)
                throw new DomainException("Cost amount cannot be negative.");
            if (costAmount > chargedAmount)
                throw new DomainException("Cost amount cannot exceed charged amount.");
            CostAmount = costAmount;
        }

        private void SetVehicleType(VehicleType vehicleType)
        {
            if (!Enum.IsDefined(typeof(VehicleType), vehicleType))
                throw new DomainException("Invalid vehicle type.");
            VehicleType = vehicleType;
        }

        private void SetStatus(FreightStatus status)
        {
            if (!Enum.IsDefined(typeof(FreightStatus), status))
                throw new DomainException("Invalid freight status.");
            Status = status;
        }

        private void SetFreightDate(DateTime freightDate)
        {
            if (freightDate < DateTime.Today)
                throw new DomainException("Freight date cannot be in the past.");
            FreightDate = freightDate;
        }
    }
        }
