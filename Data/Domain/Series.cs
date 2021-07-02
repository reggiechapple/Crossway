using System.Collections.Generic;
using Crossways.Data.Identity;

namespace Crossways.Data.Domain
{
    public class Series : Entity
    {
        public string Title { get; set; }

        public long CategoryId { get; set; }

        public Category Category { get; set; }

        public long PublisherId { get; set; }
        
        public Publisher Publisher { get; set; }

        public ICollection<SeriesPost> Posts { get; set; } = new List<SeriesPost>();
    }
}