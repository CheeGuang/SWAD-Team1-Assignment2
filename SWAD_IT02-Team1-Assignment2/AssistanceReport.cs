﻿using System;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class AssistanceReport
    {
        private int id;
        private string description;
        private DateTime dateTime;

        public AssistanceReport(int id, string description, DateTime dateTime)
        {
            this.id = id;
            this.description = description;
            this.dateTime = dateTime;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
    }
}
