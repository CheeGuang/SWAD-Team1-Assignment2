using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    public class Renter : User
    {
        private string driverLicenseNumber;
        private decimal monthlyRentalFee;
        private decimal digitalWalletAmount;
        private bool isPrime;
        private bool isVerified;

        // Association with Booking
        private List<Booking> bookings;

        public Renter(int id, string name, string email, string phoneNumber, string dob, string driverLicenseNumber, decimal monthlyRentalFee, decimal digitalWalletAmount, bool isPrime, bool isVerified)
            : base(id, name, email, phoneNumber, dob)
        {
            this.driverLicenseNumber = driverLicenseNumber;
            this.monthlyRentalFee = monthlyRentalFee;
            this.digitalWalletAmount = digitalWalletAmount;
            this.isPrime = isPrime;
            this.isVerified = isVerified;
            this.bookings = new List<Booking>();
        }

        public string DriverLicenseNumber
        {
            get { return driverLicenseNumber; }
            set { driverLicenseNumber = value; }
        }
        public decimal MonthlyRentalFee
        {
            get { return monthlyRentalFee; }
            set { monthlyRentalFee = value; }
        }
        public decimal DigitalWalletAmount
        {
            get { return digitalWalletAmount; }
            set { digitalWalletAmount = value; }
        }
        public bool IsPrime
        {
            get { return isPrime; }
            set { isPrime = value; }
        }
        public bool IsVerified
        {
            get { return isVerified; }
            set { isVerified = value; }
        }
        public List<Booking> Bookings
        {
            get { return bookings; }
            set { bookings = value; }
        }

        // Add a booking to the Renter
        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
        }

        // View all bookings
        public void ViewBookings()
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found.");
                return;
            }

            Console.WriteLine("Your Bookings:");
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Booking ID: {booking.Id}");
                Console.WriteLine($"Car ID: {booking.Car.Id}");
                Console.WriteLine($"Start Date: {booking.RentStartDateTime}");
                Console.WriteLine($"End Date: {booking.RentEndDateTime}");
                Console.WriteLine($"Amount: {booking.Amount}");
                Console.WriteLine($"Pickup Location: {booking.PickupLocation.Address}");
                Console.WriteLine($"Return Location: {booking.ReturnLocation.Address}");
                Console.WriteLine();
            }
        }
    

        // Renter Menu
        public void RenterMenu()
        {
            while (true)
            {
                Console.WriteLine("\nRenter Menu:");
                Console.WriteLine("1. View Bookings");
                Console.WriteLine("2. Book Car");
                Console.WriteLine("3. Modify Booking");
                Console.WriteLine("0. Logout");
                Console.Write("\nPlease select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewBookings();
                        break;
                    case "2":
                        // Implement Book Car functionality here
                        Console.WriteLine("\n");
                        break;
                    case "3":
                        // Implement Modify Booking functionality here
                        Console.WriteLine("\n");
                        break;
                    case "0":
                        Console.WriteLine("Log out successful. You have been securely signed out.\n");
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        break;
                }
            }
        }
    }
}
