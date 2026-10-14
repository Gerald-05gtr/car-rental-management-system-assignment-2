public class Car
{
    public int CarId { get; }
    public string Brand { get; }
    public string Model { get; }
    public string CarType { get; }
    public decimal DailyRate { get; }
    public bool IsAvailable { get; set; } = true;

    public Car(int carId, string brand, string model,
               string carType, decimal dailyRate)
    {
        CarId = carId;
        Brand = brand;
        Model = model;
        CarType = carType;
        DailyRate = dailyRate;
    }

    public void DisplayDetails()
    {
        string status = IsAvailable ? "Available" : "Rented";

        Console.WriteLine($"{CarId}. {Brand} {Model}");
        Console.WriteLine($"   Type: {CarType}");
        Console.WriteLine($"   Daily rate: {DailyRate:F2} PLN");
        Console.WriteLine($"   Status: {status}");
    }
}