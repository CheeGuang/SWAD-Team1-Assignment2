namespace SWAD_IT02_Team1_Assignment2
{
    /// <summary>
    /// Creation of class according to class diagram done by Jeffrey.
    /// Creator: Lee Guang Le, Jeffrey
    /// Student ID: S10258143A
    /// </summary>
    public class Photo
    {
        private int id;
        private string caption;
        private string url;

        public Photo(int id, string caption, string url)
        {
            this.id = id;
            this.caption = caption;
            this.url = url;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
    }
}
