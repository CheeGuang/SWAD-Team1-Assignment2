using System;

namespace SWAD_IT02_Team1_Assignment2
{
    public class Insurance
    {
        private int id;
        private decimal coverage;
        private Car car;
        private DateTime validityPeriod;

        public Insurance(int id, decimal coverage, Car car, DateTime validityPeriod)
        {
            this.id = id;
            this.coverage = coverage;
            this.car = car;
            this.validityPeriod = validityPeriod;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public decimal Coverage
        {
            get { return coverage; }
            set { coverage = value; }
        }
        public Car Car
        {
            get { return car; }
            set { car = value; }
        }
        public DateTime ValidityPeriod
        {
            get { return validityPeriod; }
            set { validityPeriod = value; }
        }
    }
}
