using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class UI_ModifyBooking
    {
        private CTL_ModifyBooking ctlModifyBooking;

        public UI_ModifyBooking()
        {
            ctlModifyBooking = new CTL_ModifyBooking();
        }

        /// <summary>
        /// Requests updated booking details from the user.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        /// <returns>Dictionary of updated booking details.</returns>
        public Dictionary<string, string> requestUpdatedBookingDetails(Booking aBooking, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            Dictionary<string, string> updatedDetails = new Dictionary<string, string>();

            // Display availability schedule for the selected car
            displayAvailabilitySchedule(aBooking.Car.NumberPlate, aBooking.Car.AvailabilitySchedules);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n===============================================");
            Console.WriteLine("           Enter Updated Booking Details");
            Console.WriteLine("===============================================");
            Console.ResetColor();

            Console.Write("New Start Date and Time (dd/MM/yyyy h:mm:ss tt): ");
            updatedDetails["newStartDateTime"] = Console.ReadLine();

            Console.Write("New End Date and Time (dd/MM/yyyy h:mm:ss tt): ");
            updatedDetails["newEndDateTime"] = Console.ReadLine();

            displayLocations(pickupLocations, returnLocations);

            Console.Write("New Pickup Location ID: ");
            updatedDetails["newPickupLocationId"] = Console.ReadLine();

            Console.Write("New Return Location ID: ");
            updatedDetails["newReturnLocationId"] = Console.ReadLine();

            Console.WriteLine("===============================================\n");

            return updatedDetails;
        }

        /// <summary>
        /// Prompts the user to enter updated booking details.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="aBooking">The booking to update.</param>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        /// <returns>Dictionary of updated booking details.</returns>
        public Dictionary<string, string> enterUpdatedBookingDetails(Booking aBooking, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            displayBookingDetails(aBooking);
            return requestUpdatedBookingDetails(aBooking, pickupLocations, returnLocations);
        }

        /// <summary>
        /// Modifies a booking for the renter.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="renter">The renter object.</param>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void initialiseModifyBooking(Renter renter, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            if (renter.Bookings.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n===============================================");
                Console.WriteLine("                All Bookings");
                Console.WriteLine("===============================================");
                Console.ResetColor();
                foreach (var booking in renter.Bookings)
                {
                    displayBookingDetails(booking);
                }

                int bookingId = selectBooking();
                Booking aBooking = renter.Bookings.Find(b => b.Id == bookingId);
                if (aBooking != null)
                {
                    bool isSuccessful = false;
                    while (!isSuccessful)
                    {
                        var updatedDetails = enterUpdatedBookingDetails(aBooking, pickupLocations, returnLocations);
                        isSuccessful = ctlModifyBooking.enterUpdated(updatedDetails, pickupLocations, returnLocations, aBooking);
                        if (!isSuccessful)
                        {
                            Console.WriteLine("Failed to update booking. Please try again.");
                        }
                        else
                        {
                            displaySuccessMessage(aBooking);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Booking ID not found.");
                }
            }
            else
            {
                Console.WriteLine("No bookings found.");
            }
        }

        /// <summary>
        /// Prompts the user to enter the Booking ID they want to modify.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <returns>The Booking ID entered by the user.</returns>
        private int selectBooking()
        {
            Console.Write("Enter the Booking ID you want to modify: ");
            int bookingId;
            while (!int.TryParse(Console.ReadLine(), out bookingId))
            {
                Console.Write("Invalid Booking ID format. Please enter a numeric value: ");
            }
            return bookingId;
        }

        /// <summary>
        /// Displays booking details.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="aBooking">The booking to display.</param>
        public void displayBookingDetails(Booking aBooking)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine($"             Booking {aBooking.Id} Details");
            Console.WriteLine("===============================================");
            Console.ResetColor();
            Console.WriteLine($"Booking ID:         {aBooking.Id}");
            Console.WriteLine($"Car ID:             {aBooking.Car.Id}");
            Console.WriteLine($"Start Date:         {aBooking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"End Date:           {aBooking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"Amount (SGD):       {aBooking.Amount}");
            Console.WriteLine($"Pickup Location:    {aBooking.PickupLocation.Address}");
            Console.WriteLine($"Return Location:    {aBooking.ReturnLocation.Address}");
            Console.WriteLine($"Status:             {aBooking.Status}");
            Console.WriteLine("===============================================\n");
        }

        /// <summary>
        /// Displays a success message after booking is updated.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="aBooking">The booking that was updated.</param>
        public void displaySuccessMessage(Booking aBooking)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n===============================================");
            Console.WriteLine("         Booking Updated Successfully!");
            Console.WriteLine("===============================================");
            Console.ResetColor();
            displayBookingDetails(aBooking);
        }

        /// <summary>
        /// Displays the availability schedule for a car.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="numberPlate">The number plate of the car.</param>
        /// <param name="availabilitySchedules">List of availability schedules.</param>
        public void displayAvailabilitySchedule(string numberPlate, List<AvailabilitySchedule> availabilitySchedules)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n===============================================");
            Console.WriteLine("            Availability Schedules");
            Console.WriteLine("===============================================\n");
            Console.ResetColor();

            foreach (AvailabilitySchedule availability in availabilitySchedules)
            {
                Console.WriteLine($"ID: {availability.Id} - Slot: {availability.StartDate.ToString("dd/MM/yyyy h:mm:ss tt")} to {availability.EndDate.ToString("dd/MM/yyyy h:mm:ss tt")}");
            }

            Console.WriteLine("===============================================\n");
        }

        /// <summary>
        /// Displays the list of pickup and return locations.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void displayLocations(List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n===============================================");
            Console.WriteLine("                Pickup Locations");
            Console.WriteLine("===============================================");
            Console.ResetColor();
            foreach (var location in pickupLocations)
            {
                Console.WriteLine($"ID: {location.Id} - Address: {location.Address}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n===============================================");
            Console.WriteLine("                Return Locations");
            Console.WriteLine("===============================================");
            Console.ResetColor();
            foreach (var location in returnLocations)
            {
                Console.WriteLine($"ID: {location.Id} - Address: {location.Address}");
            }
            Console.WriteLine("===============================================\n");
        }
    }
}
