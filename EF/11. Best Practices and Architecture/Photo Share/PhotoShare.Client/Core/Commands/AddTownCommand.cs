namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Data;
    using PhotoShare.Client.Core.Atributes;
    using PhotoShare.Client.Core.Contracts;
    using System;
    using PhotoShare.Client.Core.Commands.Validations.Messages;
    using PhotoShare.Client.Core.Commands.Validations;

    [Command("addtown")]
    public class AddTownCommand : ICommand
    {
        private string TownName { get; set; }

        private string Country { get; set; }

        public void Parse(string[] data)
        {
            this.TownName = data[1];
            this.Country = data[2];
        }

        private static PhotoShareContext context = new PhotoShareContext();

        // AddTown <townName> <countryName>
        public void Execute()
        {
            AddTownValidator.Exists(this.TownName, context);

            using (PhotoShareContext context = new PhotoShareContext())
            {
                Town town = new Town
                {
                    Name = this.TownName,
                    Country = this.Country
                };

                context.Towns.Add(town);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(TownMessages.Succsess(this.TownName));
            }
        }
    }
}
