using System.Collections.Generic;

public class Contracts
{
    public interface ISoundProducable
    {
        string ProduceSound();
    }

    public abstract class Animal : ISoundProducable
    {
        private string name;

        private int age;

        private string gender;

        public Animal()
        {
            
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.IsValidParameter(value);
                this.name = value;
            }
        }

        public string Age
        {
            get
            {
                return this.age.ToString();
            }
            set
            {
                this.age = Validator.IsValidAge(value);
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                Validator.IsValidParameter(value);
                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }
    }

    //public class AnimalList
    //{
    //    public ICollection<Animal> List { get; set; }

    //    public AnimalList()
    //    {
    //        this.List = new List<Animal>();
    //    }
    //}
}