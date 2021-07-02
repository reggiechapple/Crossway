using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Crossways.Data.Identity;

namespace Crossways.Data.Domain
{
    public class Post : Entity
    {
        public string Title { get; set; }
        
        [DataType(DataType.Text)]
        public string Content { get; set; }

        public long PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<PostCategory> Categories { get; set; } = new List<PostCategory>();

        public ICollection<SeriesPost> Series { get; set; } = new List<SeriesPost>();
    }
}