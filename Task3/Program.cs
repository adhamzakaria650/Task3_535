using System.Collections.Concurrent;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            
            int Stdid;
            string Stdname;
            int Stdage;

            int Insid;
            string Insname;
            string InsSpecialization;

            int Crsid;
            string Crsname;

            int searchid;
            string searchname;
            string choosed;

            while (true)
            {
                Console.WriteLine("Welcome to Our School");
                Console.WriteLine("select an option");
                Console.WriteLine("1.  Add Student");
                Console.WriteLine("2.  Add Instructor");
                Console.WriteLine("3.  Add Course");
                Console.WriteLine("4.  Enroll Student in Course");
                Console.WriteLine("5.  Show All Students");
                Console.WriteLine("6.  Show All Courses");
                Console.WriteLine("7.  Show All Instructors");
                Console.WriteLine("8.  Find the student by id or name");
                Console.WriteLine("9.  Find the course by id or name");
                Console.WriteLine("10. Exit");
                Console.WriteLine("11. Check if the student enrolled in specific course");
                Console.WriteLine("12. Return the instructor name by course name");


                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    bool Stdisfound = false; 
                    Student std = new Student();
                    Console.Write("Enter student id: ");
                    Stdid = Convert.ToInt32(Console.ReadLine());
                    for(int i=0; i < school.Students.Count; i++)
                    {
                        if (school.Students[i].StudentId == Stdid)
                        {
                            Stdisfound = true;
                            break;
                        }
                    }
                    if (Stdisfound)
                        Console.WriteLine("Student is already Exists");
                    else
                    {
                        Console.Write("Enter student name: ");
                        Stdname = Console.ReadLine().Trim().ToLower();
                        Console.Write("Enter student age: ");
                        Stdage = Convert.ToInt32(Console.ReadLine());
                        std.StudentId = Stdid;
                        std.name = Stdname;
                        std.Age = Stdage;
                        school.Addstudent(std);
                    }
                }
                else if (input == 2)
                {
                    bool Insisfound = false;
                    Instructor ins = new Instructor();
                    Console.Write("Enter Instructor id: ");
                    Insid = Convert.ToInt32(Console.ReadLine());
                    for(int i = 0; i < school.Instructors.Count; i++)
                    {
                        if (school.Instructors[i].InstructorId == Insid)
                        {
                            Insisfound = true;
                            break;
                        }
                    }
                    if (Insisfound)
                        Console.WriteLine("Instructor is already Exists");
                    else
                    {
                        Console.Write("Enter Instructor name: ");
                        Insname = Console.ReadLine().Trim().ToLower();
                        Console.Write("Enter Specialization: ");
                        InsSpecialization = Console.ReadLine();
                        ins.InstructorId = Insid;
                        ins.Name = Insname;
                        ins.Specialization = InsSpecialization;
                        school.Addinstructor(ins);
                    }
                }
                else if (input == 3)
                {
                    bool Crsisfound = false;
                    bool Insisfound = false;
                    Instructor ins2 = new Instructor();
                    Course crs = new Course();
                    Console.Write("Enter Course id: ");
                    Crsid = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < school.Courses.Count; i++)
                    {
                        if (school.Courses[i].CourseId == Crsid)
                        {
                            Crsisfound = true;
                            break;
                        }
                    }
                    if (Crsisfound)
                        Console.WriteLine("Course is already Exists");
                    else
                    {
                        Console.Write("Enter Course Title: ");
                        Crsname = Console.ReadLine().Trim().ToLower();
                        crs.CourseId = Crsid;
                        crs.Title = Crsname;
                        Console.Write("Enter Instructor id: ");
                        Insid = Convert.ToInt32(Console.ReadLine());
                        for(int i = 0; i < school.Instructors.Count; i++)
                        {
                            if (school.Instructors[i].InstructorId == Insid)
                            {
                                ins2 = school.Instructors[i];
                                Insisfound = true;
                                break;

                            }
                        }

                        if (Insisfound)
                        {
                            crs.Instructor = ins2;
                            school.Addcourse(crs);
                        }
                        else
                            Console.WriteLine("Instructor not found");
                    }
                }
                else if (input == 4)
                {
                    Console.WriteLine("Enter id of the student");
                    Stdid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter id of the course");
                    Crsid = Convert.ToInt32(Console.ReadLine());
                    Student std2 = school.Findstudent(Stdid);
                    if (std2 != null)
                    {
                        Course crs2 = school.Findcourse(Crsid);
                        if (crs2 != null)
                        {
                            std2.Courses.Add(crs2);
                        }
                        else
                            Console.WriteLine("Course not found");
                    }
                    else
                        Console.WriteLine("Student not found");
                }
                else if (input == 5)
                {
                    Student std3 = new Student();
                    for (int i = 0; i < school.Students.Count; i++)
                    {
                        std3 = school.Students[i];
                        Console.WriteLine(std3.PrintDetails());
                    }
                }
                else if (input == 6)
                {
                    Course crs3 = new Course();
                    for (int i = 0; i < school.Courses.Count; i++)
                    {
                        crs3 = school.Courses[i];
                        Console.WriteLine(crs3.PrintDetails());
                    }
                }
                else if (input == 7)
                {
                    Instructor ins3 = new Instructor();
                    for (int i = 0; i < school.Instructors.Count; i++)
                    {
                        ins3 = school.Instructors[i];
                        Console.WriteLine(ins3.PrintDetails());
                    }
                }
                else if (input == 8)
                {
                    Console.Write("choose 1 to find by id or 2 to find by name: ");
                    choosed = Console.ReadLine();
                    if (choosed == "1")
                    {
                        Console.Write("enter the id of the student: ");
                        if (int.TryParse(Console.ReadLine(), out searchid))
                        {
                            Student std4 = school.Findstudent(searchid);
                            if (std4 == null)
                                Console.WriteLine("Student Not found");
                            else
                                Console.WriteLine(std4.PrintDetails());
                        }
                        else
                            Console.WriteLine("Invalid input (Enter id of the student)");
                    }
                    else if (choosed == "2")
                    {
                        Console.Write("enter the name of the student: ");
                        searchname = Console.ReadLine().Trim().ToLower();
                        Student std4 = school.FindStudentByName(searchname);
                        if (std4 == null)
                            Console.WriteLine("Student Not found");
                        else
                            Console.WriteLine(std4.PrintDetails());
                    }
                    else
                        Console.WriteLine("Invaild option");
                }
                else if (input == 9)
                {
                    Console.Write("choose 1 to find by id or 2 to find by name: ");
                    choosed = Console.ReadLine();
                    if (choosed == "1")
                    {
                        Console.Write("enter the id of the course: ");
                        if (int.TryParse(Console.ReadLine(), out searchid))
                        {
                            Course crs4 = school.Findcourse(searchid);
                            if (crs4 == null)
                                Console.WriteLine("course Not found");
                            else
                                Console.WriteLine(crs4.PrintDetails());
                        }
                        else
                            Console.WriteLine("Invalid input (Enter the id of the Course)");
                    }
                    else if (choosed == "2")
                    {
                        Console.Write("enter the name of the course: ");
                        searchname = Console.ReadLine().Trim().ToLower();
                        Course crs4 = school.FindCourseByName(searchname);
                        if (crs4 == null)
                            Console.WriteLine("Not found");
                        else
                            Console.WriteLine(crs4.PrintDetails());
                    }
                    else
                        Console.WriteLine("Invaild option");
                }
                else if (input == 10)
                {
                    break;
                }
                else if (input ==11)
                {
                    Console.Write("Enter the id of the Student: ");
                    if (int.TryParse(Console.ReadLine(), out Stdid))
                    {
                        Console.Write("Enter the id of the course: ");
                        if (int.TryParse(Console.ReadLine(), out Crsid))
                        {
                            if (school.EnrollStudentInCourse(Stdid, Crsid))
                                Console.WriteLine("yes, he is enrolled");
                            else
                                Console.WriteLine("no, he isn't enrolled");                           
                        }
                        else
                            Console.WriteLine("Invalid input (Enter the id of the Course)");
                    }
                    else
                        Console.WriteLine("Invalid input (Enter id of the student)");
                }
                else if (input == 12)
                {
                    Console.Write("Enter Course Name: ");
                    Crsname = Console.ReadLine().Trim().ToLower();
                    if (school.InstructorNameByCourseName(Crsname) == null)
                        Console.WriteLine($"The Course {Crsname} not found");
                    else
                        Console.WriteLine($"The instructor of {Crsname} is {school.InstructorNameByCourseName(Crsname)}");
                }
                else
                    Console.WriteLine("Invalid Option");


                Console.WriteLine("================================================");
            }
            Console.WriteLine("Goodbye");
        }
    }
}
