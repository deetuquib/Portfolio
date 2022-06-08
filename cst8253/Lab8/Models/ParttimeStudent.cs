using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class ParttimeStudent : Student
    {
        // Properties
        public static int MaxNumOfCourses { get; set; }
        public ParttimeStudent(string name) : base(name) { }

        public override void RegisterCourse(List<Course> selectedCourses)
        {
            // Check for amount of courses
            if (selectedCourses.Count > ParttimeStudent.MaxNumOfCourses)
            {
                throw new Exception($"Your selected exceeds the maximum number of courses: {ParttimeStudent.MaxNumOfCourses}");
            }

            base.RegisterCourse(selectedCourses);
            return;
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Name} (Part time)";
        }
    }
}
