﻿using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class Car
    {
        private int id;
        private string make;
        private string model;
        private int year;
        private decimal mileage;
        private decimal rentalPrice;
        private string numberPlate;
        private bool isVerified;
        private Insurance insurance;
        private List<Photo> photos;
        private List<AvailabilitySchedule> availabilitySchedules;
        private CarOwner carOwner;

        public Car(int id, string make, string model, int year, decimal mileage, decimal rentalPrice, string numberPlate, bool isVerified, CarOwner carOwner)
        {
            this.id = id;
            this.make = make;
            this.model = model;
            this.year = year;
            this.mileage = mileage;
            this.rentalPrice = rentalPrice;
            this.numberPlate = numberPlate;
            this.isVerified = isVerified;
            this.photos = new List<Photo>();
            this.availabilitySchedules = new List<AvailabilitySchedule>();
            this.carOwner = carOwner;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public decimal Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        public decimal RentalPrice
        {
            get { return rentalPrice; }
            set { rentalPrice = value; }
        }
        public string NumberPlate
        {
            get { return numberPlate; }
            set { numberPlate = value; }
        }
        public bool IsVerified
        {
            get { return isVerified; }
            set { isVerified = value; }
        }
        public Insurance Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }
        public List<Photo> Photos
        {
            get { return photos; }
            set { photos = value; }
        }
        public List<AvailabilitySchedule> AvailabilitySchedules
        {
            get { return availabilitySchedules; }
            set { availabilitySchedules = value; }
        }
        public CarOwner CarOwner
        {
            get { return carOwner; }
            set { carOwner = value; }
        }

        /// <summary>
        /// Adds a photo to the Car.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="photo">The photo to add.</param>
        public void addPhoto(Photo photo)
        {
            photos.Add(photo);
        }

        /// <summary>
        /// Adds an availability schedule to the Car.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="availabilitySchedule">The availability schedule to add.</param>
        public void addAvailabilitySchedule(AvailabilitySchedule availabilitySchedule)
        {
            availabilitySchedules.Add(availabilitySchedule);
        }

        /// <summary>
        /// Checks the car availability for a given time period.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="newStartDateTime">The start date and time for the check.</param>
        /// <param name="newEndDateTime">The end date and time for the check.</param>
        /// <returns>True if the car is available, otherwise false.</returns>
        public bool checkCarAvailability(DateTime newStartDateTime, DateTime newEndDateTime)
        {
            foreach (var schedule in availabilitySchedules)
            {
                if (newStartDateTime >= schedule.StartDate && newEndDateTime <= schedule.EndDate)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
