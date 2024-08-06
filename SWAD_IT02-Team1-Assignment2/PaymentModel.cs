using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_IT02_Team1_Assignment2
{
    public sealed class PaymentModel
    {
        private List<Payment> payments;
        private static PaymentModel instance = null;
        private int cardIdx = 2;

        private PaymentModel() 
        {
            // Create instances of Card and DigitalWallet
            DigitalWallet wallet1 = new DigitalWallet(1, 100.00m);
            Card card1 = new Card(1, "5520728801926284", "John Doe", new DateTime(2025, 12, 31), "Visa", "DBS");

            // Create instances of Payment
            payments = new List<Payment>
            {
                new Payment(1, 120.00m, "Credit Card", DateTime.Now, card1)
            };
               
        }

        public static PaymentModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentModel();
                }
                return instance;
            }
        }
        public Payment GetPayment(int id)
        {
            foreach (Payment payment in payments)
            {
                if (payment.Id == id)
                {
                    return payment;
                }
            }
            return null;
        }

        /// <summary>
        /// Create payment object after payment made.
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="amount">The amount to pay.</param>
        /// <returns>True if the update is successful, otherwise false.</returns> 
        public Payment MakePayment(decimal amount)
        {
            // Card
            Card card = new Card(cardIdx++, "5520728801926284", "John Doe", new DateTime(2025, 12, 31), "Visa", "DBS");

            // Payment
            Payment payment = new Payment(payments.Count, amount, "Credit Card", DateTime.Now, card);
            AddPayment(payment);

            payment.DisplayPaymentStatus(amount);
            return payment;
        }

        public int AddPayment(Payment payment)
        {
            payments.Add(payment);
            return payment.Id;
        }
    }
}
