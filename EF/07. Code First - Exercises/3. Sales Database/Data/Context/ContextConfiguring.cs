namespace P03_SalesDatabase.Data.Context
{
    using Microsoft.EntityFrameworkCore;

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
