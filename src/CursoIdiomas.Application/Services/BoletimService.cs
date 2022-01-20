using CursoIdiomas.Domain.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Services
{
    public class BoletimService : IBoletimService
    {
        public Task<ActionResult<object>> Obter(long id)
        {
            throw new NotImplementedException();
        }
    }
}
