using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }
        

        public string PrintDetails()
        {
            return $"CourseId = {CourseId} , Title = {Title} , Instructor = {Instructor.Name}";
        }
    }
}
