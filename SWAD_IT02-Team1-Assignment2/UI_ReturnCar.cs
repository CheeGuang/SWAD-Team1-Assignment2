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
    public class UI_ReturnCar
    {
        private CTL_ReturnCar ctlReturnCar;

        public UI_ReturnCar()
        {
            ctlReturnCar = new CTL_ReturnCar();
        }

        /// <summary>
        /// Initiates the car return process.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        public void initiateCarReturn()
        {
            promptBookingID();
        }

        /// <summary>
        /// Prompts the user to enter their Booking ID.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        public void promptBookingID()
        {
            Console.Write("Please enter your Booking ID: ");
            enterBookingID();
        }

        /// <summary>
        /// Handles user input for Booking ID and validates it.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        public void enterBookingID()
        {
            int attempts = 0;
            const int maxAttempts = 3;

            while (attempts < maxAttempts)
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var (bookingDetails, validity) = ctlReturnCar.getBookingDetails(id);
                    if (validity)
                    {
                        displayBookingDetails(bookingDetails);
                        Console.WriteLine("Booking Found.");
                        continueReturn(bookingDetails);
                        return; // Exit the method as we have a valid booking
                    }
                    else
                    {
                        attempts++;
                        Console.WriteLine("Booking ID not found. Please try again.");
                        Console.WriteLine();
                        if (attempts < maxAttempts)
                        {
                            Console.Write("Please enter your Booking ID: ");
                        }
                    }
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Invalid Booking ID. Please enter a valid integer.");
                    Console.WriteLine();
                    if (attempts < maxAttempts)
                    {
                        Console.Write("Please enter your Booking ID: ");
                    }
                }
            }

            Console.WriteLine("Maximum attempts reached. Returning to Main Menu.");
        }

        /// <summary>
        /// Displays the details of the booking.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="b">The booking object.</param>
        public void displayBookingDetails(Booking b)
        {
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine($"             Booking {b.Id} Details");
            Console.WriteLine("===============================================");
            Console.WriteLine($"Booking ID:         {b.Id}");
            Console.WriteLine($"Car ID:             {b.Car.Id}");
            Console.WriteLine($"Return Location:    {b.ReturnLocation.Address}");
            Console.WriteLine($"Return End Date:    {b.ReturnTimeslots.First().EndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine("===============================================\n");
        }

        /// <summary>
        /// Prompts the user to continue with the return process.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="b">The booking object.</param>
        public void continueReturn(Booking b)
        {
            Console.Write("Do you want to continue with the return process? (Yes/No): ");
            string response = Console.ReadLine();
            if (response.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                var (returnDateTime, lateReturn) = ctlReturnCar.getReturnDateTime(b);
                Console.WriteLine();
                proceedWithReturn(returnDateTime, lateReturn, b.Id);
            }
            else
            {
                Console.WriteLine("Return process cancelled.");
            }
        }

        /// <summary>
        /// Proceeds with the return process and checks if the return is late.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="endDateTime">The return date and time.</param>
        /// <param name="lateReturn">Boolean indicating if the return is late.</param>
        /// <param name="id">The booking ID.</param>
        public void proceedWithReturn(DateTime endDateTime, bool lateReturn, int id)
        {
            if (lateReturn)
            {
                promptPayPenalty(endDateTime, id);
            }
            else
            {
                promptConfirmReturn(id);
            }
        }

        /// <summary>
        /// Inform the renter to pay a penalty if the return is late.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="endDateTime">The end date and time of the return timeslot.</param>
        /// <param name="id">The booking ID.</param>
        public void promptPayPenalty(DateTime endDateTime, int id)
        {
            Console.WriteLine($"Return is late. You were supposed to return the vehicle by {endDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine();
            payPenalty(id);
        }

        /// <summary>
        /// Handles the payment process for late returns.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="id">The booking ID.</param>
        public void payPenalty(int id)
        {
            Console.Write("Do you want to pay the penalty to complete the return? (Yes/No): ");
            string response = Console.ReadLine();
            Console.WriteLine();
            if (response.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                ctlReturnCar.processPayment(id); // Call the processPayment method in the controller
                promptConfirmReturn(id);
            }
            else
            {
                Console.WriteLine("Process cancelled. Ending use case.");
            }
        }

        public void promptConfirmReturn(int id)
        {
            Console.WriteLine("You may now continue to finalize the return.");
            Console.WriteLine();
            confirmReturn(id);
        }

        /// <summary>
        /// Renter confirms the return process and call function to update the booking status.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="id">The booking ID.</param>
        public void confirmReturn(int id)
        {
            Console.Write("Do you want to finalize the return? (Yes/No): ");
            string response = Console.ReadLine();
            Console.WriteLine();
            if (response.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                ctlReturnCar.updateBookingStatus(id, "Car Returned");
                var bookingDetails = ctlReturnCar.getBookingDetails(id); // Fetch the updated booking details
                displayBookingFinalized(bookingDetails.Item1);
            }
            else
            {
                Console.WriteLine("Process cancelled. Ending use case.");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays the finalized booking details with updated booking status.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="bookingDetails">The booking object with updated status.</param>
        public void displayBookingFinalized(Booking bookingDetails)
        {
            Console.WriteLine($"The car is successfully returned. Updated Booking Status: '{bookingDetails.Status}'.");
        }
    }

    
}

