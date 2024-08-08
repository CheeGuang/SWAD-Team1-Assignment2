using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Ong Yee Hen.
    /// Creator: Ong Yee Hen
    /// Student ID: S10258759D
    /// </summary>
    internal class UI_PickupAtiCarStation
    {
        private CTL_PickupAtiCarStation ctlPickupAtiCarStation;

        public UI_PickupAtiCarStation()
        {
            ctlPickupAtiCarStation = new CTL_PickupAtiCarStation();
        }

        /// <summary>
        /// Start the use case.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        public void startPickupAtiCarStation()
        {
           displayAllBooking();
           displayPickupForm();
        }

        /// <summary>
        /// Displays all bookings.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        public void displayAllBooking()
        {
            if (Program.Bookings.Count > 0)
            {
                foreach (var booking in Program.Bookings)
                {
                    Console.WriteLine("\n\n===============================================");
                    Console.WriteLine($"             Booking {booking.Id} Details");
                    Console.WriteLine("===============================================");
                    Console.WriteLine($"Booking ID:         {booking.Id}");
                    Console.WriteLine($"Car ID:             {booking.Car.Id}");
                    Console.WriteLine($"Start Date:         {booking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
                    Console.WriteLine($"End Date:           {booking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
                    Console.WriteLine($"Amount (SGD):       {booking.Amount}");
                    Console.WriteLine($"Pickup Location:    {booking.PickupLocation.Address}");
                    Console.WriteLine($"Return Location:    {booking.ReturnLocation.Address}");
                    Console.WriteLine($"Status:             {booking.Status}");
                    Console.WriteLine($"Pickup Timeslot:    {booking.PickupTimeslots.First().StartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
                    Console.WriteLine("===============================================\n");
                }
            }
            else
            {
                Console.WriteLine("No bookings found.");
            }
        }

        /// <summary>
        /// Displays pickup form.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        public void displayPickupForm()
        {
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine("                  Pickup Car");
            Console.WriteLine("===============================================");
            Console.Write("Please enter your Booking ID:");
            inputBookingID();
        }

        /// <summary>
        /// Get booking ID to get booking details.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        private void inputBookingID()
        {
            int attempts = 0;
            const int maxAttempts = 3;

            while (attempts < maxAttempts)
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var (booking, validity) = ctlPickupAtiCarStation.getBookingDetails(id);

                    
                    if (validity) 
                    { 
                        displayBookingDetails(booking);
                        
                        Console.WriteLine("Booking found. Proceeding with car pickup.");
                        confirmPickup(booking);
                        return;
                    }
                    else
                    {
                        attempts++;
                        if (attempts < maxAttempts)
                        {
                            Console.Write("Please enter your Booking ID:");
                        }
                    }
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Invalid Booking ID. Please enter a valid integer.");
                    if (attempts < maxAttempts)
                    {
                        Console.Write("Please enter your Booking ID:");
                    }
                }
            }
            Console.WriteLine("Maximum attempts reached. Try again later.");
        }

        /// <summary>
        /// Displays booking details.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="booking">The booking to display.</param>
        public void displayBookingDetails(Booking booking)
        {
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine($"             Booking {booking.Id} Details");
            Console.WriteLine("===============================================");
            Console.WriteLine($"Booking ID:         {booking.Id}");
            Console.WriteLine($"Car ID:             {booking.Car.Id}");
            Console.WriteLine($"Start Date:         {booking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"End Date:           {booking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"Amount (SGD):       {booking.Amount}");
            Console.WriteLine($"Pickup Location:    {booking.PickupLocation.Address}");
            Console.WriteLine($"Return Location:    {booking.ReturnLocation.Address}");
            Console.WriteLine($"Status:             {booking.Status}");
            Console.WriteLine($"Pickup Timeslot:    {booking.PickupTimeslots.First().StartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine("===============================================\n");
        }

        /// <summary>
        /// Displays booking details.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        /// <param name="booking">The booking to confirm the pickup.</param>
        public void confirmPickup(Booking booking)
        {
            Console.Write("Do you want to continue with the pickup process? (Yes/No): ");
            string response = Console.ReadLine();
            if (response.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                string pickupResult = ctlPickupAtiCarStation.processPickup(booking);
                displayPickupResult(pickupResult);
                
            }
            else
            {
                Console.WriteLine("Pickup process cancelled.");
            }
            
        }

        /// <summary>
        /// Displays pickup result.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        /// <param name="pickupResult">The pickup result to display.</param>
        public void displayPickupResult(string pickupResult)
        {
            if (pickupResult == "success")
            {
                Console.WriteLine("Car pickup successful.");
            }
            else 
            {
                Console.WriteLine("Car pickup failed. Please come back later at your pickup timeslot.");
            }
            
        }
    }
}
