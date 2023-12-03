namespace WebApplication2.Models
{
    public class MembershipType
    {
        public Guid Id { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonth { get; set; }
        public int DiscountRate { get; set; }

        public ICollection<Customer>? Customers { get; set; }
    }
}
