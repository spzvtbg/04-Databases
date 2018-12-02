namespace Stations.Models
{
    public class TrainSeat
    {
        //Id – integer, Primary Key
        public int Id { get; set; }

        //TrainId – integer(required)
        public int TrainId { get; set; }

        //Train – train whose seats will be described(required)
        public Train Train { get; set; }

        //SeatingClassId – integer(required)
        public int SeatingClassId { get; set; }

        //SeatingClass – class of the seats(required)
        public SeatingClass SeatingClass { get; set; }

        //Quantity – how many seats of given class total for the given train(required, non-negative)
        public int Quantity { get; set; }
    }
}                  