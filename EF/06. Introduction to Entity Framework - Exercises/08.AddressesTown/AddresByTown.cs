namespace _08.AddressesTown
{
    using System;
    using System.Linq;

    using P02_DatabaseFirst.Data;
    using Microsoft.EntityFrameworkCore;

    public class AddresByTown
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var addresses = context.Addresses
                    .Include(e => e.Employees)
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Select(a => new { a.AddressText, a.Town.Name, a.Employees.Count })
                    .Take(10);

                foreach (var address in addresses)
                {
                    Console.WriteLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
                }
            }
        }
    }
}
