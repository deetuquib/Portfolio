using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7Trial.Models
{
    public class CoopStudent : Student
    {
        // properties
        public int MaxWeeklyHours { get; set; }
        public int MaxNumOfCourses { get; set; }

        // constructor taking one parameter of string type to pass to the base class' constructor to initialize the base classes Name property
        public CoopStudent (string name) : base (name) { }
    }
}
