using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
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

        public Booking(int id, User user, Car car, DateTime rentStartDateTime, DateTime rentEndDateTime, decimal amount, Payment payment, PickupLocation pickupLocation, ReturnLocation returnLocation)
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

        public void AddPickupTimeslot(PickupTimeslot pickupTimeslot)
        {
            pickupTimeslots.Add(pickupTimeslot);
        }

        public void AddReturnTimeslot(ReturnTimeslot returnTimeslot)
        {
            returnTimeslots.Add(returnTimeslot);
        }

        public DateTime GetStartDateTime()
        {
            return rentStartDateTime;
        }

        public DateTime GetEndDateTime()
        {
            return rentEndDateTime;
        }

        public int GetCarId()
        {
            return car.Id;
        }
        public string GetRenterEmail()
        {
            return user.Email;
        }

        public string GetCarOwnerEmail()
        {
            return car.CarOwner.Email;
        }     
        
        public void ModifyBooking(DateTime newStartDateTime, DateTime newEndDateTime, PickupLocation newPickupLocation, ReturnLocation newReturnLocation, decimal newAmount)
        {
            this.RentStartDateTime = newStartDateTime;
            this.RentEndDateTime = newEndDateTime;
            this.PickupLocation = newPickupLocation;
            this.ReturnLocation = newReturnLocation;
            this.Amount = newAmount;            
        }
    }
}
