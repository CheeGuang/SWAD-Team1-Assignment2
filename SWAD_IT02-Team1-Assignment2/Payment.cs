using System;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Raeanne.
    /// Creator: Zou Ruining, Raeanne
    /// Student ID: S10258772G
    /// </summary>
    public class Payment
    {
        private int id;
        private decimal amount;
        private string method;
        private DateTime dateTime;

        // Association with Card
        private Card card;

        public Payment(int id, decimal amount, string method, DateTime dateTime, Card card)
        {
            this.id = id;
            this.amount = amount;
            this.method = method;
            this.dateTime = dateTime;
            this.card = card;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string Method
        {
            get { return method; }
            set { method = value; }
        }
        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        public Card Card
        {
            get { return card; }
            set { card = value; }
        }

        /// <summary>
        /// Makes a payment of the specified amount.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="paymentAmount">The amount to pay.</param>
        public void MakePayment(decimal paymentAmount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nPayment ${paymentAmount} successful.");
            Console.ResetColor();
        }
    }
}
