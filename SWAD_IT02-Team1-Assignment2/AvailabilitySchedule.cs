using System;

namespace SWAD_IT02_Team1_Assignment2
{
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
