namespace _14._DeleteProject
{
    using System;
    using System.Linq;

    using P02_DatabaseFirst.Data;

    public class DeleteProject
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var project = context.Projects.Find(2);
                foreach (var item in context.EmployeesProjects)
                {
                    if (item.Project == project)
                    {
                        context.EmployeesProjects.Remove(item);
                    }
                }
                context.Projects.Remove(project);
                context.SaveChanges();

                context.Projects.Take(10).ToList().ForEach(x => Console.WriteLine(x.Name));
            }
        }
    }
}
