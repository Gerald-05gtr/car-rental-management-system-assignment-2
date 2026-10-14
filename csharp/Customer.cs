public class Customer
{
    public int CustomerId { get; }
    public string Name { get; }
    public string Phone { get; }

    public Customer(int customerId, string name, string phone)
    {
        CustomerId = customerId;
        Name = name;
        Phone = phone;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Customer ID: {CustomerId}");
        Console.WriteLine($"Customer Name: {Name}");
        Console.WriteLine($"Phone Number: {Phone}");
    }
}