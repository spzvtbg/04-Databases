namespace _15._Remove_Towns
{
    using System;
    using System.Linq;

    using P02_DatabaseFirst.Data;

    public class DeleteTown
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var town = Console.ReadLine();

                context.Employees.Where(e => e.Address.Town.Name == $"{town}")
                    .ToList().ForEach(e => e.AddressId = null);
                var affectedRowsEmployeeID = context.ChangeTracker.Entries().Count();
                context.SaveChanges();

                context.Addresses.RemoveRange(context.Addresses.Where(a => a.Town.Name == $"{town}"));
                var affectedRowsAddress = context.ChangeTracker.Entries().Count();
                context.SaveChanges();

                var countAffectedRows = affectedRowsAddress - affectedRowsEmployeeID;
                Console.WriteLine($"({countAffectedRows}) address in {town} was deleted");

                context.Towns.Remove(context.Towns.Where(t => t.Name == $"{town}").First());
                var affectedRowsT = context.ChangeTracker.Entries().Count();
                context.SaveChanges();
            }
        }
    }
}
