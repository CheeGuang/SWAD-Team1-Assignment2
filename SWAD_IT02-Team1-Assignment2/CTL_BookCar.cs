using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        /// Create new booking object.
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="car">The car selected.</param>
        /// <param name="renter">The renter making the booking.</param>
        /// <returns>True if the update is successful, otherwise false.</returns> 
        public bool ProcessBookingRequest(Renter renter, Car car)
        {
            try
            {
                //validate booking availability slot
                uiBookCar.DisplayAvailabilitySchedule(car.NumberPlate, car.AvailabilitySchedules);
                int slotID;
                AvailabilitySchedule selectedSlot = null;
                do
                {
                    slotID = uiBookCar.GetSelectedAvailabilitySlot();
                    selectedSlot = GetAvailabilitySlot(slotID, car.AvailabilitySchedules);

                } while (selectedSlot == null);

                //validate bookingdates
                Dictionary<string, string> bookingDetails;
                do
                {
                    bookingDetails = uiBookCar.GetBookingDates();

                } while (!ValidateBookingDates(selectedSlot, bookingDetails));
                

                //validate pickup/return locations
                uiBookCar.DisplayLocations(Program.pickupLocations, Program.returnLocations);
                do
                {
                    bookingDetails = uiBookCar.GetSelectedLocations();

                } while (!ValidateBookingLocations(bookingDetails));


                // Call UI to confirm payment
                decimal totalCost = CalculateCost(DateTime.Parse(bookingDetails["startDateTime"]), DateTime.Parse(bookingDetails["endDateTime"]));
                bool commitPayment = uiBookCar.DisplayPaymentOption(totalCost);

                if (!commitPayment)
                {
                    Console.WriteLine("Your booking request has been cancelled successfully");
                    return false; // Abort the booking
                }

                // Assume Payment handled
                Payment payment = PaymentModel.Instance.MakePayment(totalCost);
                

                // Commit the new booking
                Booking booking = new Booking(renter.Bookings.Count, renter, car, DateTime.Parse(bookingDetails["startDateTime"]), DateTime.Parse(bookingDetails["endDateTime"]), totalCost, 
                    payment, getPickupLocationById(int.Parse(bookingDetails["pickupLocation"])), getReturnLocationById(int.Parse(bookingDetails["returnLocation"])), "Created Successfully");
                renter.AddBooking(booking);

                //Console print booking summary
                uiBookCar.PrintBookingSummary(booking);

                // Send an Email
                EmailSystem.SendBookingConfirmationEmail(renter.Email, renter.Name, booking);

                return true;
            } catch
            {
                // If booking fails
                return false;
            }
           
        }

        private AvailabilitySchedule GetAvailabilitySlot(int slotID, List<AvailabilitySchedule> availabilities)
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
        public bool ValidateBookingDates(AvailabilitySchedule availability, Dictionary<string, string> bookingDetails)
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
        public bool ValidateBookingLocations(Dictionary<string, string> bookingDetails)
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
            bool pickupLocationExists = Program.pickupLocations.Any(p => p.Id == pickupLocation);
            bool returnLocationExists = Program.returnLocations.Any(r => r.Id == returnLocation);

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

        private ReturnLocation getReturnLocationById(int id)
        {
            foreach(ReturnLocation location in Program.returnLocations) 
            { 
                if(id == location.Id)
                {
                    return location;
                }
            }
            return null;
        }
        private PickupLocation getPickupLocationById(int id)
        {
            foreach (PickupLocation location in Program.pickupLocations)
            {
                if (id == location.Id)
                {
                    return location;
                }
            }
            return null;
        }

        public decimal CalculateCost(DateTime endDate, DateTime startDate)
        {
            return 5 * Math.Abs((decimal)(endDate - startDate).TotalHours);
        }
    }
}
