using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Sian Kim.
    /// Creator: Cing Sian Kim
    /// Student ID: S10257716F
    /// </summary>
    public class CarOwner : User
    {
        private decimal digitalWalletAmount;
        private decimal earning;

        // Association with Car
        private List<Car> cars;

        public CarOwner(int id, string name, string email, string phoneNumber, string dob, decimal digitalWalletAmount, decimal earning)
            : base(id, name, email, phoneNumber, dob)
        {
            this.digitalWalletAmount = digitalWalletAmount;
            this.earning = earning;
            this.cars = new List<Car>();
        }

        public decimal DigitalWalletAmount
        {
            get { return digitalWalletAmount; }
            set { digitalWalletAmount = value; }
        }
        public decimal Earning
        {
            get { return earning; }
            set { earning = value; }
        }
        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }


        /// <summary>
        /// Adds a car to the CarOwner.
        /// Creator: Cing Sian Kim
        /// Student ID: S10257716F
        /// </summary>
        /// <param name="car">The car to add.</param>
        public void addCar(Car car)
        {
            cars.Add(car);
        }
    }
}
