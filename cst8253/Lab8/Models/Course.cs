using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Course
    {
        public string Code;
        public string Title;
        public int WeeklyHours;

        public Course(string code, string title)
        {
            this.Code = code;
            this.Title = title;
        }

        //public Course(string code, string title, int weeklyHours)
        //{
        //    this.Code = code;
        //    this.Title = title;
        //    this.WeeklyHours = weeklyHours;
        //}

    }
}