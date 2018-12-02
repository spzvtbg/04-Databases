namespace PhotoShare.Client.Core.Commands.Validations
{
    using System;
    using System.Linq;

    using PhotoShare.Data;
    using PhotoShare.Client.Core.Commands.Validations.Messages;

    public static class AddTownValidator
    {
        public static void Exists(string town, PhotoShareContext context)
        {
            if (context.Towns.Any(t => t.Name == town))
            {
                throw new ArgumentException(TownMessages.InvalidTown(town));
            }
        }
    }
}
