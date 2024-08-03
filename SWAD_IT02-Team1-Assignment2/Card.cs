using System;

namespace SWAD_IT02_Team1_Assignment2
{
    public class Card
    {
        private int id;
        private string number;
        private string holderName;
        private DateTime expiryDate;
        private string type;
        private string bankCompany;


        public Card(int id, string number, string holderName, DateTime expiryDate, string type, string bankCompany)
        {
            this.id = id;
            this.number = number;
            this.holderName = holderName;
            this.expiryDate = expiryDate;
            this.type = type;
            this.bankCompany = bankCompany;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string HolderName
        {
            get { return holderName; }
            set { holderName = value; }
        }
        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string BankCompany
        {
            get { return bankCompany; }
            set { bankCompany = value; }
        }
    }
}
