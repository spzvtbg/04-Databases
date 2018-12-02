namespace Stations.Models
{
    using System;
    using System.Collections.Generic;

    public class Trip
    {
        public Trip()
        {
            this.BoughtTripTickets = new List<Ticket>();
        }

        //Id – integer, Primary Key
        public int Id { get; set; }

        //OriginStationId – integer(required)
        public int OriginStationId { get; set; }

        //OriginStation – station from which the trip begins(required)
        public Station OriginStation { get; set; }

        //DestinationStation Id – integer(required)
        public int DestinationStationId { get; set; }

        //DestinationStation – station where the trip ends(required)
        public Station DestinationStation { get; set; }

        //DepartureTime – date and time of departure from origin station(required)
        public DateTime DepartureTime { get; set; }

        //ArrivalTime – date and time of arrival at destination station, must be after departure time(required)
        public DateTime ArrivalTime { get; set; }

        //TrainId – integer(required)
        public int TrainId { get; set; }

        //Train – train used for that particular trip(required)
        public Train Train { get; set; }

        //Status – TripStatus enumeration with possible values: OnTime, Delayed and Early(default:OnTime)
        public TripStatus Status { get; set; } = TripStatus.OnTime;

        //TimeDifference – time(span) representing how late or early a given train was(optional)
        public TimeSpan? TimeDifference { get; set; }

        public ICollection<Ticket> BoughtTripTickets { get; set; }
    }
}