using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7Trial.Models
{
    public class Student
    {
        // properties
        public int Id { get; }
        public string Name { get; }

        // constructor taking one parameter of string type for initializing the Name property
        // the constructor will initialize Id property with a randomly generated 6-digit number
        protected Student (string name)
        {
            Random random = new Random();
            Id = random.Next(100000, 999999);
            Name = name;
        }
    }
}
