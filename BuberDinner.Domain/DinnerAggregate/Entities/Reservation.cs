using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public DinnerId DinnerId { get; }
    public int GuestCount { get; }
    public GuestId GuestId { get; }
    public BillId? BillId { get; }
    public ReservationStatus Status { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(
        DinnerId dinnerId,
        GuestId guestId,
        int guestCount,
        DateTime? arrivalDateTime,
        BillId? billId,
        ReservationStatus status)
        : base(ReservationId.CreateUnique())
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        GuestCount = guestCount;
        ArrivalDateTime = arrivalDateTime;
        BillId = billId;
        Status = status;
    }

    public static Reservation Create(
        DinnerId dinnerId,
        GuestId guestId,
        int guestCount,
        ReservationStatus status,
        BillId? billId = null,
        DateTime? arrivalDateTime = null)
    {
        // TODO: Enforce invariants
        return new Reservation(
            dinnerId,
            guestId,
            guestCount,
            arrivalDateTime,
            billId,
            status);
    }
}