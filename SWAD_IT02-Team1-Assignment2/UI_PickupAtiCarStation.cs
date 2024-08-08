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
           initPickupForm();
        }

        /// <summary>
        /// Displays pickup form.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        public void initPickupForm()
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
                    var (bookingDetails, validity) = ctlPickupAtiCarStation.getBookingDetails(id);

                    
                    if (validity) 
                    { 
                        displayBookingDetails(bookingDetails);
                        
                        Console.WriteLine("Booking found. Proceeding with car pickup.");
                        confirmPickup(bookingDetails);
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
        /// <param name="b">The booking to display.</param>
        public void displayBookingDetails(Booking b)
        {
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine($"             Booking {b.Id} Details");
            Console.WriteLine("===============================================");
            Console.WriteLine($"Booking ID:         {b.Id}");
            Console.WriteLine($"Car ID:             {b.Car.Id}");
            Console.WriteLine($"Start Date:         {b.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"End Date:           {b.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"Amount (SGD):       {b.Amount}");
            Console.WriteLine($"Pickup Location:    {b.PickupLocation.Address}");
            Console.WriteLine($"Return Location:    {b.ReturnLocation.Address}");
            Console.WriteLine($"Status:             {b.Status}");
            Console.WriteLine("===============================================\n");
        }

            /// <summary>
            /// Displays booking details.
            /// Creator: Ong Yee Hen
            /// Student ID: S10258759D
            /// </summary>
            /// <param name="b">The booking to confirm the pickup.</param>
            public void confirmPickup(Booking b)
        {
            Console.Write("Do you want to continue with the pickup process? (Yes/No): ");
            string response = Console.ReadLine();
            if (response.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                string pickupResult = ctlPickupAtiCarStation.processPickup(b);
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
