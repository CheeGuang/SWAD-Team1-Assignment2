using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class UI_Main
    {
        /// <summary>
        /// Displays the main menu.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="dummyRenter">The dummy renter object.</param>
        /// <param name="dummyCarOwner">The dummy car owner object.</param>
        /// <param name="dummyICarAdmin">The dummy ICarAdmin object.</param>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void MainMenu(Renter dummyRenter, CarOwner dummyCarOwner, ICarAdmin dummyICarAdmin, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            while (true)
            {
                Console.WriteLine("\n===============================================");
                Console.WriteLine("         Welcome to iCar Car Rental System");
                Console.WriteLine("===============================================");
                Console.WriteLine("1. Login as Renter");
                Console.WriteLine("2. Login as CarOwner");
                Console.WriteLine("3. Login as iCarAdmin");
                Console.WriteLine("0. Exit");
                Console.WriteLine("===============================================\n");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        LoginAsRenter(dummyRenter, pickupLocations, returnLocations);
                        break;
                    case "2":
                        LoginAsCarOwner(dummyCarOwner);
                        break;
                    case "3":
                        LoginAsICarAdmin(dummyICarAdmin);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        break;
                }
            }
        }

        /// <summary>
        /// Logs in as Renter.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="dummyRenter">The dummy renter object.</param>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void LoginAsRenter(Renter dummyRenter, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            Console.WriteLine($"Logged in as Renter: {dummyRenter.Name}");
            UI_Renter uiRenter = new UI_Renter();
            uiRenter.RenterMenu(dummyRenter, pickupLocations, returnLocations);
        }

        /// <summary>
        /// Logs in as Car Owner.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="dummyCarOwner">The dummy car owner object.</param>
        public void LoginAsCarOwner(CarOwner dummyCarOwner)
        {
            Console.WriteLine($"Logged in as Car Owner: {dummyCarOwner.Name}");
            UI_CarOwner uiCarOwner = new UI_CarOwner();
            uiCarOwner.CarOwnerMenu(dummyCarOwner);
        }

        /// <summary>
        /// Logs in as ICarAdmin.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="dummyICarAdmin">The dummy ICarAdmin object.</param>
        public void LoginAsICarAdmin(ICarAdmin dummyICarAdmin)
        {
            Console.WriteLine($"Logged in as ICarAdmin: {dummyICarAdmin.Name}");
            UI_ICarAdmin uiICarAdmin = new UI_ICarAdmin();
            uiICarAdmin.ICarAdminMenu(dummyICarAdmin);
        }
    }
}
