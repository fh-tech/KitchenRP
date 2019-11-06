using System;

namespace KitchenRP.Domain.Models
{
    public class DomainReservationStatus
    {
        public string Status { get; }
        public string DisplayName { get; }

        private DomainReservationStatus(string status, string displayName)
        {
            Status = status;
            DisplayName = displayName;
        }
        
        public static DomainReservationStatus Pending 
            => new DomainReservationStatus("PENDING", "Reservation pending ...");
        
        public static DomainReservationStatus NeedsApproval 
            => new DomainReservationStatus("NEEDS_APPROVAL", "Reservation needs approval ...");

        public static DomainReservationStatus Denied 
            => new DomainReservationStatus("DENIED", "Reservation was denied!");
        
        public static DomainReservationStatus Approved 
            => new DomainReservationStatus("APPROVED", "Reservation was approved!");

    }
}