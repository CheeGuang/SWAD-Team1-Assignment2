using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Ong Yee Hen.
    /// Creator: Ong Yee Hen
    /// Student ID: S10258759D
    /// </summary>
    internal class CTL_PickupAtiCarStation
    {
        /// <summary>
        /// Get booking details using booking id.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        /// <param name="id">The booking ID</param>
        /// <returns>booking and Validity = True if the details exists, otherwise false.</returns>
        public (Booking, bool) getBookingDetails(int id)
        {
            Booking booking = Booking.getBookingDetails(id);
            bool validity = checkBookingValidity(booking);
            return (booking, validity);
            
        }

        /// <summary>
        /// Check if booking details is null.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        /// <param name="booking">The booking details</param>
        /// <returns>Validity = True if the details exists, otherwise false.</returns>
        public bool checkBookingValidity(Booking booking)
        {
            bool validity = false;
            if (booking != null)
            {
                validity = true;
                Console.WriteLine($"Booking Validity is {validity}.");
                return validity;
            }
            else {
                Console.WriteLine($"Booking Validity is {validity}. Please Try Again.");
                return validity;
            }

        }

        /// <summary>
        /// Get start date time of the pickup timeslot.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        /// <param name="booking">The booking details</param>
        /// <returns>start date time, otherwise DateTime.MinValue.</returns>
        public DateTime getStartDateTime(Booking booking)
        {
            PickupTimeslot pickupTimeslot = booking.PickupTimeslots.FirstOrDefault();
            if (pickupTimeslot != null)
            {
                DateTime startDateTime = pickupTimeslot.getStartDateTime();
                
                return startDateTime;                    
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Process the pickup.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        /// <param name="booking">The booking details</param>
        /// <returns>pickupResult = success if time has passed the start date time, otherwise failure.</returns>
        public string processPickup(Booking booking)
        {
            string pickupResult;
            DateTime startDateTime = getStartDateTime(booking);
            if (DateTime.Now >= startDateTime)
            {
                booking.updateBookingStatus("Car picked up");
                Console.WriteLine($"Your booking status is now updated to {booking.Status}.");
                pickupResult = "success";
                return pickupResult;
            }
            else
            {
                pickupResult = "failure";
                return pickupResult;
            }
        }
    }
}
