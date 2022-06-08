using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6Trial.Models
{
    public class Course
    {
        // Course properties
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours { get; set; }

        // Course constructors
        public Course(string code, string title)
        {
            Code = code;
            Title = title;
            WeeklyHours = WeeklyHours;
        }

        public Course(string code, string title, int weeklyHours)
        {
            Code = code;
            Title = title;
            WeeklyHours = WeeklyHours;
        }
    }
}
