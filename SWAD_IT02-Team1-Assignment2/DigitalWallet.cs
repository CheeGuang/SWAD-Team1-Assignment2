namespace SWAD_IT02_Team1_Assignment2
{
    public class DigitalWallet
    {
        private int id;
        private decimal balance;

        public DigitalWallet(int id, decimal balance)
        {
            this.id = id;
            this.balance = balance;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
    }
}
