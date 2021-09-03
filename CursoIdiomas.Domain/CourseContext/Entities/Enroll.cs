

using System.Collections.Generic;
using System.Linq;
using Domain.CourseContext.Enums;
using Shared.Entities;

namespace Domain.CourseContext.Entities
{
    public class Enroll : Entity
    {
        private readonly IList<MonthlyPayments> _monthlyPayments;
        private readonly IList<ReportCards> _reportCards;

        public Enroll(Student student, Classes classe)
        {
            Student = student;
            Classe = classe;
            Status = EEnrollStatus.Active;

            // Inicializa as listas.
            _monthlyPayments = new List<MonthlyPayments>();
            _reportCards = new List<ReportCards>();
        }

        public Student Student { get; private set; }
        public Classes Classe { get; private set; }
        public EEnrollStatus Status { get; private set; }

        // Lista de mensalidades da matricula
        public IReadOnlyCollection<MonthlyPayments> MonthlyPayments => _monthlyPayments.ToArray();

        // Lista de boletins
        public IReadOnlyCollection<ReportCards> ReportCards => _reportCards.ToArray();

        // Muda o status da matricula
        public void ChangeStatus(EEnrollStatus status) => Status = status;

        // Adiciona uma nova mensalidade
        public void AddMonthlyPayments(MonthlyPayments monthly) => _monthlyPayments.Add(monthly);
        // Adiciona um boletim novo
        public void AddReportCards(ReportCards reports) => _reportCards.Add(reports);

    }
}