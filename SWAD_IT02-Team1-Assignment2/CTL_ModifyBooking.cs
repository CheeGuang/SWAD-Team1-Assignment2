using System;
using System.Collections.Generic;
using System.Linq;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class CTL_ModifyBooking
    {
        /// <summary>
        /// Enter updated booking details.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="updatedDetails">The updated booking details.</param>
        /// <param name="pickupLocations">The list of pickup locations.</param>
        /// <param name="returnLocations">The list of return locations.</param>
        /// <param name="booking">The booking to modify.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        public bool EnterUpdated(Dictionary<string, string> updatedDetails, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations, Booking booking)
        {
            bool isSuccessful = false;

            if (ValidateUpdatedBookingDetails(updatedDetails, pickupLocations, returnLocations))
            {
                DateTime originalStartDateTime = booking.GetStartDateTime();
                DateTime originalEndDateTime = booking.GetEndDateTime();

                DateTime newStartDateTime = DateTime.ParseExact(updatedDetails["newStartDateTime"], "dd/MM/yyyy h:mm:ss tt", null);
                DateTime newEndDateTime = DateTime.ParseExact(updatedDetails["newEndDateTime"], "dd/MM/yyyy h:mm:ss tt", null);
                
                Booking originalBooking = new Booking(
                    booking.Id,
                    booking.User,
                    booking.Car,
                    originalStartDateTime,
                    originalEndDateTime,
                    booking.Amount,
                    booking.Payment,
                    booking.PickupLocation,
                    booking.ReturnLocation,
                    booking.Status
                );


                decimal newAmount = booking.Amount;

                if (originalEndDateTime - originalStartDateTime >= newEndDateTime - newStartDateTime)
                {
                    isSuccessful = true;
                }
                else
                {
                    bool carIsAvailable = booking.Car.CheckCarAvailability(newStartDateTime, newEndDateTime);

                    if (carIsAvailable)
                    {
                        decimal additionalHours = (decimal)(newEndDateTime - newStartDateTime - (originalEndDateTime - originalStartDateTime)).TotalHours;
                        decimal paymentAmount = 5 * additionalHours;

                        while (true)
                        {
                            Console.WriteLine($"The total extra amount needed to pay is: ${paymentAmount}. It is $5 per additional hour.");
                            Console.Write("Do you want to proceed with the payment? (yes to confirm): ");
                            string userConfirmation = Console.ReadLine();

                            if (userConfirmation.ToLower() == "yes")
                            {
                                booking.Payment.DisplayPaymentStatus(paymentAmount);
                                newAmount += paymentAmount;
                                isSuccessful = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'yes' to confirm the payment.");
                            }
                        }

                    }
                    else
                    {
                        DisplayCarNotAvailableErrorMessage();
                        return false; // Early return to prevent further messages
                    }
                }

                if (isSuccessful)
                {
                    // Proceed with updating the booking using valid details
                    booking.ModifyBooking(newStartDateTime, newEndDateTime, pickupLocations.First(p => p.Id == int.Parse(updatedDetails["newPickupLocationId"])), returnLocations.First(r => r.Id == int.Parse(updatedDetails["newReturnLocationId"])), newAmount);

                    // Send confirmation emails
                    string renterEmail = booking.GetRenterEmail();
                    string carOwnerEmail = booking.GetCarOwnerEmail();
                    EmailSystem.SendConfirmationEmail(renterEmail, booking.User.Name, originalBooking, booking);
                    Console.WriteLine("Renter confirmation email sent successfully.");

                    EmailSystem.SendConfirmationEmail(carOwnerEmail, booking.Car.CarOwner.Name, originalBooking, booking);
                    Console.WriteLine("Car Owner confirmation email sent successfully.");
                }
                else
                {
                    DisplayGenericErrorMessage();
                    return false; // Early return to prevent further messages
                }
            }
            else
            {
                DisplayGenericErrorMessage();
                return false; // Early return to prevent further messages
            }

            return isSuccessful;
        }

        /// <summary>
        /// Validates the updated booking details.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="updatedDetails">The updated booking details.</param>
        /// <param name="pickupLocations">The list of pickup locations.</param>
        /// <param name="returnLocations">The list of return locations.</param>
        /// <returns>True if the details are valid, otherwise false.</returns>
        public bool ValidateUpdatedBookingDetails(Dictionary<string, string> updatedDetails, List<PickupLocation> pickupLocations, List<ReturnLocation> returnLocations)
        {
            DateTime newStartDateTime;
            DateTime newEndDateTime;
            int newPickupLocationId;
            int newReturnLocationId;

            if (!DateTime.TryParseExact(updatedDetails["newStartDateTime"], "dd/MM/yyyy h:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out newStartDateTime))
            {
                Console.WriteLine("Invalid Start DateTime format.");
                return false;
            }

            if (!DateTime.TryParseExact(updatedDetails["newEndDateTime"], "dd/MM/yyyy h:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out newEndDateTime))
            {
                Console.WriteLine("Invalid End DateTime format.");
                return false;
            }

            if (newEndDateTime <= newStartDateTime)
            {
                Console.WriteLine("End DateTime must be after Start DateTime.");
                return false;
            }

            if (!int.TryParse(updatedDetails["newPickupLocationId"], out newPickupLocationId))
            {
                Console.WriteLine("Invalid Pickup Location ID format.");
                return false;
            }

            if (!int.TryParse(updatedDetails["newReturnLocationId"], out newReturnLocationId))
            {
                Console.WriteLine("Invalid Return Location ID format.");
                return false;
            }

            bool pickupLocationExists = pickupLocations.Any(p => p.Id == newPickupLocationId);
            bool returnLocationExists = returnLocations.Any(r => r.Id == newReturnLocationId);

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
        /// Displays an error message when the car is not available.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        public void DisplayCarNotAvailableErrorMessage()
        {
            Console.WriteLine("The car is not available for the selected time period.");
        }

        /// <summary>
        /// Displays a generic error message.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        public void DisplayGenericErrorMessage()
        {
            Console.WriteLine("An error occurred while updating the booking. Please try again.");
        }
    }
}
