using System;
using System.Collections.Generic;
using System.Linq;

List<Car> cars = new List<Car>
{
    new Car(1, "Toyota", "Corolla", "Sedan", 150m),
    new Car(2, "Skoda", "Fabia", "Economy", 100m),
    new Car(3, "BMW", "320i", "Luxury", 250m)
};

List<Customer> customers = new List<Customer>();
List<Rental> rentals = new List<Rental>();

while (true)
{
    Console.WriteLine("\n=== CAR RENTAL MANAGEMENT SYSTEM ===");
    Console.WriteLine("1. View all cars");
    Console.WriteLine("2. Register customer");
    Console.WriteLine("3. Rent a car");
    Console.WriteLine("4. Return a car");
    Console.WriteLine("5. View rental records");
    Console.WriteLine("6. View available cars only");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine()?.Trim() ?? "";

    switch (choice)
    {
        case "1":
            foreach (Car car in cars)
            {
                car.DisplayDetails();
            }
            break;

        case "2":
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(phone))
            {
                Console.WriteLine("Name and phone are required.");
                break;
            }

            int customerId = customers.Count + 101;
            Customer customer = new Customer(customerId, name, phone);
            customers.Add(customer);

            Console.WriteLine($"Customer registered! ID: {customerId}");
            break;

        case "3":
            if (customers.Count == 0)
            {
                Console.WriteLine("Please register a customer first.");
                break;
            }

            Console.Write("Customer ID: ");
            bool validCustomer = int.TryParse(
                Console.ReadLine(), out int selectedCustomerId);

            Console.Write("Car ID: ");
            bool validCar = int.TryParse(
                Console.ReadLine(), out int selectedCarId);

            Console.Write("Rental duration (days): ");
            bool validDays = int.TryParse(
                Console.ReadLine(), out int days);

            if (!validCustomer || !validCar || !validDays)
            {
                Console.WriteLine("Please enter valid whole numbers.");
                break;
            }

            Customer? selectedCustomer = customers.FirstOrDefault(
                c => c.CustomerId == selectedCustomerId);

            Car? selectedCar = cars.FirstOrDefault(
                c => c.CarId == selectedCarId);

            if (selectedCustomer == null || selectedCar == null)
            {
                Console.WriteLine("Invalid customer ID or car ID.");
                break;
            }

            Rental rental = new Rental(
                rentals.Count + 1, selectedCar, selectedCustomer, days);

            rental.RentCar();

            if (rental.IsActive)
            {
                rentals.Add(rental);
            }
            break;

        case "4":
            Console.Write("Enter rental ID: ");

            if (!int.TryParse(Console.ReadLine(), out int rentalId))
            {
                Console.WriteLine("Please enter a valid rental ID.");
                break;
            }

            Rental? selectedRental = rentals.FirstOrDefault(
                r => r.RentalId == rentalId);

            if (selectedRental == null)
            {
                Console.WriteLine("Rental not found.");
            }
            else
            {
                selectedRental.ReturnCar();
            }
            break;

        case "5":
            if (rentals.Count == 0)
            {
                Console.WriteLine("No rental records found.");
                break;
            }

            foreach (Rental record in rentals)
            {
                string status = record.IsActive ? "Active" : "Returned";

                Console.WriteLine($"\nRental ID: {record.RentalId}");
                Console.WriteLine($"Customer: {record.Customer.Name}");
                Console.WriteLine(
                    $"Car: {record.Car.Brand} {record.Car.Model}");
                Console.WriteLine($"Days: {record.Days}");
                Console.WriteLine($"Total: {record.TotalCost:F2} PLN");
                Console.WriteLine($"Status: {status}");
            }
            break;

        case "0":
            Console.WriteLine("Thank you for using the Car Rental System!");
            return;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}