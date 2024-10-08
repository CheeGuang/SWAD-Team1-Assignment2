﻿using System;
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
            displayAllBooking();
            promptBookingID();
        }

        /// <summary>
        /// Displays all booking details.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        public void displayAllBooking()
        {
            if (Program.Bookings.Count > 0)
            {
                foreach (var booking in Program.Bookings)
                {
                    Console.WriteLine("\n\n===============================================");
                    Console.WriteLine($"             Booking {booking.Id} Details");
                    Console.WriteLine("===============================================");
                    Console.WriteLine($"Booking ID:         {booking.Id}");
                    Console.WriteLine($"Car ID:             {booking.Car.Id}");
                    Console.WriteLine($"Start Date:         {booking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
                    Console.WriteLine($"End Date:           {booking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
                    Console.WriteLine($"Amount (SGD):       {booking.Amount}");
                    Console.WriteLine($"Pickup Location:    {booking.PickupLocation.Address}");
                    Console.WriteLine($"Return Location:    {booking.ReturnLocation.Address}");
                    Console.WriteLine($"Return End Date:    {booking.ReturnTimeslots.First().EndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
                    Console.WriteLine($"Status:             {booking.Status}");
                    Console.WriteLine("===============================================\n");
                }
            }
            else
            {
                Console.WriteLine("No bookings found.");
            }
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
        /// <param name="bookingDetails">The booking object.</param>
        public void displayBookingDetails(Booking bookingDetails)
        {
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine($"             Booking {bookingDetails.Id} Details");
            Console.WriteLine("===============================================");
            Console.WriteLine($"Booking ID:         {bookingDetails.Id}");
            Console.WriteLine($"Car ID:             {bookingDetails.Car.Id}");
            Console.WriteLine($"Return Location:    {bookingDetails.ReturnLocation.Address}");
            Console.WriteLine($"Return End Date:    {bookingDetails.ReturnTimeslots.First().EndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}");
            Console.WriteLine("===============================================\n");
        }

        /// <summary>
        /// Prompts the user to continue with the return process.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="bookingDetails">The booking object.</param>
        public void continueReturn(Booking bookingDetails)
        {
            Console.Write("Do you want to continue with the return process? (Yes/No): ");
            string response = Console.ReadLine();
            if (response.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                var (endDateTime, lateReturn) = ctlReturnCar.getReturnDateTime(bookingDetails);
                Console.WriteLine();
                proceedWithReturn(endDateTime, lateReturn, bookingDetails.Id);
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
                Console.WriteLine("Return is on time.");
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
            Console.Write("Press Enter to finalize the return: ");
            Console.ReadLine();
            Console.WriteLine();
            string newStatus = "Car Returned";

            ctlReturnCar.updateBookingStatus(id, newStatus);
            displayBookingFinalized(newStatus);
        }

        /// <summary>
        /// Displays the finalized booking details with updated booking status.
        /// Creator: Wang Po Yen Jason
        /// Student ID: S10255872A
        /// </summary>
        /// <param name="bookingDetails">The booking object with updated status.</param>
        public void displayBookingFinalized(string newStatus)
        {
            Console.WriteLine($"The car is successfully returned. Updated Booking Status: '{newStatus}'.");
        }
    }

    
}

