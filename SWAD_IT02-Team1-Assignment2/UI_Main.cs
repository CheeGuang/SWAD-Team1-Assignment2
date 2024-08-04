using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    public class UI_Main
    {
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

        public void LoginAsRenter(Renter dummyRenter, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            Console.WriteLine($"Logged in as Renter: {dummyRenter.Name}");
            UI_Renter uiRenter = new UI_Renter();
            uiRenter.RenterMenu(dummyRenter, pickupLocations, returnLocations);
        }

        public void LoginAsCarOwner(CarOwner dummyCarOwner)
        {
            Console.WriteLine($"Logged in as Car Owner: {dummyCarOwner.Name}");
            UI_CarOwner uiCarOwner = new UI_CarOwner();
            uiCarOwner.CarOwnerMenu(dummyCarOwner);
        }

        public void LoginAsICarAdmin(ICarAdmin dummyICarAdmin)
        {
            Console.WriteLine($"Logged in as ICarAdmin: {dummyICarAdmin.Name}");
            UI_ICarAdmin uiICarAdmin = new UI_ICarAdmin();
            uiICarAdmin.ICarAdminMenu(dummyICarAdmin);
        }
    }
}
