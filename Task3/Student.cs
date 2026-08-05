using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class Student
    {
        private int age;
        public int StudentId { get; set; }

        public string name { get; set; }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 2 && value < 60)
                {
                    this.age = value;
                }
            }
        }
        public List<Course> Courses { get; set; }= new List<Course>();

        public bool Enroll(Course course)
        {
            if (Courses.Contains(course))
                return false;
            else
            {
                Courses.Add(course);
                return true;
            }
        }
        public string PrintDetails()
        {
            string EnrolledCourses = "[";
            for (int i = 0; i < Courses.Count; i++)
            {
                EnrolledCourses += $"  {Courses[i].Title}  ";
            }
            EnrolledCourses += "]";

            return $"StdID = {StudentId} , Name = {name} , Age = {age} , Courses = {EnrolledCourses}";
        }
    }
}
