using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    public class ICarAdmin : User
    {
        private bool verifiedBy;

        // Association with Car
        private List<Car> cars;

        public ICarAdmin(int id, string name, string email, string phoneNumber, string dob, bool verifiedBy)
            : base(id, name, email, phoneNumber, dob)
        {
            this.verifiedBy = verifiedBy;
            this.cars = new List<Car>();
        }

        public bool VerifiedBy
        {
            get { return verifiedBy; }
            set { verifiedBy = value; }
        }
        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        // Add a car to the ICarAdmin
        public void AddCar(Car car)
        {
            cars.Add(car);
        }
    }
}
