﻿using System;
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
        /// Displays booking details.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="aBooking">The booking to display.</param>
        public void DisplayBookingDetails(Booking aBooking)
        {
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine($"             Booking {aBooking.Id} Details");
            Console.WriteLine("===============================================");
            Console.WriteLine($"Booking ID:         {aBooking.Id}");
            Console.WriteLine($"Car ID:             {aBooking.Car.Id}");
            Console.WriteLine($"Start Date:         {aBooking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"End Date:           {aBooking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"Amount:             {aBooking.Amount}");
            Console.WriteLine($"Pickup Location:    {aBooking.PickupLocation.Address}");
            Console.WriteLine($"Return Location:    {aBooking.ReturnLocation.Address}");
            Console.WriteLine("===============================================\n");
        }

        /// <summary>
        /// Displays a success message after booking is updated.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="aBooking">The booking that was updated.</param>
        public void DisplaySuccessMessage(Booking aBooking)
        {
            Console.WriteLine("\n===============================================");
            Console.WriteLine("         Booking Updated Successfully!");
            Console.WriteLine("===============================================");
            DisplayBookingDetails(aBooking);
        }

        /// <summary>
        /// Displays the list of pickup and return locations.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void DisplayLocations(List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
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
        /// Requests updated booking details from the user.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        /// <returns>Dictionary of updated booking details.</returns>
        public Dictionary<string, string> RequestUpdatedBookingDetails(List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            Dictionary<string, string> updatedDetails = new Dictionary<string, string>();

            Console.WriteLine("\n===============================================");
            Console.WriteLine("           Enter Updated Booking Details");
            Console.WriteLine("===============================================");
            Console.Write("New Start Date and Time (dd/MM/yyyy h:mm:ss tt): ");
            updatedDetails["newStartDateTime"] = Console.ReadLine();

            Console.Write("New End Date and Time (dd/MM/yyyy h:mm:ss tt): ");
            updatedDetails["newEndDateTime"] = Console.ReadLine();

            DisplayLocations(pickupLocations, returnLocations);

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
        public Dictionary<string, string> EnterUpdatedBookingDetails(Booking aBooking, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            DisplayBookingDetails(aBooking);
            return RequestUpdatedBookingDetails(pickupLocations, returnLocations);
        }

        /// <summary>
        /// Modifies a booking for the renter.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="renter">The renter object.</param>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void ModifyBooking(Renter renter, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            if (renter.Bookings.Count > 0)
            {
                Console.WriteLine("\n===============================================");
                Console.WriteLine("                All Bookings");
                Console.WriteLine("===============================================");
                foreach (var booking in renter.Bookings)
                {
                    DisplayBookingDetails(booking);
                }

                Console.Write("Enter the Booking ID you want to modify: ");
                int bookingId;
                if (int.TryParse(Console.ReadLine(), out bookingId))
                {
                    Booking selectedBooking = renter.Bookings.Find(b => b.Id == bookingId);
                    if (selectedBooking != null)
                    {
                        bool isSuccessful = false;
                        while (!isSuccessful)
                        {
                            var updatedDetails = EnterUpdatedBookingDetails(selectedBooking, pickupLocations, returnLocations);
                            isSuccessful = ctlModifyBooking.EnterUpdated(updatedDetails, pickupLocations, returnLocations, selectedBooking);
                            if (!isSuccessful)
                            {
                                Console.WriteLine("Failed to update booking. Please try again.");
                            }
                            else
                            {
                                DisplaySuccessMessage(selectedBooking);
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
                    Console.WriteLine("Invalid Booking ID format.");
                }
            }
            else
            {
                Console.WriteLine("No bookings found.");
            }
        }
    }
}
