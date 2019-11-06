using System;
using System.Diagnostics;
using System.Threading.Tasks;
using KitchenRP.DataAccess.Models;

namespace KitchenRP.Domain.Models
{
    public static class Mapper
    {

        public static DomainUser Map(User u)
            => new DomainUser(u.Id, u.Sub, u.Role.RoleName, u.Email, u.AllowNotifications);
        
        public static DomainRefreshToken Map(RefreshToken r)
            => new DomainRefreshToken(r.Key, r.Sub, r.Expires);

        public static DomainReservationStatus Map(ReservationStatus s)
        {
            if(s.Status == DomainReservationStatus.Denied.Status) return DomainReservationStatus.Denied;
            if(s.Status == DomainReservationStatus.Pending.Status) return DomainReservationStatus.Pending;
            if(s.Status == DomainReservationStatus.NeedsApproval.Status) return DomainReservationStatus.NeedsApproval;
            if(s.Status == DomainReservationStatus.Approved.Status) return DomainReservationStatus.Approved;
            throw new NotSupportedException($"Unknown reservation status: {s.Status}");
        }
        
        public static DomainStatusChange Map(StatusChange s)
            => new DomainStatusChange(
                Map(s.PreviousStatus),
                Map(s.CurrentStatus),
                s.Reason,
                s.ChangedAt,
                Map(s.ChangedBy)
                );
        
        public static DomainResourceType Map(ResourceType t)
            => new DomainResourceType(t.Type, t.DisplayName);
        
        
        public static DomainResource Map(Resource r)
            => new DomainResource(
                r.Id, 
                r.DisplayName, 
                r.MetaData, 
                r.Description, 
                Map(r.ResourceType));
        
        public static DomainReservation Map(Reservation r)
            => new DomainReservation(
                r.Id, 
                r.StartTime, 
                r.EndTime, 
                Map(r.Owner), 
                Map(r.ReservedResource), 
                r.AllowNotifications);
        
    }
}