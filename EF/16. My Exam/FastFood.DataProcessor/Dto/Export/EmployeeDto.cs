using System.Collections.Generic;

namespace FastFood.DataProcessor.Dto.Export
{
    public class EmployeeDto
    {
        public string Name { get; set; }

        public ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }
}
