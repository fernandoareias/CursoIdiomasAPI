

using System;
using Domain.CourseContext.ValueObjects;
using Shared.Entities;

namespace Domain.CourseContext.Entities
{
    public class ReportCards : Entity
    {
        public ReportCards(Enroll enroll, int note)
        {
            Enroll = enroll;
            CreateDate = DateTime.Now;
            Note = note;
        }

        public Enroll Enroll { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public int Note { get; private set; }

        public void Update(int note)
        {
            Note = note;
            LastUpdate = DateTime.Now;


        }

    }
}