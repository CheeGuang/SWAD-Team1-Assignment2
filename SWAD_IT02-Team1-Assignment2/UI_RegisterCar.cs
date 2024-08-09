using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Threading;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to sequence diagram done by Sian Kim.
    /// Creator: Cing Sian Kim
    /// Student ID: S10257716F
    /// </summary>
    public class UI_RegisterCar
    {
        private CTL_RegisterCar ctlRegisterCar;

        public UI_RegisterCar()
        {
            ctlRegisterCar = new CTL_RegisterCar();
        }

        private Car newCar;

        /// <summary>
        /// Registers a car for the car owner.
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public void registerCar(CarOwner carOwner)
        {
            displayCarRegistrationForm(carOwner);

        }

        /// <summary>
        /// Registers a car for the car owner.
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        private void displayCarRegistrationForm(CarOwner carOwner)
        {

            // Get car details from user input
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine($"Car Details");
            Console.WriteLine("===============================================");
            Console.Write($"Make: ");
            string make = Console.ReadLine();
            Console.Write($"Model: ");
            string model = Console.ReadLine();
            Console.Write($"Year: ");
            string year = Console.ReadLine();
            Console.Write($"Mileage (km): ");
            string mileage = Console.ReadLine();
            Console.Write($"Rental Price (SGD): ");
            string rentalPrice = Console.ReadLine();
            Console.Write($"Number Plate: ");
            string numberPlate = Console.ReadLine();

            bool isVerified = submitCarDetails(make, model, year, mileage, rentalPrice, numberPlate);

            if (isVerified)
            {
                newCar = ctlRegisterCar.createCar(carOwner, make, model, Convert.ToInt32(year), Convert.ToDecimal(mileage), Convert.ToDecimal(rentalPrice), numberPlate, isVerified);
                displayPhotoForm();
                displayAvailabilityScheduleForm();
                displayInsuranceForm();
                displayRegistrationSuccess();
                
            }
            else
            {
                displayErrorMessage();
            }
        }

        /// <summary>
        /// Informs user of error in registration
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public bool submitCarDetails(string make, string model, string year, string mileage, string rentalPrice, string numberPlate)
        {
            bool isValid = ctlRegisterCar.validateCarDetails(make, model, year, mileage, rentalPrice, numberPlate);
            return isValid;
        }


        /// <summary>
        /// Informs user of error in registration
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        private void displayErrorMessage()
        {
            Console.WriteLine("Error in registration, please try again.");
        }



        /// <summary>
        /// Displays photo upload form for users to input their information.
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public void displayPhotoForm()
        {

            Console.WriteLine("\n===============================================");
            Console.WriteLine($"Photo Upload Form");
            Console.WriteLine("===============================================");
            uploadPhoto();
            
        }

        /// <summary>
        /// Uploads one photo to the ctl
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        private void uploadPhoto()
        {
            int photoId = 1;
            while (true)
            {
                Console.Write("Enter photo URL of either .jpg or .png (or 'done' to finish): ");
                string photoUrl = Console.ReadLine();

                if (photoUrl.ToLower() == "done")
                {
                    if (photoId == 1)
                    {
                        Console.WriteLine("You must upload at least one photo before finishing.");
                        continue;  // Skip the rest of the loop to force another iteration
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Enter photo caption: ");
                string caption = Console.ReadLine();
                bool photoIsValid = ctlRegisterCar.processPhotoUpload(photoId, photoUrl, caption);

                if (!photoIsValid)
                {
                    displayInvalidPhotoMessage();
                } else
                {
                    photoId++;
                }
            }
        }

        /// <summary>
        /// Shows invalid photo message 
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public void displayInvalidPhotoMessage()
        {
            Console.WriteLine("Photo upload failed. Please try again.");
        }

        /// <summary>
        /// Displays Availability Schedule form for users to input their information.
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public void displayAvailabilityScheduleForm()
        {
            Console.WriteLine("\n===============================================");
            Console.WriteLine($"Availability Schedule Form");
            Console.WriteLine("===============================================");
            Console.WriteLine("Provide dates to add a schedule:");

            submitAvailabilitySchedule();
        }

        /// <summary>
        /// Allows users to submit availability schedule for the new registered car.
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        private void submitAvailabilitySchedule()
        {
            while (true)
            {
                Console.Write("Start date (YYYY-MM-DD): ");
                string startInput = Console.ReadLine();

                Console.Write("End date (YYYY-MM-DD): ");
                string endInput = Console.ReadLine();

                if (startInput.ToLower() == "done")
                {
                    break; // Exit the loop and method if the user types "done"
                }

                if (endInput.ToLower() == "done")
                {
                    break; // Exit the loop and method if the user types "done"
                }

                try
                {
                    DateTime startDate = DateTime.Parse(startInput);
                    DateTime endDate = DateTime.Parse(endInput);

                    bool dateIsValid = ctlRegisterCar.validateAvailabilitySchedule(startDate, endDate);

                    if (dateIsValid)
                    {
                        Console.WriteLine("Availability schedule added successfully.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid schedule. Please try again.");

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date format. Please enter dates in YYYY-MM-DD format.");
                }
            }
        }

        /// <summary>
        /// Display form for users to enter input
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        private void displayInsuranceForm()
        {
            Console.WriteLine("\n===============================================");
            Console.WriteLine($"Availability Schedule Form");
            Console.WriteLine("===============================================");
            Console.Write("Do you want to apply for iCar insurance? (yes/no): ");
            submitInsuranceChoice(Console.ReadLine());
        }

        /// <summary>
        /// Submits the user's insurance choice
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public void submitInsuranceChoice(string choice)
        {
            ctlRegisterCar.submitInsuranceChoice(choice.ToLower() == "yes");
        }

        /// <summary>
        /// Shows registration success message 
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public void displayRegistrationSuccess()
        {
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine("Car registration successful!");
            Console.WriteLine("===============================================");
            displayCarDetails(newCar);
        }

        /// <summary>
        /// Display Car Details
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public void displayCarDetails(Car newCar)
        {
            Console.WriteLine($"Car Details:");
            Console.WriteLine($"Car Id: {newCar.Id}");
            Console.WriteLine($"Make: {newCar.Make}");
            Console.WriteLine($"Model: {newCar.Model}");
            Console.WriteLine($"Year: {newCar.Year}");
            Console.WriteLine($"Number Plate: {newCar.NumberPlate}");
            Console.WriteLine($"Rental Rate: {newCar.RentalPrice}");
            Console.WriteLine($"Number of Photos: {newCar.Photos.Count}");
            Console.WriteLine($"Insurance Applied: {(newCar.Insurance != null ? "Yes" : "No")}");
            Console.WriteLine($"Car Owner: {newCar.CarOwner.Name}");
            Console.WriteLine("===============================================");
        }
    }
}
