using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    public class PickupLocation
    {
        private int id;
        private string address;
        private bool isAvailable;
        private int notOfLots;

        // Aggregate association with PickupTimeslot
        private List<PickupTimeslot> pickupTimeslots;

        public PickupLocation(int id, string address, bool isAvailable, int notOfLots)
        {
            this.id = id;
            this.address = address;
            this.isAvailable = isAvailable;
            this.notOfLots = notOfLots;
            this.pickupTimeslots = new List<PickupTimeslot>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }
        public int NotOfLots
        {
            get { return notOfLots; }
            set { notOfLots = value; }
        }
        public List<PickupTimeslot> PickupTimeslots
        {
            get { return pickupTimeslots; }
            set { pickupTimeslots = value; }
        }

        // Add a pickup timeslot to the PickupLocation
        public void AddPickupTimeslot(PickupTimeslot pickupTimeslot)
        {
            pickupTimeslots.Add(pickupTimeslot);
        }
    }
}
