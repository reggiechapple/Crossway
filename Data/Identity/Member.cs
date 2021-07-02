using System.Collections.Generic;
using Crossways.Data.Domain;

namespace Crossways.Data.Identity
{
    public class Member : Profile
    {
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<MeetingAttendee> Meetings { get; set; } = new List<MeetingAttendee>();
        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
        public ICollection<PublisherSubscriber> Subscriptions { get; set; } = new List<PublisherSubscriber>();

    }
}