namespace P1_DoctorsConsoleApplication.Values
{
    using P1_DoctorsConsoleApplication.MyConsole;

    using System.Collections.Generic;

    public class Options
    {
        public static Dictionary<string, Position> InitialOptions { get; } = new Dictionary<string, Position>
        {
            { "View Patients", new Position() },
            {"View Visitations", new Position() },
            {"View Diagnoses", new Position() },
            {"View Medicaments", new Position() }
        };
    }
}
