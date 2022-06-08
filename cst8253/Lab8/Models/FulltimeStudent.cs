using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class FulltimeStudent : Student
    {
        // Properties
        public static int MaxWeeklyHours { get; set; }
        public FulltimeStudent(string name) : base(name) { }

        public override void RegisterCourse(List<Course> selectedCourses)
        {
            // Check for hours
            int hours = 0;
            foreach (Course course in selectedCourses)
            {
                hours += course.WeeklyHours;
            }
            if(hours > FulltimeStudent.MaxWeeklyHours)
            {
                throw new Exception($"Your selected exceeds the maximum weekly hours: {FulltimeStudent.MaxWeeklyHours}");
            }

            // Change courses and return
            base.RegisterCourse(selectedCourses);
            return;
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Name} (Full time)";
        }
    }
}
