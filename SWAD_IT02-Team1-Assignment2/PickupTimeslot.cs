using System;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Yee Hen.
    /// Creator: Ong Yee Hen
    /// Student ID: S10258759D
    /// </summary>
    public class PickupTimeslot
    {
        private int id;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private bool isAvailable;
        private int carCount;

        public PickupTimeslot(int id, DateTime startDateTime, DateTime endDateTime, bool isAvailable, int carCount)
        {
            this.id = id;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.isAvailable = isAvailable;
            this.carCount = carCount;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }
        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }
        public int CarCount
        {
            get { return carCount; }
            set { carCount = value; }
        }
    }
}
