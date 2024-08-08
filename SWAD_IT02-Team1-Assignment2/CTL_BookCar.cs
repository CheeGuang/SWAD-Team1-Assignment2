using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Raeanne.
    /// Creator: Zou Ruining, Raeanne
    /// Student ID: S10258772G
    /// </summary>
    public class CTL_BookCar
    {
        private UI_BookCar uiBookCar;

        public CTL_BookCar(){
            uiBookCar = new UI_BookCar();
        }

        /// <summary>
        /// Processes all the booking requests and validate data
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="car">The car selected.</param>
        /// <param name="renter">The renter making the booking.</param>
        /// <returns>True if the update is successful, otherwise false.</returns> 
        public bool processBookingRequest(Renter renter, Car car, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            try
            {
                //validate booking availability slot
                uiBookCar.displayAvailabilitySchedule(car.NumberPlate, car.AvailabilitySchedules);
                int slotID = -1;
                AvailabilitySchedule selectedSlot = null;
                do
                {
                    slotID = uiBookCar.promptSelectedAvailabilitySlot();
                    selectedSlot = getAvailabilitySlot(slotID, car.AvailabilitySchedules);

                } while (selectedSlot == null);

                //validate bookingdates
                Dictionary<string, string> bookingDetails = null;
                bool isBookingDatesValid = false;
                do
                {
                    bookingDetails = uiBookCar.promptBookingDates();
                    isBookingDatesValid = validateBookingDates(selectedSlot, bookingDetails);
                } while (!isBookingDatesValid);


                //validate pickup/return locations
                bool isLocValid = false;
                uiBookCar.displayLocations(pickupLocations, returnLocations);
                do
                {
                    bookingDetails = uiBookCar.promptSelectedLocations();
                    isLocValid = validateBookingLocations(bookingDetails, pickupLocations, returnLocations);
                } while (!isLocValid);


                // Call UI to confirm payment
                decimal totalCost = calculateCost(DateTime.Parse(bookingDetails["startDateTime"]), DateTime.Parse(bookingDetails["endDateTime"]));
                bool commitPayment = uiBookCar.promptPaymentConfirmation(totalCost);

                if (!commitPayment)
                {
                    Console.WriteLine("Your booking request has been cancelled successfully");
                    return false; // Abort the booking
                }

                // Dummy Data
                Card card1 = new Card(1, "5520728801926284", "John Doe", new DateTime(2025, 12, 31), "Visa", "DBS");
                Payment payment = new Payment(1, 120.00m, "Credit Card", DateTime.Now, card1);

                // Assume Payment made
                payment.makePayment(totalCost);

                // Call method to create booking
                Booking aBooking = createBooking(renter.Bookings.Count + 1, renter, car, DateTime.Parse(bookingDetails["startDateTime"]), DateTime.Parse(bookingDetails["endDateTime"]), totalCost,
                payment, getPickupLocationById(int.Parse(bookingDetails["pickupLocation"]), pickupLocations), getReturnLocationById(int.Parse(bookingDetails["returnLocation"]), returnLocations), "Created Successfully");

                // Console print booking summary
                uiBookCar.printBookingSummary(aBooking);

                // Send an Email
                EmailSystem.sendBookingConfirmationEmail(renter.Email, renter.Name, aBooking);

                return true;
            } catch
            {
                // If booking fails
                return false;
            }
           
        }

        private Booking createBooking(int id, Renter renter, Car car, DateTime rentStartDateTime, DateTime rentEndDateTime, decimal amount, Payment payment, PickupLocation pickupLocation, ReturnLocation returnLocation, string status)
        {
            // Commit the new booking
            Booking booking = new Booking(id, renter, car, rentStartDateTime, rentEndDateTime,amount, payment, pickupLocation, returnLocation, status);
            renter.addBooking(booking);
            return booking;
        }

        /// <summary>
        /// Get the availability schedule based on user's selected slot ID
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="slotID">Availability Schedule ID</param>
        /// <param name="availabilities">List of selected car's availability schedule</param>
        private AvailabilitySchedule getAvailabilitySlot(int slotID, List<AvailabilitySchedule> availabilities)
        {
            foreach (AvailabilitySchedule availability in availabilities)
            {
                if (availability.Id == slotID)
                {
                    return availability;
                }
            }
            return null;
        }

        /// <summary>
        /// Validate booking dates.
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="availability">The updated booking details.</param>
        /// <param name="bookingDetails">The updated booking details.</param>
        /// <returns>True if the details are valid, otherwise false.</returns>
        public bool validateBookingDates(AvailabilitySchedule availability, Dictionary<string, string> bookingDetails)
        {
            DateTime startDateTime;
            DateTime endDateTime;

            // Check formatting
            if (!DateTime.TryParseExact(bookingDetails["startDateTime"], "dd/MM/yyyy h:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out startDateTime))
            {
                Console.WriteLine("Invalid Start DateTime format.");
                return false;
            }
            if (!DateTime.TryParseExact(bookingDetails["endDateTime"], "dd/MM/yyyy h:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out endDateTime))
            {
                Console.WriteLine("Invalid End DateTime format.");
                return false;
            }

            // Checking if the start and end dates are outside the availability schedule
            if (startDateTime < availability.StartDate || startDateTime > availability.EndDate)
            {
                Console.WriteLine("Selected Start Date is not available.");
                return false;
            }
            if (endDateTime < availability.StartDate || endDateTime > availability.EndDate)
            {
                Console.WriteLine("Selected End Date is not available.");
                return false;
            }

            // Check if the end date is later than start date
            if (endDateTime <= startDateTime)
            {
                Console.WriteLine("End DateTime must be after Start DateTime.");
                return false;
            }

            // All validations passed
            return true;
        }

        /// <summary>
        /// Validates booking locations.
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="bookingDetails">The updated booking details.</param>
        /// <returns>True if the details are valid, otherwise false.</returns>
        public bool validateBookingLocations(Dictionary<string, string> bookingDetails, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            int pickupLocation;
            int returnLocation;

            // Check formatting
            if (!int.TryParse(bookingDetails["pickupLocation"], out pickupLocation))
            {
                Console.WriteLine("Invalid Pickup Location ID format.");
                return false;
            }
            if (!int.TryParse(bookingDetails["returnLocation"], out returnLocation))
            {
                Console.WriteLine("Invalid Return Location ID format.");
                return false;
            }

            // Check if locations exists
            bool pickupLocationExists = pickupLocations.Any(p => p.Id == pickupLocation);
            bool returnLocationExists = returnLocations.Any(r => r.Id == returnLocation);

            if (!pickupLocationExists)
            {
                Console.WriteLine("Pickup Location ID does not exist.");
                return false;
            }
            if (!returnLocationExists)
            {
                Console.WriteLine("Return Location ID does not exist.");
                return false;
            }

            // All validations passed
            return true;
        }

        /// <summary>
        /// Get the return location by ID
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="id">Return location ID</param>
        private ReturnLocation getReturnLocationById(int id, List<ReturnLocation> returnLocations)
        {
            foreach(ReturnLocation location in returnLocations) 
            { 
                if(id == location.Id)
                {
                    return location;
                }
            }
            return null;
        }

        /// <summary>
        /// Get the pickup location by ID
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="id">Pickup location ID</param>
        private PickupLocation getPickupLocationById(int id, List<PickupLocation> pickupLocations)
        {
            foreach (PickupLocation location in pickupLocations)
            {
                if (id == location.Id)
                {
                    return location;
                }
            }
            return null;
        }

        /// <summary>
        /// Calculate total cost of current booking request: assumption $5/hr
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="endDate">Booking End DateTime</param>
        /// <param name="startDate">Booking Start DateTime</param>
        public decimal calculateCost(DateTime endDate, DateTime startDate)
        {
            return 5 * Math.Abs((decimal)(endDate - startDate).TotalHours);
        }
    }
}
