using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Solution
{
    class Student
    {
        public const int MAX_WEEKLY_HOURS = 8;
        private string name;
        private int currentWeeklyHours;
        private double currentFees; 
        List<string> courses = new List<string>(); // list of courses the studnet has registered.
 
        public Student(string name)
        {
            this.name = name;
        }
        
        public string Name
        {
            get { return name; }
        }

        public void addCourse(int number, Course[] courseList)
        {
            courses.Add($"{courseList[number].Code} {courseList[number].Title}");
            this.currentWeeklyHours += courseList[number].WeeklyHours;
            this.currentFees += courseList[number].Fee;
        }
        public void getEnrolledCourses()
        {
            Console.Write($"\n\tYour course(s): \n");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.Write($"\t\t{courses[i]}\n");
            }
        }

        public void displayInfo()
        {
            Console.Write($"\t\tCurrent Weekly Hours: {currentWeeklyHours}\n" +
                $"\t\tFees: ${currentFees}\n\n");
        }

        public bool[] selectCourse(Course[] courseList)
        {
            bool[] flags = { true, true };
            Console.Write("\nEnter your selection: ");
            string selection = Console.ReadLine();
            int number;
            if (Int32.TryParse(selection, out number) && number >= 0 
                && number < courseList.Length)
            {
                int potentialHours = currentWeeklyHours + courseList[number].WeeklyHours;
                if (potentialHours <= MAX_WEEKLY_HOURS)
                {
                    if (!this.inTheCourse(courseList[number]))
                    {
                        if (courseList[number].isAvailable(this.name))
                        {
                            this.addCourse(number, courseList);
                        }    
                        else
                            Console.Write("This course is full.");
                    }     
                    else
                        Console.Write("You have already registered for this course.");
                }
                else
                    Console.Write($"Cannot add course. Reason: Exceeded Weekly Hours"
                        + $"\n(Will be {potentialHours}/{MAX_WEEKLY_HOURS})");
            }
            else
            {
                Console.Write("More students to register? (Y/N)");
                selection = Console.ReadLine();
                if (selection.ToLower() == "y")
                {
                    flags[1] = false;
                    return flags;
                }
                else
                {
                    flags[0] = false;
                    flags[1] = false;
                    return flags;
                }
            }
            return flags;
        }

        public bool inTheCourse(Course theCourse)
        {
            string targetCourse = ($"{theCourse.Code} {theCourse.Title}");
            for (int i = 0; i < this.courses.Count; i++)
            {
                if (courses.Contains(targetCourse))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
