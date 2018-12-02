namespace PhotoShare.Client.Core.Commands.Validations.Messages
{
    public static class TownMessages
    {
        public static string Succsess(string town) => $"{town} was added to database!";

        public static string InvalidTown(string town) => $"Town {town} was already added!";
    }
}
