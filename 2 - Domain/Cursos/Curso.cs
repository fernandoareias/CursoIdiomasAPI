using CursoIdiomas.Domain.Cursos.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace CursoIdiomas.Domain.Entities {
    public class Curso : Entity
    {
        public Curso()
        {

        }

        public Curso(string nome, EDificuldade dificuldade, int cargaHoraria)
        {
            Nome = nome;
            Dificuldade = dificuldade;
            CargaHoraria = cargaHoraria;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Nome, 2, "Nome", "O Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(Nome, 80, "Nome", "O Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(CargaHoraria, 0, "CargaHoraria", "A Carga horaria deve ser maior que 0.")
                .IsLowerThan((int)dificuldade, 4, "Dificuldade", "O dificuldade deve ser menor que 4")
                );

        }
        public Curso(Guid id, string nome, EDificuldade dificuldade, int cargaHoraria) : base(id){
            Nome = nome;
            Dificuldade = dificuldade;
            CargaHoraria = cargaHoraria;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Nome, 2, "Nome", "O Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(Nome, 80, "Nome", "O Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(CargaHoraria, 0, "CargaHoraria", "A Carga horaria deve ser maior que 0.")
                .IsLowerThan((int)dificuldade, 4, "Dificuldade", "O dificuldade deve ser menor que 4")
                );

        }
  
        public string Nome { get; private set; }
        public EDificuldade Dificuldade { get; private set; }
        public int CargaHoraria { get; private set; }
        public Guid TurmaId { get;  set; }
        public List<Turma> Turmas { get;  set; }
    }
}
