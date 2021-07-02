using System;
using System.Collections.Generic;
using Crossways.Data.Identity;

namespace Crossways.Data.Domain
{
    public class Meeting : Entity
    {
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsPrivate { get; set; }
        public long PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<MeetingAttendee> Attendees { get; set; } = new List<MeetingAttendee>();
    }
}