namespace P01_HospitalDatabase.Data.Context
{
    using Microsoft.EntityFrameworkCore;

    using P01_HospitalDatabase.Data.Common;

    public class ContextConfiguring
    {
        public static void Connection(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(string.Format(Strings.ConectionString, Strings.Connection()));
            }
        }

        public static void Connection(DbContextOptionsBuilder optionsBuilder, string connectionName)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(string.Format(Strings.ConectionString, connectionName));
            }
        }
    }
}
