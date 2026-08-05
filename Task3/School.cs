using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Task3
{
    internal class School
    {
        public List<Student> Students { get; set;} = new List<Student>();
        public List<Course> Courses { get; set; }= new List<Course>();
        public List<Instructor> Instructors { get; set; }=  new List<Instructor>();
        public bool Addstudent(Student student)
        {
            Students.Add(student);
            return true;
        }

        public bool Addcourse(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public bool Addinstructor(Instructor instructor)
        {
            Instructors.Add(instructor);
            return true;
        }
        public Student Findstudent(int StdID)
        {
            for (int i=0;i<Students.Count;i++)
            {
                if (Students[i].StudentId == StdID)
                {
                    return Students[i];
                }
            }
            return null;

        }
        public Student FindStudentByName(string StudentName)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].name == StudentName)
                    return Students[i];
            }
            return null;
        }

        public Course Findcourse(int CourseID)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == CourseID)
                {
                    return Courses[i]; 
                }
            }
            return null;

        }
        public Instructor Findinstructor(int InsId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == InsId)

                {
                    return Instructors[i];
                }
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student std = Findstudent(studentId);
            if (std != null)
            {
                Course course = Findcourse(courseId);
                if (course != null)
                {
                    std.Courses.Add(course);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        //11. Check if the student enrolled in specific course
        public bool IfEnrolledInSpecificCourse(int studentId, int courseId)
        {
            Student std = Findstudent(studentId);
            if (std != null)
            {
                Course course = Findcourse(courseId);
                if (course != null)
                {
                    if (std.Courses.Contains(course))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        //12 Return the instructor name by course name
        public Course FindCourseByName(string CourseName)
        {
            for (int i=0;i<Courses.Count;i++)
            {
                if (Courses[i].Title == CourseName)
                    return Courses[i];
            }
            return null;
        }
        public string InstructorNameByCourseName(string coursename)
        {
           Course crs= FindCourseByName(coursename);
            if (crs != null)
            {
                Instructor ins = crs.Instructor;
                return ins.Name;
            }
            else
                return null;
        }

    }
}
