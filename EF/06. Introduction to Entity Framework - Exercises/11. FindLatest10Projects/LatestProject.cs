namespace _11._FindLatest10Projects
{
    using System;
    using System.Linq;

    using P02_DatabaseFirst.Data;

    public class LatestProject
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var db = context.Projects.OrderByDescending(p => p.StartDate)
                    .Take(10).OrderBy(p => p.Name);

                foreach (var project in db)
                {
                    Console.WriteLine(project.Name);
                    Console.WriteLine(project.Description);
                    Console.WriteLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
                }
            }
        }
    }
}
