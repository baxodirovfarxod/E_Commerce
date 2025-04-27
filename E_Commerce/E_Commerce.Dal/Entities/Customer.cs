namespace E_Commerce.Dal.Entities;

public class Customer
{
    public long CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Cart Cart { get; set; }
    public List<Order> Orders { get; set; }
    public List<Card> Cards { get; set; }
}
