namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class User
    {
        private int id;
        private string name;
        private string email;
        private string phoneNumber;
        private string dob;

        public User(int id, string name, string email, string phoneNumber, string dob)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.dob = dob;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Dob
        {
            get { return dob; }
            set { dob = value; }
        }
    }
}
