using System.Numerics;

namespace SCM.Domain.Common
{
    public class BaseEntity
    {
        public BigInteger Id { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
