using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    public class UI_ModifyBooking
    {
        public void DisplayBookingDetails(Booking aBooking)
        {
            Console.WriteLine("\n\nBooking Details:");
            Console.WriteLine($"Booking ID: {aBooking.Id}");
            Console.WriteLine($"Car ID: {aBooking.Car.Id}");
            Console.WriteLine($"Start Date: {aBooking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"End Date: {aBooking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine($"Amount: {aBooking.Amount}");
            Console.WriteLine($"Pickup Location: {aBooking.PickupLocation.Address}");
            Console.WriteLine($"Return Location: {aBooking.ReturnLocation.Address}");
            Console.WriteLine();
        }
        public void DisplaySuccessMessage(Booking aBooking)
        {
            Console.WriteLine("\nBooking updated successfully!");
            Console.WriteLine("Updated Booking Details:");
            DisplayBookingDetails(aBooking);
        }

        public Dictionary<string, string> RequestUpdatedBookingDetails()
        {
            Dictionary<string, string> updatedDetails = new Dictionary<string, string>();

            Console.WriteLine("\n\nEnter new start date and time (dd/MM/yyyy h:mm:ss tt):");
            updatedDetails["newStartDateTime"] = Console.ReadLine();

            Console.WriteLine("Enter new end date and time (dd/MM/yyyy h:mm:ss tt):");
            updatedDetails["newEndDateTime"] = Console.ReadLine();

            Console.WriteLine("Enter new pickup location ID:");
            updatedDetails["newPickupLocationId"] = Console.ReadLine();

            Console.WriteLine("Enter new return location ID:");
            updatedDetails["newReturnLocationId"] = Console.ReadLine();

            return updatedDetails;
        }

        public Dictionary<string, string> EnterUpdatedBookingDetails(Booking aBooking)
        {
            DisplayBookingDetails(aBooking);
            return RequestUpdatedBookingDetails();
        }

        public void RenterMenu(Renter renter, CTL_ModifyBooking ctlModifyBooking, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
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
                        if (renter.Bookings.Count > 0)
                        {
                            foreach (var booking in renter.Bookings)
                            {
                                DisplayBookingDetails(booking);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No bookings found.");
                        }
                        break;
                    case "2":
                        // Implement Book Car functionality here
                        Console.WriteLine("\n");
                        break;
                    case "3":
                        if (renter.Bookings.Count > 0)
                        {
                            foreach (var booking in renter.Bookings)
                            {
                                DisplayBookingDetails(booking);
                            }
                            Console.WriteLine("Enter the Booking ID you want to modify:");
                            int bookingId;
                            if (int.TryParse(Console.ReadLine(), out bookingId))
                            {
                                Booking selectedBooking = renter.Bookings.Find(b => b.Id == bookingId);
                                if (selectedBooking != null)
                                {
                                    bool isSuccessful = false;
                                    while (!isSuccessful)
                                    {
                                        var updatedDetails = EnterUpdatedBookingDetails(selectedBooking);
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
