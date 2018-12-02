namespace Stations.Models
{
    using System.Collections.Generic;

    public class SeatingClass
    {
        public SeatingClass()
        {
            this.TrainSeats = new List<TrainSeat>();
        }

        //Id – integer, Primary Key
        public int Id { get; set; }

        //Name – text with max length 30 (required, unique)
        public string Name { get; set; }

        //Abbreviation – text with an exact length of 2 (no more, no less), (required, unique)
        public string Abbreviation { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; }
    }
}