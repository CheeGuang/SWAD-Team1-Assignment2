using System;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class UI_CarOwner
    {
        /// <summary>
        /// Displays the Car Owner menu.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="carOwner">The car owner object.</param>
        public void CarOwnerMenu(CarOwner carOwner)
        {
            while (true)
            {
                Console.WriteLine("\n===============================================");
                Console.WriteLine("                CarOwner Menu");
                Console.WriteLine("===============================================");
                Console.WriteLine("1. Register Car");
                Console.WriteLine("0. Logout");
                Console.WriteLine("===============================================\n");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // Implement Register Car functionality here
                        Console.WriteLine("\n");
                        continue;
                    case "0":
                        Console.WriteLine("\nLog out successful. You have been securely signed out.\n");
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        continue;
                }
            }
        }
    }
}
