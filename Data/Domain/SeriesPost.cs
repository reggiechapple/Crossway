namespace Crossways.Data.Domain
{
    public class SeriesPost : Entity
    {
        public int PostOrder { get; set; }
        public long SeriesId { get; set; }
        public Series Series { get; set; }
        public long PostId { get; set; }
        public Post Post { get; set; }
    }
}