using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class Accident
    {
        private int id;
        private string description;
        private DateTime dateTime;
        private bool requiresAssistance;

        // Association with AssistanceReport
        private List<AssistanceReport> assistanceReports;

        public Accident(int id, string description, DateTime dateTime, bool requiresAssistance)
        {
            this.id = id;
            this.description = description;
            this.dateTime = dateTime;
            this.requiresAssistance = requiresAssistance;
            this.assistanceReports = new List<AssistanceReport>();
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
        public bool RequiresAssistance
        {
            get { return requiresAssistance; }
            set { requiresAssistance = value; }
        }
        public List<AssistanceReport> AssistanceReports
        {
            get { return assistanceReports; }
            set { assistanceReports = value; }
        }

        /// <summary>
        /// Adds an assistance report to the Accident.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        public void AddAssistanceReport(AssistanceReport assistanceReport)
        {
            assistanceReports.Add(assistanceReport);
        }
    }
}
