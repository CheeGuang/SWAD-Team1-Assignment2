using System;
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
        // Global Libraries for Random
        Random random = new Random();

        /// <summary>
        /// Create new booking object.
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="car">The car selected.</param>
        /// <param name="renter">The renter making the booking.</param>
        /// <param name="pickupTimeslot">The pickup timeslot selected.</param>
        /// <param name="returnTimeslot">The return timeslot selected.</param>
        /// <param name="amount">The amount to pay.</param>
        /// <param name="payment">The payment details.</param>
        /// <param name="pickupLocation">The pickup location selected.</param>
        /// <param name="returnLocation">The return location selected.</param>
        /// <returns>True if the update is successful, otherwise false.</returns> 
        public bool CreateBooking(int id, Renter renter, Car car, DateTime pickupTimeslot, DateTime returnTimeslot, decimal amount, Payment payment, PickupLocation pickupLocation, ReturnLocation returnLocation)
        {
            try
            {
                Booking booking = new Booking(id, renter, car, pickupTimeslot, returnTimeslot, amount, payment, pickupLocation, returnLocation);
                renter.AddBooking(booking);
                return true;
            } catch
            {
                // If booking fails
                return false;
            }
           
        }

        /// <summary>
        /// Create payment object after payment made.
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="amount">The amount to pay.</param>
        /// <param name="method">The payment method.</param>
        /// <param name="paymentDateTime">The date and time of payment.</param>
        /// <param name="cardNumber">The selected card number.</param>
        /// <param name="cardHolderName">The name of the card holder.</param>
        /// <param name="cardExpiryDate">The expiary date of the card selected.</param>
        /// <param name="cardType">The type of card selected.</param>
        /// <param name="bankCompany">The bank company of the card.</param>
        /// <returns>True if the update is successful, otherwise false.</returns> 
        public Payment RegisterPayment(decimal amount, string method, DateTime paymentDateTime, string cardNumber, string cardHolderName, DateTime cardExpiryDate, string cardType, string bankCompany)
        {
            // Card
            int cardId = random.Next(0, 999999);
            Card card = new Card(cardId, cardNumber, cardHolderName, cardExpiryDate, cardType, bankCompany);

            // Payment
            int paymentId = random.Next(0, 999999);
            Payment payment = new Payment(paymentId, amount, method, paymentDateTime, card);
            payment.MakePayment(amount);
            return payment;
        }
    }
}
