using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crossways.Data.Domain
{
    public class Topic : Entity
    {
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        public ICollection<Discussion> Discussions { get; set; } = new List<Discussion>();
    }
}