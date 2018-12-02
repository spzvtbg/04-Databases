namespace Stations.Models
{
    using System.Collections.Generic;

    public class Station
    {
        public Station()
        {
            this.TripsTo = new List<Trip>();
            this.TripsFrom = new List<Trip>();
        }

        public int Id { get; set; }

        public string Name { get; set; } //text with max length 50 (required, unique)

        public string Town { get; set; } //text with max length 50 (required)

        public ICollection<Trip> TripsTo { get; set; }

        public ICollection<Trip> TripsFrom { get; set; }
    }
}
