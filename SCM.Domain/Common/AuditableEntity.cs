namespace SCM.Domain.Common
{
    public class AuditableEntity : BaseEntity
    {
        public string RequestedBy { get; set; }
        public string BoughtBy { get; set;}
        public DateTime RequestTime { get; set; }
        public DateTime BoughtTime { get; set;}
    }
}
