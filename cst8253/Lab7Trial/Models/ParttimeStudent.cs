using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7Trial.Models
{
    public class ParttimeStudent : Student
    {
        // property
        public int MaxNumOfCourses { get; set; }

        // constructor taking one parameter of strin gtype to pass to the base class' constructor to initialie the base classes Name property
        public ParttimeStudent (string name) : base (name) { }
    }
}
