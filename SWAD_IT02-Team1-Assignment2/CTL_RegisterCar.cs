using System;
using System.Security.Policy;

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

        public bool validateCarDetails(string make, string model, string year, string mileage, string rentalPrice, string numberPlate)
        {
            bool isVerified = false;

            if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(year) || string.IsNullOrWhiteSpace(mileage) || string.IsNullOrWhiteSpace(rentalPrice) || string.IsNullOrWhiteSpace(numberPlate))
            {
                Console.WriteLine("All fields must be filled.");
                return isVerified;
            }

            if (!int.TryParse(year, out int parsedYear))
            {
                Console.WriteLine("Year must be a valid integer.");
                return isVerified;
            }

            int currentYear = DateTime.Now.Year;
            if (parsedYear < 1886 || parsedYear > currentYear)
            {
                Console.WriteLine($"Year must be between 1886 and {currentYear}.");
                return isVerified;
            }

            if (!decimal.TryParse(mileage, out decimal parsedMileage))
            {
                Console.WriteLine("Mileage must be a valid decimal number.");
                return isVerified;
            }

            if (parsedMileage < 0)
            {
                Console.WriteLine("Mileage cannot be negative.");
                return isVerified;
            }

            if (!decimal.TryParse(rentalPrice, out decimal parsedRentalPrice))
            {
                Console.WriteLine("Rental Price must be a valid decimal number.");
                return isVerified;
            }   

            if (parsedRentalPrice <= 0)
            {
                Console.WriteLine("Rental Price must be more than zero.");
                return isVerified;
            }

            isVerified = true;
            return isVerified;
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
        public Car createCar(CarOwner carOwner, string make, string model, int year, decimal mileage, decimal rentalPrice, string numberPlate, bool isVerified)
        {
            newCar = new Car(carId++, make, model, year, mileage, rentalPrice, numberPlate, isVerified, carOwner);
            carOwner.addCar(newCar);
            return newCar;
        }

        /// <summary>
        /// Processes photo object and validates it
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        /// <param name="photoId">Id of the photo.</param>
        /// <param name="photoUrl">Url of the photo.</param>
        /// <param name="caption">Caption of the photo.</param>
        public bool processPhotoUpload(int photoId, string photoUrl, string caption)
        {
            bool photoIsValid = false;
            
            if (photoUrl.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || photoUrl.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            {
                photoIsValid = true;

                if (photoIsValid)
                {
                    createPhoto(photoId, photoUrl, caption);
                    Console.WriteLine($"Photo {photoId} uploaded successfully.");
                    photoId++;
                    return photoIsValid;
                }
                else
                {
                    return photoIsValid;
                }
            }
            else
            {
                // Notifies the user if the URL is not valid
                Console.WriteLine("Invalid URL. Please enter a URL that ends with .jpg or .png.");
                return photoIsValid;
            }
        }

        /// <summary>
        /// Creates photo object into car
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        /// <param name="photoId">Id of the photo.</param>
        /// <param name="photoUrl">Url of the photo.</param>
        /// <param name="caption">Caption of the photo.</param>
        public void createPhoto(int photoId, string photoUrl, string caption)
        {
            Photo photo = new Photo(photoId, caption, photoUrl);
            newCar.addPhoto(photo);
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
    }
}
