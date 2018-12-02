namespace FastFood.DataProcessor.Dto
{
    using System.Collections.Generic;

    public class OrderDto
    {
        public OrderDto()
        {
            this.Items = new List<ItemDto>();
        }

        public string Customer { get; set; }

        public string Employee { get; set; }

        public string DateTime { get; set; }

        public string Type { get; set; }

        public ICollection<ItemDto> Items { get; set; }
    }
}
