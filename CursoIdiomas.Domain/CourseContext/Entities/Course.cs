

using Domain.CourseContext.Enums;
using Domain.CourseContext.ValueObjects;
using Shared.Entities;

namespace Domain.CourseContext.Entities
{
    public class Course : Entity
    {
        public Course(string name, ECourseLevel level, int workload)
        {
            Name = name;
            Level = level;
            Workload = workload;
        }

        public string Name { get; private set; }
        public ECourseLevel Level { get; private set; }
        public int Workload { get; private set; }
    }
}