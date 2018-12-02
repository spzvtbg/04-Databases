namespace Stations.Models
{
    using System.Collections.Generic;

    public class Train
    {
        public Train()
        {
            this.TrainSeats = new List<TrainSeat>();
            this.Trips = new List<Trip>();
        }

        //Id – integer, Primary Key
        public int Id { get; set; }

        //TrainNumber – text with max length 10 (required, unique)
        public string TrainNumber { get; set; }

        //Type – TrainType enumeration with possible values: HighSpeed, LongDistance or Freight (optional).
        public TrainType? Type { get; set; }

        //TrainSeats – Collection of type TrainSeat
        public ICollection<TrainSeat> TrainSeats { get; set; }

        //Trips – Collection of type Trip
        public ICollection<Trip> Trips { get; set; }
    }
}