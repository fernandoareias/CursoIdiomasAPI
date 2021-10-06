using CursoIdiomas.Domain.Cursos.Enum;
using CursoIdiomas.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace CursoIdiomas.Domain.Cursos.Curso {
    public class Curso : Entity
    {
        public Curso() { }
        public Curso(long id) : base(id) { }

        public Curso(string nome, EDificuldade dificuldade, int cargaHoraria) {
            Nome = nome;
            Dificuldade = dificuldade;
            CargaHoraria = cargaHoraria;
        }

        public Curso(long idCurso, string nome, EDificuldade dificuldade, int cargaHoraria) : base(idCurso){
            Nome = nome;
            Dificuldade = dificuldade;
            CargaHoraria = cargaHoraria;
        }

        public Curso(string nome, EDificuldade dificuldade, int cargaHoraria, DateTime dataInicio, DateTime? dataTermino = null) {
            Nome = nome;
            Dificuldade = dificuldade;
            CargaHoraria = cargaHoraria;
            DataInicio = dataInicio;
            DataTermino = dataTermino;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Nome, 2, "Nome", "O Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(Nome, 80, "Nome", "O Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(CargaHoraria, 0, "CargaHoraria", "A Carga horaria deve ser maior que 0.")
                .IsLowerThan((int)dificuldade, 4, "Dificuldade", "O dificuldade deve ser menor que 4")
                );
        }

        public Curso(long id, string nome, EDificuldade dificuldade, int cargaHoraria, DateTime dataInicio, DateTime? dataTermino = null) : base(id) {
            Nome = nome;
            Dificuldade = dificuldade;
            CargaHoraria = cargaHoraria;
            DataInicio = dataInicio;
            DataTermino = dataTermino;

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
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }

        public virtual IEnumerable<CursoIdiomas.Domain.Entities.Professor> Professores { get; private set; }
    }
}
