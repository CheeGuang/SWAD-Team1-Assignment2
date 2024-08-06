using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jason.
    /// Creator: Wang Po Yen Jason
    /// Student ID: S10255872A
    /// </summary>
    public class CTL_ReturnCar
    {
        /// <summary>
        /// Gets the booking details and validity based on the provided booking ID.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="id">The booking ID.</param>
        /// <returns>A tuple containing the booking object and a validity flag.</returns>
        public (Booking, bool) getBookingDetails(int id)
        {
            Booking bookingDetails = Booking.getBookingDetails(id);
            bool validity = verifyValidity(bookingDetails);
            return (bookingDetails, validity);
        }

        /// <summary>
        /// Verifies the validity of the booking details.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="bookingDetails">The booking object.</param>
        /// <returns>A boolean indicating whether the booking details are valid.</returns>
        private bool verifyValidity(Booking bookingDetails)
        {
            if (bookingDetails != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the return date and time, and checks if the return is late.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="bookingDetails">The booking object.</param>
        /// <returns>A tuple containing the return date and time, and a late return flag.</returns>
        public (DateTime, bool) getReturnDateTime(Booking bookingDetails)
        {
            ReturnTimeslot returnTimeslot = bookingDetails.ReturnTimeslots.FirstOrDefault();

            if (returnTimeslot != null)
            {
                DateTime returnDateTime = returnTimeslot.getReturnDateTime();
                bool lateReturn = !checkLateReturn(returnDateTime);
                return (returnDateTime, lateReturn);
            }
            else
            {
                Console.WriteLine("No return timeslot found for this booking.");
                return (DateTime.MinValue, false); // Handle the case where no ReturnTimeslot is found
            }
        }

        /// <summary>
        /// Checks if the return is late.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="endDateTime">The end date and time of the return timeslot.</param>
        /// <returns>A boolean indicating whether the return is late.</returns>
        public bool checkLateReturn(DateTime endDateTime)
        {
            return DateTime.Now <= endDateTime;
        }

        /// <summary>
        /// Processes the payment for a late return.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="id">The booking ID.</param>
        public void processPayment(int id)
        {
            // Logic to process the payment, interacting with the payment gateway
            Console.WriteLine("This section is done by Pay Late Return Penalty Use Case");
            Console.Write("Press Enter to complete the payment: ");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Payment Complete.");
        }

        /// <summary>
        /// Updates the status of the booking.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="id">The booking ID.</param>
        /// <param name="newStatus">The new status to be set for the booking.</param>
        public void updateBookingStatus(int id, string newStatus)
        {
            Booking booking = Booking.getBookingDetails(id);
            if (booking != null)
            {
                booking.updateBookingStatus(newStatus);
            }
        }

    }
}

    
