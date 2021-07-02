using Crossways.Data.Identity;

namespace Crossways.Data.Domain
{
    public class PublisherSubscriber
    {
        public long PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public long MemberId { get; set; }
        public Member Member { get; set; }
    }
}