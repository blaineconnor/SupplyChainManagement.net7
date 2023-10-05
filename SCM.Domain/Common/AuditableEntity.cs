namespace SCM.Domain.Common
{
    public class AuditableEntity : BaseEntity
    {
        public string By { get; set; }
        public DateTime DateTime { get; set; }
    }
}
