namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Sian Kim.
    /// Creator: Cing Sian Kim
    /// Student ID: S10257716F
    /// </summary>
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
