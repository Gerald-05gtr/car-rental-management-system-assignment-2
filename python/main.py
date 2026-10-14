class Car:
    def __init__(self, car_id, brand, model, car_type, daily_rate):
        self.car_id = car_id
        self.brand = brand
        self.model = model
        self.car_type = car_type
        self.daily_rate = daily_rate
        self.is_available = True

    def display_details(self):
        status = "Available" if self.is_available else "Rented"

        print(f"{self.car_id}. {self.brand} {self.model}")
        print(f"   Type: {self.car_type}")
        print(f"   Daily rate: {self.daily_rate:.2f} PLN")
        print(f"   Status: {status}")

class Customer:
    def __init__(self, customer_id, name, phone):
        self.customer_id = customer_id
        self.name = name
        self.phone = phone

    def display_details(self):
        print(f"Customer ID: {self.customer_id}")
        print(f"Customer Name: {self.name}")
        print(f"Phone Number: {self.phone}") 
class Rental:
    def __init__(self, rental_id, car, customer, days):
        self.rental_id = rental_id
        self.car = car
        self.customer = customer
        self.days = days
        self.total_cost = 0
        self.is_active = False

    def rent_car(self):
        if self.days <= 0:
            print("Rental duration must be greater than zero.")
            return

        if not self.car.is_available:
            print("Sorry, this car is already rented.")
            return

        self.total_cost = self.car.daily_rate * self.days
        self.car.is_available = False
        self.is_active = True

        print("\n=== RENTAL CONFIRMATION ===")
        print(f"Customer: {self.customer.name}")
        print(f"Car: {self.car.brand} {self.car.model}")
        print(f"Duration: {self.days} days")
        print(f"Total cost: {self.total_cost:.2f} PLN")
        print("Rental successful!")

    def return_car(self):
        if not self.is_active:
            print("This rental is not active.")
            return

        self.car.is_available = True
        self.is_active = False
        print(f"\n{self.car.brand} {self.car.model} returned successfully.") 
def main():
    cars = [
        Car(1, "Toyota", "Corolla", "Sedan", 150),
        Car(2, "Skoda", "Fabia", "Economy", 100),
        Car(3, "BMW", "320i", "Luxury", 250)
    ]

    customers = []
    rentals = []

    while True:
        print("\n=== CAR RENTAL MANAGEMENT SYSTEM ===")
        print("1. View all cars")
        print("2. Register customer")
        print("3. Rent a car")
        print("4. Return a car")
        print("5. View rental records") 
        print("6. View available cars only")
        print("0. Exit")

        choice = input("Choose an option: ").strip()

        if choice == "1":
            for car in cars:
                car.display_details()

        elif choice == "2":
            name = input("Enter customer name: ").strip()
            phone = input("Enter phone number: ").strip()

            if not name or not phone:
                print("Name and phone number are required.")
                continue

            customer_id = len(customers) + 101
            customer = Customer(customer_id, name, phone)
            customers.append(customer)

            print(f"Customer registered! ID: {customer_id}")

        elif choice == "3":
            if not customers:
                print("Please register a customer first.")
                continue

            try:
                customer_id = int(input("Customer ID: "))
                car_id = int(input("Car ID: "))
                days = int(input("Rental duration (days): "))
            except ValueError:
                print("Please enter valid whole numbers.")
                continue

            customer = next(
                (c for c in customers if c.customer_id == customer_id),
                None
            )

            car = next(
                (c for c in cars if c.car_id == car_id),
                None
            )

            if customer is None or car is None:
                print("Invalid customer ID or car ID.")
                continue

            rental = Rental(len(rentals) + 1, car, customer, days)
            rental.rent_car()

            if rental.is_active:
                rentals.append(rental)

        elif choice == "4":
            try:
                rental_id = int(input("Enter rental ID: "))
            except ValueError:
                print("Please enter a valid rental ID.")
                continue

            rental = next(
                (r for r in rentals if r.rental_id == rental_id),
                None
            )

            if rental is None:
                print("Rental not found.")
            else:
                rental.return_car()

        elif choice == "5":
            if not rentals:
                print("No rental records found.")
                continue

            for rental in rentals:
                status = "Active" if rental.is_active else "Returned"

                print(f"\nRental ID: {rental.rental_id}")
                print(f"Customer: {rental.customer.name}")
                print(f"Car: {rental.car.brand} {rental.car.model}")
                print(f"Days: {rental.days}")
                print(f"Total: {rental.total_cost:.2f} PLN")
                print(f"Status: {status}") 
                

        elif choice == "6":
            available_cars = [
                car for car in cars if car.is_available
            ]

            if not available_cars:
                print("No cars are currently available.")
            else:
                print("\n=== AVAILABLE CARS ===")
                for car in available_cars:
                    car.display_details()
            if not cars:
                print("No cars available.")
                continue

            print("\nAvailable Cars:")
            for car in cars:
                if car.is_available:
                    print(f"- {car.brand} {car.model} (${car.daily_rate:.2f}/day)")

        elif choice == "0":
            print("Thank you for using the Car Rental System!")
            break

        else:
            print("Invalid option. Please try again.")


if __name__ == "__main__":
    main()