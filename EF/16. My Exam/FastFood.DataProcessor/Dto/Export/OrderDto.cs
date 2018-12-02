using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataProcessor.Dto.Export
{
    public class OrderDto
    {
        public string Customer { get; set; }

        public ICollection<ItemsDto> Items { get; set; } = new List<ItemsDto>();

        public decimal TotalPrice { get; set; }
    }
}
