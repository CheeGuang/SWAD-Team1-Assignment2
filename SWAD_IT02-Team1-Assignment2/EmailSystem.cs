using System;
using System.Net.Mail;
using System.Net;

namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class EmailSystem
    {
        /// <summary>
        /// Sends a confirmation email.
        /// Creator: Lee Guang Le, Jeffrey
        /// Student ID: S10258143A
        /// </summary>
        /// <param name="receiverEmail">The receiver's email address.</param>
        /// <param name="userName">The user's name.</param>
        /// <param name="originalBooking">The original booking details.</param>
        /// <param name="updatedBooking">The updated booking details.</param>
        static public void SendConfirmationEmail(string receiverEmail, string userName, Booking originalBooking, Booking updatedBooking)
        {
            // Sender Email Details
            string fromMail = "jeffreyleeprg2@gmail.com";
            string fromPassword = "cuhmvmdqllulsucg";
            string senderName = "ICar Car Rental Service";

            // Initialising and configuring message object
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail, senderName);
            message.Subject = "ICar Car Rental Service Booking Confirmation";
            try
            {
                message.To.Add(new MailAddress(receiverEmail));
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }

            message.Body = $@"
    <html>
        <body>
            <h1>ICar Car Rental Service Booking Confirmation</h1>
            <p>Dear {userName},</p>
            <p>Your booking has been successfully updated. Below are the details of your original and updated booking:</p>
            
            <h2>Original Booking Details</h2>
            <ul>
                <li>Booking ID: {originalBooking.Id}</li>
                <li>Car: {originalBooking.Car.Make} {originalBooking.Car.Model} ({originalBooking.Car.Year})</li>
                <li>Start Date: {originalBooking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}</li>
                <li>End Date: {originalBooking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}</li>
                <li>Pickup Location: {originalBooking.PickupLocation.Address}</li>
                <li>Return Location: {originalBooking.ReturnLocation.Address}</li>
                <li>Amount: {originalBooking.Amount:C}</li>
            </ul>
            
            <h2>Updated Booking Details</h2>
            <ul>
                <li>Booking ID: {updatedBooking.Id}</li>
                <li>Car: {updatedBooking.Car.Make} {updatedBooking.Car.Model} ({updatedBooking.Car.Year})</li>
                <li>Start Date: {updatedBooking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}</li>
                <li>End Date: {updatedBooking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}</li>
                <li>Pickup Location: {updatedBooking.PickupLocation.Address}</li>
                <li>Return Location: {updatedBooking.ReturnLocation.Address}</li>
                <li>Amount: {updatedBooking.Amount:C}</li>
            </ul>
            
            <p>Thank you for choosing ICar Car Rental Service!</p>
            <p>If you have any questions or need further assistance, please don't hesitate to contact our support team at jeffreyleeprg2@gmail.com.</p>
            <p>Best regards,<br>ICar Car Rental Service Team</p>
        </body>
    </html>";

            message.IsBodyHtml = true;

            // Setting up Simple Mail Transfer Protocol client to send the Email
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            // Sending Email
            smtpClient.Send(message);

            // Display Confirmation Message
            Console.WriteLine();
            Console.WriteLine("Confirmation Email Sent!!");
            Console.WriteLine();
        }

        /// <summary>
        /// Sends a confirmation email after successful booking creation.
        /// Creator: Zou Ruining, Raeanne
        /// Student ID: S10258772G
        /// </summary>
        /// <param name="receiverEmail">The receiver's email address.</param>
        /// <param name="userName">The user's name.</param>
        /// <param name="booking">The original booking details.</param>
        static public void SendBookingConfirmationEmail(string receiverEmail, string userName, Booking booking)
        {
            // Sender Email Details
            string fromMail = "jeffreyleeprg2@gmail.com";
            string fromPassword = "cuhmvmdqllulsucg";
            string senderName = "ICar Car Rental Service";

            // Initialising and configuring message object
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail, senderName);
            message.Subject = "ICar Car Rental Service Booking Confirmation";
            try
            {
                message.To.Add(new MailAddress(receiverEmail));
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }

            message.Body = $@"
    <html>
        <body>
            <h1>ICar Car Rental Service Booking Confirmation</h1>
            <p>Dear {userName},</p>
            <p>You have successfully made a booking. Below are the details of your booking:</p>
            
            <h2>Original Booking Details</h2>
            <ul>
                <li>Booking ID: {booking.Id}</li>
                <li>Car: {booking.Car.Make} {booking.Car.Model} ({booking.Car.Year})</li>
                <li>Start Date: {booking.RentStartDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}</li>
                <li>End Date: {booking.RentEndDateTime.ToString("dd/MM/yyyy h:mm:ss tt")}</li>
                <li>Pickup Location: {booking.PickupLocation.Address}</li>
                <li>Return Location: {booking.ReturnLocation.Address}</li>
                <li>Amount: {booking.Amount:C}</li>
            </ul>
            
            <p>Thank you for choosing ICar Car Rental Service!</p>
            <p>If you have any questions or need further assistance, please don't hesitate to contact our support team at jeffreyleeprg2@gmail.com.</p>
            <p>Best regards,<br>ICar Car Rental Service Team</p>
        </body>
    </html>";

            message.IsBodyHtml = true;

            // Setting up Simple Mail Transfer Protocol client to send the Email
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            // Sending Email
            smtpClient.Send(message);

            // Display Confirmation Message
            Console.WriteLine();
            Console.WriteLine("Confirmation Email Sent!");
            Console.WriteLine();
        }
    }
}
