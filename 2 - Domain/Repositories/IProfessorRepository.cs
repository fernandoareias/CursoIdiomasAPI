using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories {
    public interface IProfessorRepository : IRepository<CursoIdiomas.Domain.Entities.Professor> {
    }
}
