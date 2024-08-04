using System;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class AvailabilitySchedule
    {
        private int id;
        private DateTime startDate;
        private DateTime endDate;

        public AvailabilitySchedule(int id, DateTime startDate, DateTime endDate)
        {
            this.id = id;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
    }
}
