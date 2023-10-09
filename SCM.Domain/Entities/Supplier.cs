using System.ComponentModel.DataAnnotations;

namespace SCM.Domain.Entities
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

    }
}
