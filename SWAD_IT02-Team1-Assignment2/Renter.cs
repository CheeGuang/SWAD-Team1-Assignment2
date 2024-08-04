using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class Renter : User
    {
        private string driverLicenseNumber;
        private decimal monthlyRentalFee;
        private decimal digitalWalletAmount;
        private bool isPrime;
        private bool isVerified;

        // Association with Booking
        private List<Booking> bookings;

        public Renter(int id, string name, string email, string phoneNumber, string dob, string driverLicenseNumber, decimal monthlyRentalFee, decimal digitalWalletAmount, bool isPrime, bool isVerified)
            : base(id, name, email, phoneNumber, dob)
        {
            this.driverLicenseNumber = driverLicenseNumber;
            this.monthlyRentalFee = monthlyRentalFee;
            this.digitalWalletAmount = digitalWalletAmount;
            this.isPrime = isPrime;
            this.isVerified = isVerified;
            this.bookings = new List<Booking>();
        }

        public string DriverLicenseNumber
        {
            get { return driverLicenseNumber; }
            set { driverLicenseNumber = value; }
        }
        public decimal MonthlyRentalFee
        {
            get { return monthlyRentalFee; }
            set { monthlyRentalFee = value; }
        }
        public decimal DigitalWalletAmount
        {
            get { return digitalWalletAmount; }
            set { digitalWalletAmount = value; }
        }
        public bool IsPrime
        {
            get { return isPrime; }
            set { isPrime = value; }
        }
        public bool IsVerified
        {
            get { return isVerified; }
            set { isVerified = value; }
        }
        public List<Booking> Bookings
        {
            get { return bookings; }
            set { bookings = value; }
        }


        /// <summary>
        /// Adds a booking to the Renter.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="booking">The booking to add.</param>
        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
        }
    }
}
