

using System;
using Domain.CourseContext.ValueObjects;
using Shared.Entities;

namespace Domain.CourseContext.Entities
{
    public class MonthlyPayments : Entity
    {
        public MonthlyPayments(Enroll enroll, DateTime dueDate, decimal price)
        {
            Enroll = enroll;
            DueDate = dueDate;
            Price = price;
        }

        public Enroll Enroll { get; private set; }
        public DateTime DueDate { get; private set; }
        public decimal Price { get; private set; }



    }
}