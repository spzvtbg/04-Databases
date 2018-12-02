namespace P01_StudentSystemSeeder.Engine
{
    using System.Collections.Generic;

    using P01_StudentSystem.Data.Models;
    using P01_StudentSystemSeeder.DataValues;

    public class Genarator
    {
        public static ICollection<Student> RandomStudents()
        {
            ICollection<Student> studentsCollection = new List<Student>();

            for (int count = 0; count < Ints.InitialStudentsCount; count++)
            {
                Student newStudent = new Student();
                newStudent.Name = GeneratorHelper.PersonName(Text.FirstNames, Text.LaststNames);
                newStudent.PhoneNumber = GeneratorHelper.PhoneNumber();
                newStudent.Birthday = GeneratorHelper.Date();
                newStudent.RegisteredOn = GeneratorHelper.Date(newStudent.Birthday.Value.Year);
                studentsCollection.Add(newStudent);
            }
            return studentsCollection;
        }

        public static ICollection<Student> RandomStudents(int students)
        {
            ICollection<Student> studentsCollection = new List<Student>();

            for (int count = 0; count < students; count++)
            {
                Student newStudent = new Student();
                newStudent.Name = GeneratorHelper.PersonName(Text.FirstNames, Text.LaststNames);
                newStudent.PhoneNumber = GeneratorHelper.PhoneNumber();
                newStudent.Birthday = GeneratorHelper.Date();
                newStudent.RegisteredOn = GeneratorHelper.Date(newStudent.Birthday.Value.Year);
                studentsCollection.Add(newStudent);
            }
            return studentsCollection;
        }

        public static ICollection<Course> Courses()
        {
            ICollection<Course> courseesCollection = new List<Course>();

            for (int count = 0; count < Text.Courses.Length; count++)
            {
                decimal price = GeneratorHelper.Price();
                for (int repeatingCount = 0; repeatingCount < 5; repeatingCount++)
                {
                    Course newCourse = new Course();
                    newCourse.Name = Text.Courses[count];
                    newCourse.Price = price;
                }
            }
            return courseesCollection;
        }
    }
}
