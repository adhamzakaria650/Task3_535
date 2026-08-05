using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Task3
{
    internal class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public string PrintDetails()
        {
            return $"InstID = {InstructorId}\nName = {Name}\nSpecialization = {Specialization}";
        }
    }
}
