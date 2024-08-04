using System;
using System.Collections.Generic;

namespace SWAD_IT02_Team1_Assignment2
{
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
        private bool isAvailable;
        private Insurance insurance;
        private List<Photo> photos;
        private List<AvailabilitySchedule> availabilitySchedules;
        private CarOwner carOwner;

        public Car(int id, string make, string model, int year, decimal mileage, decimal rentalPrice, string numberPlate, bool isVerified, bool isAvailable, CarOwner carOwner)
        {
            this.id = id;
            this.make = make;
            this.model = model;
            this.year = year;
            this.mileage = mileage;
            this.rentalPrice = rentalPrice;
            this.numberPlate = numberPlate;
            this.isVerified = isVerified;
            this.isAvailable = isAvailable;
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
        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
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

        public void AddPhoto(Photo photo)
        {
            photos.Add(photo);
        }

        public void AddAvailabilitySchedule(AvailabilitySchedule availabilitySchedule)
        {
            availabilitySchedules.Add(availabilitySchedule);
        }

        public bool CheckCarAvailability(DateTime newStartDateTime, DateTime newEndDateTime)
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
