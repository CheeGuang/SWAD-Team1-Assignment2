using System;
using System.Linq;
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
            Console.WriteLine($"Prepare the following car details to register a car.");
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

            bool isVerified = ctlRegisterCar.ValidateCarDetails(make, model, year, mileage, rentalPrice, numberPlate);

            if (isVerified)
            {
                ctlRegisterCar.CreateCar(carOwner, make, model, Convert.ToInt32(year), Convert.ToDecimal(mileage), Convert.ToDecimal(rentalPrice), numberPlate, isVerified);
                uploadPhotos();
                submitAvailabilitySchedule();
                string choice = displayInsuranceForm();
                submitInsuranceChoice(choice);
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
        private void displayErrorMessage()
        {
            Console.WriteLine("Error in registration, please try again.");
        }

        /// <summary>
        /// Displays photo upload form for users to input their information.
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        private void uploadPhotos()
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

                // Validation of the URL to ensure it ends with either .jpg or .png
                if (photoUrl.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || photoUrl.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Enter photo caption: ");
                    string caption = Console.ReadLine();
                    bool photoIsValid = ctlRegisterCar.processPhotoUpload(photoId, photoUrl, caption);

                    if (photoIsValid)
                    {
                        Console.WriteLine($"Photo {photoId} uploaded successfully.");
                        photoId++;
                    }
                    else
                    {
                        displayInvalidPhotoMessage();
                    }
                }
                else
                {
                    // Notifies the user if the URL is not valid
                    Console.WriteLine("Invalid URL. Please enter a URL that ends with .jpg or .png.");
                }
            }
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
                Console.WriteLine("Provide dates to add a schedule:");

                Console.Write("Start date (YYYY-MM-DD): ");
                string startInput = Console.ReadLine();
                if (startInput.ToLower() == "done")
                {
                    break; // Exit the loop and method if the user types "done"
                }

                Console.Write("End date (YYYY-MM-DD): ");
                string endInput = Console.ReadLine();
                if (endInput.ToLower() == "done")
                {
                    break; // Exit the loop and method if the user types "done"
                }

                try
                {
                    DateTime startDate = DateTime.Parse(startInput);
                    DateTime endDate = DateTime.Parse(endInput);

                    bool isValid = ctlRegisterCar.validateAvailabilitySchedule(startDate, endDate);

                    if (isValid)
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
        private string displayInsuranceForm()
        {
            Console.Write("Do you want to apply for insurance? (yes/no): ");
            return Console.ReadLine();
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
        /// Shows invalid photo message 
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public void displayInvalidPhotoMessage()
        {
            Console.WriteLine("Photo upload failed. Please try again.");
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
            ctlRegisterCar.displayCarDetails();
        }

    }
}
