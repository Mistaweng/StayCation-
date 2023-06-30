namespace StayCation.Models
{
    public class Property
    {
        public Property(string location, string propName, string price, string pic, string group, string popularity)
        {
            Location = location;
            PropName = propName;
            Price = price;
            Pic = pic;
            this.group = group;
            this.popularity = popularity;
        }

        public string Location { get; set; }
        public string PropName { get; set; }
        public string Price { get; set; }
        public string Pic { get; set; }
        public string group { get; set; }
        public string popularity { get; set; }




    }
}
