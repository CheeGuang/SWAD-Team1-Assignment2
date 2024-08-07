using System;
using System.Collections.Generic;
using SWAD_IT02_Team1_Assignment2;

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
            UI_RegisterCar uiRegisterCar = new UI_RegisterCar();

            while (true)
            {
                Console.WriteLine("\n===============================================");
                Console.WriteLine("                CarOwner Menu");
                Console.WriteLine("===============================================");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. View All Cars");
                Console.WriteLine("2. Register Car");
                Console.WriteLine("0. Logout");
                Console.ResetColor(); // Reset to default console colour
                Console.WriteLine("===============================================\n");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // Where the View All Cars functionality starts.
                        ViewAllCars(carOwner);
                        continue;
                    case "2":
                        // Where the Register Car functionality starts.
                        uiRegisterCar.registerCar(carOwner);
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

        /// <summary>
        /// Displays all cars of the car owner.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="carOwner">The car owner object.</param>
        private void ViewAllCars(CarOwner carOwner)
        {
            if (carOwner.Cars.Count == 0)
            {
                Console.WriteLine("You have no cars registered.\n");
                return;
            }

            Console.WriteLine("===============================================");
            Console.WriteLine("                Your Cars");
            Console.WriteLine("===============================================");

            for (int i = 0; i < carOwner.Cars.Count; i++)
            {
                var car = carOwner.Cars[i];
                Console.WriteLine($"ID: {car.Id}");
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"Mileage: {car.Mileage}");
                Console.WriteLine($"Rental Price: {car.RentalPrice:C}");
                Console.WriteLine($"Number Plate: {car.NumberPlate}");
                Console.WriteLine($"Verified: {car.IsVerified}");

                if (carOwner.Cars.Count > 1 && i < carOwner.Cars.Count - 1)
                {
                    Console.WriteLine("-----------------------------------------------");
                }
            }

            Console.WriteLine("===============================================\n");
        }
    }
}
