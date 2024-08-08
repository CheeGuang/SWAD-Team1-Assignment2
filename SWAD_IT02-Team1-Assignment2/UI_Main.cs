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
        /// Modified By: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="dummyRenter">The dummy renter object.</param>
        /// <param name="dummyCarOwner">The dummy car owner object.</param>
        /// <param name="dummyICarAdmin">The dummy ICarAdmin object.</param>
        /// <param name="dummyCar">The dummy car object.</param>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void mainMenu(Renter dummyRenter, CarOwner dummyCarOwner, ICarAdmin dummyICarAdmin, Car dummyCar, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            displayWelcomeScreen(); // Display the ASCII art welcome screen

            while (true)
            {
                Console.WriteLine("\n===============================================");
                Console.WriteLine("                  Main Menu");
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
                        loginAsRenter(dummyRenter, dummyCar, pickupLocations, returnLocations);
                        break;
                    case "2":
                        loginAsCarOwner(dummyCarOwner);
                        break;
                    case "3":
                        loginAsICarAdmin(dummyICarAdmin);
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
        /// Modified By: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="dummyRenter">The dummy renter object.</param>
        /// <param name="pickupLocations">List of pickup locations.</param>
        /// <param name="returnLocations">List of return locations.</param>
        public void loginAsRenter(Renter dummyRenter, Car dummyCar, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            Console.WriteLine($"Logged in as Renter: {dummyRenter.Name}");
            UI_Renter uiRenter = new UI_Renter();
            uiRenter.renterMenu(dummyRenter, dummyCar, pickupLocations, returnLocations); // added dummyCar
        }

        /// <summary>
        /// Logs in as Car Owner.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="dummyCarOwner">The dummy car owner object.</param>
        public void loginAsCarOwner(CarOwner dummyCarOwner)
        {
            Console.WriteLine($"Logged in as Car Owner: {dummyCarOwner.Name}");
            UI_CarOwner uiCarOwner = new UI_CarOwner();
            uiCarOwner.carOwnerMenu(dummyCarOwner);
        }

        /// <summary>
        /// Logs in as ICarAdmin.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="dummyICarAdmin">The dummy ICarAdmin object.</param>
        public void loginAsICarAdmin(ICarAdmin dummyICarAdmin)
        {
            Console.WriteLine($"Logged in as ICarAdmin: {dummyICarAdmin.Name}");
            UI_ICarAdmin uiICarAdmin = new UI_ICarAdmin();
            uiICarAdmin.iCarAdminMenu(dummyICarAdmin);
        }

        /// <summary>
        /// Displays the ASCII art welcome screen.
        /// </summary>
        private void displayWelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
 ___ ____              ____             ____            _        _ 
|_ _/ ___|__ _ _ __   / ___|__ _ _ __  |  _ \ ___ _ __ | |_ __ _| |
 | | |   / _` | '__| | |   / _` | '__| | |_) / _ \ '_ \| __/ _` | |
 | | |__| (_| | |    | |__| (_| | |    |  _ <  __/ | | | || (_| | |
|___\____\__,_|_|     \____\__,_|_|    |_| \_\___|_| |_|\__\__,_|_|
/ ___|  ___ _ ____   _(_) ___ ___                                  
\___ \ / _ \ '__\ \ / / |/ __/ _ \                                 
 ___) |  __/ |   \ V /| | (_|  __/                                 
|____/ \___|_|    \_/ |_|\___\___|                                 
            ");
            Console.ResetColor();
        }
    }
}
