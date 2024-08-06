using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    internal class Program
    {
        public static List<Booking> Bookings = new List<Booking>();

        private static Renter dummyRenter;
        private static CarOwner dummyCarOwner;
        private static ICarAdmin dummyICarAdmin;
        private static List<PickupLocation> pickupLocations;
        private static List<ReturnLocation> returnLocations;

        static void Main(string[] args)
        {
            // Adding dummy data
            AddDummyData();

            // Main menu
            UI_Main uiMain = new UI_Main();
            uiMain.MainMenu(dummyRenter, dummyCarOwner, dummyICarAdmin, pickupLocations, returnLocations);
        }

        /// <summary>
        /// Function to add dummy data for testing purposes.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        public static void AddDummyData()
        {
            // Initialize existing variables
            dummyCarOwner = new CarOwner(1, "Benjamin Lau", "s10258143@connect.np.edu.sg", "0987654321", "1985-02-02", 100.0m, 500.0m);
            dummyRenter = new Renter(1, "Jeffrey Lee", "s10258143@connect.np.edu.sg", "1122334455", "1992-03-03", "DL123456", 50.0m, 200.0m, true, true);
            dummyICarAdmin = new ICarAdmin(1, "Emily Tan", "emilytan@example.com", "6677889900", "1988-04-04", true);

            // Create instance of Car
            Car dummyCar = new Car(1, "Toyota", "Camry", 2020, 15000.0m, 50.0m, "SGX1234A", true, dummyCarOwner);

            // Create instance of Insurance
            Insurance dummyInsurance = new Insurance(1, 10000.0m, dummyCar, new DateTime(2024, 12, 31));
            dummyCar.Insurance = dummyInsurance;

            // Create instance of Photo
            Photo dummyPhoto = new Photo(1, "Front View", "http://example.com/front.jpg");
            dummyCar.AddPhoto(dummyPhoto);

            // Create instance of AvailabilitySchedule
            AvailabilitySchedule dummySchedule = new AvailabilitySchedule(1, new DateTime(2024, 08, 01), new DateTime(2024, 08, 31));
            dummyCar.AddAvailabilitySchedule(dummySchedule);

            // Initialize locations list
            pickupLocations = new List<PickupLocation>
            {
                new PickupLocation(1, "123 Orchard Road", true, 10),
                new PickupLocation(2, "456 Bukit Timah Road", true, 20),
                new PickupLocation(3, "789 iCar Station", true, 30)
            };

            returnLocations = new List<ReturnLocation>
            {
                new ReturnLocation(1, "123 Orchard Road", true, 10),
                new ReturnLocation(2, "456 Bukit Timah Road", true, 20),
                new ReturnLocation(3, "789 iCar Station", true, 30)
            };

            // Create instances of Card and DigitalWallet
            DigitalWallet wallet1 = new DigitalWallet(1, 100.00m);
            Card card1 = new Card(1, "5520728801926284", "John Doe", new DateTime(2025, 12, 31), "Visa", "DBS");

            // Create instances of Payment
            Payment payment1 = new Payment(1, 120.00m, "Credit Card", DateTime.Now, card1);

            // Create instances of PickupTimeslot
            PickupTimeslot pickupTimeslot1 = new PickupTimeslot(1, new DateTime(2024, 08, 05, 20, 0, 0), new DateTime(2024, 08, 05, 23, 0, 0), true, 1);
            PickupTimeslot pickupTimeslot2 = new PickupTimeslot(1, new DateTime(2024, 08, 10, 20, 0, 0), new DateTime(2024, 08, 10, 23, 0, 0), true, 1);

            // Create instances of Booking
            Booking booking1 = new Booking(1, dummyRenter, dummyCar, new DateTime(2024, 08, 01, 9, 0, 0), new DateTime(2024, 08, 02, 9, 0, 0), 120.00m, payment1, pickupLocations[0], returnLocations[0], "Created Successfully");
            Booking booking2 = new Booking(2, dummyRenter, dummyCar, new DateTime(2024, 08, 07, 9, 0, 0), new DateTime(2024, 08, 12, 9, 0, 0), 120.00m, payment1, pickupLocations[0], returnLocations[0], "Created Successfully");


            booking1.PickupTimeslots.Add(pickupTimeslot1);
            booking2.PickupTimeslots.Add(pickupTimeslot2);

            Bookings.Add(booking1);
            Bookings.Add(booking2);


            // Add bookings to renter
            dummyRenter.AddBooking(booking1);
            dummyRenter.AddBooking(booking2);

            // Create instances of Accident and AssistanceReport
            Accident accident1 = new Accident(1, "Minor collision", new DateTime(2024, 07, 01, 10, 0, 0), true);
            AssistanceReport report1 = new AssistanceReport(1, "Assistance required", new DateTime(2024, 07, 01, 10, 30, 0));
            accident1.AddAssistanceReport(report1);
        }
    }
}
