using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Student
    {
        // Student Properties
        public int Id { get; }
        public string Name { get; }
        public List<Course> RegisteredCourses { get; }

        // Student Constructors
        protected Student(string name)
        {
            Random rnd = new Random();
            this.Id = rnd.Next(100000, 999999);
            this.Name = name;
            this.RegisteredCourses = new List<Course>();
        }

        public virtual void RegisterCourse(List<Course> selectedCourses)
        {
            // Remove all old elements
            this.RegisteredCourses.Clear();

            // Add all new elements
            foreach(Course course in selectedCourses)
            {
                this.RegisteredCourses.Add(course);
            }
        }

        public int TotalWeeklyHours()
        {
            int hours = 0;
            foreach(Course course in this.RegisteredCourses)
            { 
                hours += course.WeeklyHours;
            }
            return hours;
        }
    }
}
