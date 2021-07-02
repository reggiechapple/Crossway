using Crossways.Data.Identity;

namespace Crossways.Data.Domain
{
    public class Donation : Entity
    {
        public decimal Amount { get; set; }

        public long PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public long DonorId { get; set; }
        public Member Donor { get; set; }
    }
}