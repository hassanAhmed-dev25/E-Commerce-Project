namespace ECommerceProject.Domain.Entities
{
    public class ShippingAddress
    {
        public int Id { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }



        // Foreign Keys
        public int OrderId { get; set; }



        // Navigation Properties
        public Order? Order { get; set; }
    }
}
