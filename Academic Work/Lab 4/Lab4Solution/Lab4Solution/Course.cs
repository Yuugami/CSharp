using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Solution
{
    class Course
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int WeeklyHours { get; set; }
        public double Fee { get; set; }
        public int MaxEnrollment {get; set;}

        public List<string> students = new List<string>();

        public Course(string code, string title)
        {
            //add code here to initialize the properties.
            this.Code = code;
            this.Title = title;
        }

        public bool isAvailable(string studentName)
        {
            if (this.students.Count < this.MaxEnrollment)
            {
                this.students.Add(studentName);
                return true;
            }    
            else
                return false;
        }
    }
}
