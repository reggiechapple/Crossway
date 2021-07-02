using Crossways.Data.Identity;

namespace Crossways.Data.Domain
{
    public class MeetingAttendee
    {
        public long MeetingId { get; set; }
        public Meeting Meeting { get; set; }
        public long AttendeeId { get; set; }
        public Member Attendee { get; set; }
    }
}