using System.Collections.Generic;
using Crossways.Data.Domain;

namespace Crossways.Data.Identity
{
    public class Publisher : Profile
    {
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
        public ICollection<PublisherSubscriber> Subscribers { get; set; } = new List<PublisherSubscriber>();
    }
}