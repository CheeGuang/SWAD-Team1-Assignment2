﻿using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Yee Hen.
    /// Creator: Ong Yee Hen
    /// Student ID: S10258759D
    /// </summary>
    public class ReturnLocation
    {
        private int id;
        private string address;
        private bool isAvailable;
        private int notOfLots;

        // Aggregate association with ReturnTimeslot
        private List<ReturnTimeslot> returnTimeslots;

        public ReturnLocation(int id, string address, bool isAvailable, int notOfLots)
        {
            this.id = id;
            this.address = address;
            this.isAvailable = isAvailable;
            this.notOfLots = notOfLots;
            this.returnTimeslots = new List<ReturnTimeslot>();
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
        public List<ReturnTimeslot> ReturnTimeslots
        {
            get { return returnTimeslots; }
            set { returnTimeslots = value; }
        }
    }
}
