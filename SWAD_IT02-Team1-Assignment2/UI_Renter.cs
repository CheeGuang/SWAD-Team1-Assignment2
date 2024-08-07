using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class UI_Renter
    {
        /// <summary>
        /// Displays the renter menu.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="renter">The renter object.</param>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void RenterMenu(Renter renter, Car dummyCar, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            UI_ModifyBooking uiModifyBooking = new UI_ModifyBooking();
            CTL_BookCar ctlBookCar = new CTL_BookCar();
            UI_ReturnCar uiReturnCar = new UI_ReturnCar();
            UI_PickupAtiCarStation uiPickupAtiCarStation = new UI_PickupAtiCarStation();

            while (true)
            {
                Console.WriteLine("\n===============================================");
                Console.WriteLine("                  Renter Menu");
                Console.WriteLine("===============================================");

                // Display menu options with colours
                Console.WriteLine("1. View Bookings");
                Console.WriteLine("2. Book Car");
                Console.WriteLine("3. Modify Booking");
                Console.WriteLine("4. Pickup Car");
                Console.WriteLine("5. Return Car");
                Console.WriteLine("0. Logout");

                Console.WriteLine("===============================================\n");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

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
                        ctlBookCar.ProcessBookingRequest(renter, dummyCar, pickupLocations, returnLocations);
                        break;
                    case "3":
                        uiModifyBooking.ModifyBooking(renter, pickupLocations, returnLocations);
                        break;
                    case "4":
                        // Implement Pickup Car functionality here
                        uiPickupAtiCarStation.startPickupAtiCarStation();
                        break;
                    case "5":
                        // Implement Return Car functionality here
                        uiReturnCar.initiateCarReturn();
                        Console.WriteLine("\n");
                        break;
                    case "0":
                        Console.WriteLine("\nLog out successful. You have been securely signed out.\n");
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        break;
                }
            }
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
            Console.WriteLine($"Status:             {aBooking.Status}");
            Console.WriteLine("===============================================\n");
        }
    }
}
