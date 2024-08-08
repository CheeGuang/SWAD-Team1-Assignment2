using System;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to sequence diagram done by Sian Kim.
    /// Creator: Cing Sian Kim
    /// Student ID: S10257716F
    /// </summary>
    public class CTL_RegisterCar
    {
        public Car newCar;
        private static int carId = 2;
        private static int scheduleId = 2;
        private static int insuranceId = 2;

        /// <summary>
        /// Validates the entered car details.
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        /// <param name="make">The make of the car.</param>
        /// <param name="model">The model of the car.</param>
        /// <param name="year">The year the car was bought.</param>
        /// <param name="mileage">The mileage of the car.</param>
        /// <param name="rentalPrice">The rental price of the car.</param>
        /// <param name="numberPlate">The number plate of the car.</param>
        /// <returns>True if the details are valid, otherwise false.</returns>

        public bool ValidateCarDetails(string make, string model, string year, string mileage, string rentalPrice, string numberPlate)
        {
            bool isValid = false;

            if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(year) || string.IsNullOrWhiteSpace(mileage) || string.IsNullOrWhiteSpace(rentalPrice) || string.IsNullOrWhiteSpace(numberPlate))
            {
                Console.WriteLine("All fields must be filled.");
                return isValid;
            }

            if (!int.TryParse(year, out int parsedYear))
            {
                Console.WriteLine("Year must be a valid integer.");
                return isValid;
            }

            int currentYear = DateTime.Now.Year;
            if (parsedYear < 1886 || parsedYear > currentYear)
            {
                Console.WriteLine($"Year must be between 1886 and {currentYear}.");
                return isValid;
            }

            if (!decimal.TryParse(mileage, out decimal parsedMileage))
            {
                Console.WriteLine("Mileage must be a valid decimal number.");
                return isValid;
            }

            if (parsedMileage < 0)
            {
                Console.WriteLine("Mileage cannot be negative.");
                return isValid;
            }

            if (!decimal.TryParse(rentalPrice, out decimal parsedRentalPrice))
            {
                Console.WriteLine("Rental Price must be a valid decimal number.");
                return isValid;
            }

            if (parsedRentalPrice <= 0)
            {
                Console.WriteLine("Rental Price must be more than zero.");
                return isValid;
            }

            isValid = true;
            return isValid;
        }

        /// <summary>
        /// Creates a car object
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        /// <param name="carOwner">Owner of the registering car.</param>
        /// <param name="make">The make of the car.</param>
        /// <param name="model">The model of the car.</param>
        /// <param name="year">The year the car was bought.</param>
        /// <param name="mileage">The mileage of the car.</param>
        /// <param name="rentalPrice">The rental price of the car.</param>
        /// <param name="numberPlate">The number plate of the car.</param>
        public void CreateCar(CarOwner carOwner, string make, string model, int year, decimal mileage, decimal rentalPrice, string numberPlate, bool isVerified)
        {
            newCar = new Car(carId++, make, model, year, mileage, rentalPrice, numberPlate, isVerified, carOwner);
            carOwner.addCar(newCar);
        }

        /// <summary>
        /// Uploads photo object into car
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        /// <param name="photoId">Id of the photo.</param>
        /// <param name="url">Url of the photo.</param>
        /// <param name="caption">Caption of the photo.</param>
        public bool processPhotoUpload(int photoId, string url, string caption)
        {
            Photo photo = new Photo(photoId, caption, url);
            newCar.addPhoto(photo);
            return true;
        }

        /// <summary>
        /// Uploads availability schedule object into car
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        /// <param name="startDate">Start date of availability schedule</param>
        /// <param name="endDate">End date of availability schedule</param>
        public bool validateAvailabilitySchedule(DateTime startDate, DateTime endDate)
        {
            if (startDate == null || endDate == null || startDate < endDate)
            {
                AvailabilitySchedule schedule = new AvailabilitySchedule(scheduleId++, startDate, endDate);
                newCar.addAvailabilitySchedule(schedule);
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Uploads insurance object into car
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        /// <param name="applyForInsurance">Choice user makes if they want insurance for their car or not</param>
        public void submitInsuranceChoice(bool applyForInsurance)
        {
            if (applyForInsurance)
            {
                newCar.Insurance = new Insurance(insuranceId++, Convert.ToDecimal(10000.00), newCar, DateTime.Today);
            }

        }

        /// <summary>
        /// Display Car Details
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        public void displayCarDetails()
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
