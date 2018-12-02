namespace StartUp
{
    using P03_FootballBetting.Data;

    public class FootballBettingSystem
    {

        static void Main(string[] args)
        {
            using (FootballBettingContext context = new FootballBettingContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
