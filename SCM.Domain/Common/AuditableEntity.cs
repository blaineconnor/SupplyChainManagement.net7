namespace SCM.Domain.Common
{
    public class AuditableEntity : BaseEntity
    {
        public string By { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
