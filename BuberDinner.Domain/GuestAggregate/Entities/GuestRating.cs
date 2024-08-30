using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

using ErrorOr;

namespace BuberDinner.Domain.GuestAggregate.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private GuestRating(DinnerId dinnerId, HostId hostId, Rating rating)
        : base(GuestRatingId.CreateUnique())
    {
        DinnerId = dinnerId;
        HostId = hostId;
        Rating = rating;
    }

    public static ErrorOr<GuestRating> Create(DinnerId dinnerId, HostId hostId, int rating)
    {
        var ratingValueObject = Rating.Create(rating);

        return new GuestRating(dinnerId, hostId, ratingValueObject);
    }
}