using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Movie>? Movies { get; set; }
        public Guid MembershiptypesId { get; set; }
        [ForeignKey(nameof(MembershipType))]

        public virtual MembershipType? Membershiptypes { get; set; }
    }
}
