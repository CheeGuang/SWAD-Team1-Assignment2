using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Raeanne.
    /// Creator: Zou Ruining, Raeanne
    /// Student ID: S10258772G
    /// </summary>
    public class UI_BookCar
    {
        private Dictionary<string, string> bookingDetails = new Dictionary<string, string>();

        /// <summary>
        /// Display all Availability Schedule of selected car
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="numberPlate">Selected car liscense plate</param>
        /// <param name="availabilitySchedules">All availability schedules of selected car</param>
        public void displayAvailabilitySchedule(string numberPlate, List<AvailabilitySchedule> availabilitySchedules)
        { 
            Console.WriteLine("Selected Car License Plate: " + numberPlate);
        
            Console.WriteLine("\n===============================================");
            Console.WriteLine("            Availability Schedules");
            Console.WriteLine("===============================================\n");

            foreach (AvailabilitySchedule availability in availabilitySchedules)
            {
                Console.WriteLine($"ID: {availability.Id} - Slot: {availability.StartDate.ToString("dd/MM/yyyy h:mm:ss tt")} to {availability.EndDate.ToString("dd/MM/yyyy h:mm:ss tt")}");
            }

            Console.WriteLine("===============================================\n");

        }

        /// <summary>
        /// Get user to select availability slot
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        public int promptSelectedAvailabilitySlot()
        {
            Console.Write("Please enter availability slot ID: ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Get user to input booking dates
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        public Dictionary<string, string> promptBookingDates()
        {
            Console.Write("\nBooking Start Date and Time (dd/MM/yyyy h:mm:ss tt): ");
            bookingDetails["startDateTime"] = Console.ReadLine();
            Console.Write("Booking End Date and Time (dd/MM/yyyy h:mm:ss tt): ");
            bookingDetails["endDateTime"] = Console.ReadLine();

            return bookingDetails;

        }


        /// <summary>
        /// Displays the list of pickup and return locations.
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void displayLocations(List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            Console.WriteLine("\n===============================================");
            Console.WriteLine("                Pickup Locations");
            Console.WriteLine("===============================================");
            foreach (var location in pickupLocations)
            {
                Console.WriteLine($"ID: {location.Id} - Address: {location.Address}");
            }

            Console.WriteLine("\n===============================================");
            Console.WriteLine("                Return Locations");
            Console.WriteLine("===============================================");
            foreach (var location in returnLocations)
            {
                Console.WriteLine($"ID: {location.Id} - Address: {location.Address}");
            }
            Console.WriteLine("===============================================\n");
        }

        /// <summary>
        /// Get user to input pickup and return locations
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        public Dictionary<string, string> promptSelectedLocations()
        {
            Console.Write("\nEnter Pickup Location ID: ");
            bookingDetails["pickupLocation"] = Console.ReadLine();
            Console.Write("Enter Return Location ID: ");
            bookingDetails["returnLocation"] = Console.ReadLine();

            return bookingDetails;

        }
        
        /// <summary>
        /// Get user to confirm payment
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="totalCost">Booking total cost</param>
        public bool promptPaymentConfirmation(decimal totalCost)
        {
            bool response = false;
            bool commitPayment = false;

            Console.WriteLine($"\nThe rental rate is $5 per hour. The total amount needed to pay is: ${totalCost}.");

            do
            {
                Console.Write("Do you want to proceed with the payment? (Enter 'y' to confirm, 'n' to cancel): ");
                string userConfirmation = Console.ReadLine();

                if (userConfirmation.ToLower() == "y")
                {
                    response = true;
                    commitPayment = true;
                } else if (userConfirmation.ToLower() == "n")
                {
                    response = true;
                    commitPayment = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            } while (!response);

            return commitPayment;
        }

        /// <summary>
        /// Print the booking details after booking is confirmed
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="booking">Booking made</param>
        public void printBookingSummary(Booking booking)
        {
            Console.WriteLine("\n****** Booking Summary ********");
            Console.WriteLine("  ID: " + booking.Id);
            Console.WriteLine("  Car: " + booking.Car.Make + " " + booking.Car.Model);
            Console.WriteLine("  License Plate: " + booking.Car.NumberPlate);
            Console.WriteLine("  Start Date: " + booking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt"));
            Console.WriteLine("  Pickup Location: " + booking.PickupLocation.Address);
            Console.WriteLine("\n  End Date: " + booking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt"));
            Console.WriteLine("  Return Location: " + booking.ReturnLocation.Address);
            Console.WriteLine("  Payment [$"+booking.Amount+"]: " + booking.Payment.DateTime.ToString("dd/MM/yyyy h:mm:ss tt"));
            Console.WriteLine("*********************************\n");
        }

    }
}
