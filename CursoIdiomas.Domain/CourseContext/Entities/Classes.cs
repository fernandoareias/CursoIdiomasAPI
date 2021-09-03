

using System;
using Shared.Entities;

namespace Domain.CourseContext.Entities
{
    public class Classes : Entity
    {
        public Classes(Course course, Teacher teacher, object initialDate, object finalDate)
        {
            Course = course;
            Teacher = teacher;
            InitialDate = initialDate;
            FinalDate = finalDate;
        }

        public Course Course { get; private set; }
        public Teacher Teacher { get; private set; }

        public object InitialDate { get; private set; }
        public object FinalDate { get; private set; }
    }
}