using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class CoopStudent : Student
    {
        // Properties
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }
        public CoopStudent(string name) : base (name) { }


        public override void RegisterCourse(List<Course> selectedCourses)
        {
            // Check for amount of courses
            if (selectedCourses.Count > CoopStudent.MaxNumOfCourses)
            {
                throw new Exception($"Your selected exceeds the maximum number of courses: {CoopStudent.MaxNumOfCourses}");
            }

            // Check for hours
            int hours = 0;
            foreach (Course course in selectedCourses)
            {
                hours += course.WeeklyHours;
            }
            if (hours > CoopStudent.MaxWeeklyHours)
            {
                throw new Exception($"Your selected exceeds the maximum weekly hours: {CoopStudent.MaxWeeklyHours}");
            }

            // Change courses and return
            base.RegisterCourse(selectedCourses);
            return;
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Name} (Coop)";
        }
    }
}
