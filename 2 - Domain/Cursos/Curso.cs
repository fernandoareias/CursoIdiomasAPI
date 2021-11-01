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
        public Curso(long id) : base(id) { 
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(id, 0, "Id", "O Id deve ser maior que zero.")
            );
        }

        public Curso(string nome, EDificuldade dificuldade, int cargaHoraria) {
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

        public Curso(long idCurso, string nome, EDificuldade dificuldade, int cargaHoraria) : base(idCurso){
            Nome = nome;
            Dificuldade = dificuldade;
            CargaHoraria = cargaHoraria;
            
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(idCurso, 0, "Id", "O Id deve ser maior que zero.")
                .IsGreaterThan(Nome, 2, "Nome", "O Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(Nome, 80, "Nome", "O Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(CargaHoraria, 0, "CargaHoraria", "A Carga horaria deve ser maior que 0.")
                .IsLowerThan((int)dificuldade, 4, "Dificuldade", "O dificuldade deve ser menor que 4")
                );
        }

        public Curso(string nome, EDificuldade dificuldade, int cargaHoraria, DateTime dataInicio){
            Nome = nome;
            Dificuldade = dificuldade;
            CargaHoraria = cargaHoraria;
            DataInicio = dataInicio;

                AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Nome, 2, "Nome", "O Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(Nome, 80, "Nome", "O Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(dataInicio, DateTime.Now, "A data de inicio deve ser maior que a data de hoje!")
                .IsGreaterThan(CargaHoraria, 0, "CargaHoraria", "A Carga horaria deve ser maior que 0.")
                .IsLowerThan((int)dificuldade, 4, "Dificuldade", "O dificuldade deve ser menor que 4")
                );
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
                .IsGreaterThan(dataInicio, DateTime.Now, "A data de inicio deve ser maior que a data de hoje!")
                .IsLowerThan(dataInicio, dataTermino.Value, "A data de inicio deve ser menor que a data de termino!")
                .IsGreaterThan(dataTermino.Value, DateTime.Now, "A data de termino deve ser maior que a data de hoje!")
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

        public virtual IEnumerable<CursoIdiomas.Domain.Entities.Professor> Professores { get; set; }


        /*
         public void Update()
        {
            ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
           
        }*/
    }
}
