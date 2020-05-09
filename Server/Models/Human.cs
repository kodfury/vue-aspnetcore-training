using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Human
    {   
        public Human()
        {
            Console.WriteLine("Constructor execute :" + Name);
        }

        public Human(string message)
        {
            Console.WriteLine("Constructor execute, " + message);
        }

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Constructor execute, " + this.Name + " " + this.Age);
        }

        public string Name { get; set; }
        public int Age { get; set; }

        protected string Gender { get; set; }

        public static void Greet(string name)
        {   
            Console.WriteLine("Hello " + name);
        }

        public void Introduce()
        {
            Console.WriteLine("My name is " + Name);
        }

        public int GetAgePlusTen()
        {
            return Age + 10;
        }
    }
}