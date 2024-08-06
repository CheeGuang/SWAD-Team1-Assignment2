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
    public class Booking
    {
        private int id;
        private User user;
        private Car car;
        private DateTime rentStartDateTime;
        private DateTime rentEndDateTime;
        private decimal amount;
        private Payment payment;
        private PickupLocation pickupLocation;
        private ReturnLocation returnLocation;
        private List<PickupTimeslot> pickupTimeslots;
        private List<ReturnTimeslot> returnTimeslots;
        private string status;

        public Booking(int id, User user, Car car, DateTime rentStartDateTime, DateTime rentEndDateTime, decimal amount, Payment payment, PickupLocation pickupLocation, ReturnLocation returnLocation, string status)
        {
            this.id = id;
            this.user = user;
            this.car = car;
            this.rentStartDateTime = rentStartDateTime;
            this.rentEndDateTime = rentEndDateTime;
            this.amount = amount;
            this.payment = payment;
            this.pickupLocation = pickupLocation;
            this.returnLocation = returnLocation;
            this.pickupTimeslots = new List<PickupTimeslot>();
            this.returnTimeslots = new List<ReturnTimeslot>();
            this.status = status;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        public Car Car
        {
            get { return car; }
            set { car = value; }
        }
        public DateTime RentStartDateTime
        {
            get { return rentStartDateTime; }
            set { rentStartDateTime = value; }
        }
        public DateTime RentEndDateTime
        {
            get { return rentEndDateTime; }
            set { rentEndDateTime = value; }
        }
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public Payment Payment
        {
            get { return payment; }
            set { payment = value; }
        }
        public PickupLocation PickupLocation
        {
            get { return pickupLocation; }
            set { pickupLocation = value; }
        }
        public ReturnLocation ReturnLocation
        {
            get { return returnLocation; }
            set { returnLocation = value; }
        }
        public List<PickupTimeslot> PickupTimeslots
        {
            get { return pickupTimeslots; }
            set { pickupTimeslots = value; }
        }
        public List<ReturnTimeslot> ReturnTimeslots
        {
            get { return returnTimeslots; }
            set { returnTimeslots = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Adds a pickup timeslot to the Booking.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        public void AddPickupTimeslot(PickupTimeslot pickupTimeslot)
        {
            pickupTimeslots.Add(pickupTimeslot);
        }

        /// <summary>
        /// Adds a return timeslot to the Booking.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        public void AddReturnTimeslot(ReturnTimeslot returnTimeslot)
        {
            returnTimeslots.Add(returnTimeslot);
        }

        /// <summary>
        /// Gets the start date and time of the Booking.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <returns>The start date and time.</returns>
        public DateTime GetStartDateTime()
        {
            return rentStartDateTime;
        }

        /// <summary>
        /// Gets the end date and time of the Booking.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <returns>The end date and time.</returns>
        public DateTime GetEndDateTime()
        {
            return rentEndDateTime;
        }

        /// <summary>
        /// Gets the renter's email of the Booking.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <returns>The renter's email.</returns>
        public string GetRenterEmail()
        {
            return user.Email;
        }

        /// <summary>
        /// Gets the car owner's email of the Booking.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <returns>The car owner's email.</returns>
        public string GetCarOwnerEmail()
        {
            return car.CarOwner.Email;
        }

        /// <summary>
        /// Modifies the booking details.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        public void ModifyBooking(DateTime newStartDateTime, DateTime newEndDateTime, PickupLocation newPickupLocation, ReturnLocation newReturnLocation, decimal newAmount)
        {
            this.RentStartDateTime = newStartDateTime;
            this.RentEndDateTime = newEndDateTime;
            this.PickupLocation = newPickupLocation;
            this.ReturnLocation = newReturnLocation;
            this.Amount = newAmount;            
        }

        /// <summary>
        /// Get the booking details using the booking ID.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        public static Booking getBookingDetails(int id)
        {
            return Program.Bookings.FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// Update the booking status.
        /// Creator: Ong Yee Hen
        /// Student ID: S10258759D
        /// </summary>
        public void updateBookingStatus(string newStatus)
        {
            this.status = newStatus;
        }
    }
}
