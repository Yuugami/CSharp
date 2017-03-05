using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Solution
{
    class RegistrationSystem
    {
        const int NUM_OF_COURSES = 4;

        static void Main(string[] args)
        {
            Course[] courses = new Course[NUM_OF_COURSES];
            
            courses[0] = new Course("CST8282", "Introduction to Database Systems");
            courses[0].WeeklyHours = 4;
            courses[0].MaxEnrollment = 3;
            courses[0].Fee = 300.0;

            courses[1] = new Course("CST8253", "Web Programming II");
            courses[1].WeeklyHours = 2;
            courses[1].MaxEnrollment = 4;
            courses[1].Fee = 250.0;

            courses[2] = new Course("CST8256", "Web Programming Language I");
            courses[2].WeeklyHours = 5;
            courses[2].MaxEnrollment = 4;
            courses[2].Fee = 350.0;

            courses[3] = new Course("CST8255", "Web Imaging and Animations");
            courses[3].WeeklyHours = 2;
            courses[3].MaxEnrollment = 3;
            courses[3].Fee = 200.0;

            ///////////////////////////////////////////////////////////////////
            // Another loop for getting a student
            bool[] flags = { true, true };
            while (flags[0])
            {
                flags[0] = false;
                flags[1] = true;
                String studentName = getName();
                Student newStudent = new Student(studentName);
                Console.Write($"\nWelcome {studentName},\n");
                // Loop for course selection
                while (flags[1])
                {
                    printCourses(courses);
                    flags = newStudent.selectCourse(courses); 
                    if (flags[1])
                    {
                        newStudent.getEnrolledCourses();
                        newStudent.displayInfo();
                    }      
                } 
            }

            for (int i = 0; i < courses.Length; i++)
            {
                Console.Write($"Course {courses[i].Code}, {courses[i].Title} enrollment: \n");
                foreach (string j in courses[i].students)
                {
                    Console.Write($"\t{j}\n");
                }
                Console.Write("\n");
            }
            
            ///////////////////////////////////////////////////////////////////

            Console.ReadLine(); // End Line
        }
        // Functions
        static string getName()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            return name;
        }

        static void printCourses(Course[] courseList)
        {
            for (int i = 0; i < courseList.Length; i++)
            {
                Console.Write($"Enter {i} to select " +
                    $"{courseList[i].Title}\n");
            }
        }
    }
}
