public class Rental
{
    public int RentalId { get; }
    public Car Car { get; }
    public Customer Customer { get; }
    public int Days { get; }
    public decimal TotalCost { get; private set; }
    public bool IsActive { get; private set; }

    public Rental(int rentalId, Car car, Customer customer, int days)
    {
        RentalId = rentalId;
        Car = car;
        Customer = customer;
        Days = days;
        TotalCost = 0m;
        IsActive = false;
    }

    public void RentCar()
    {
        if (Days <= 0)
        {
            Console.WriteLine("Rental duration must be greater than zero.");
            return;
        }

        if (!Car.IsAvailable)
        {
            Console.WriteLine("Sorry, this car is already rented.");
            return;
        }

        TotalCost = Car.DailyRate * Days;
        Car.IsAvailable = false;
        IsActive = true;

        Console.WriteLine("\n=== RENTAL CONFIRMATION ===");
        Console.WriteLine($"Customer: {Customer.Name}");
        Console.WriteLine($"Car: {Car.Brand} {Car.Model}");
        Console.WriteLine($"Duration: {Days} days");
        Console.WriteLine($"Total cost: {TotalCost:F2} PLN");
        Console.WriteLine("Rental successful!");
    }

    public void ReturnCar()
    {
        if (!IsActive)
        {
            Console.WriteLine("This rental is not active.");
            return;
        }

        Car.IsAvailable = true;
        IsActive = false;

        Console.WriteLine(
            $"\n{Car.Brand} {Car.Model} returned successfully."
        );
    }
}