using CursoIdiomas.Domain.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Services
{
    public class MensalidadeService : IMensalidadesService
    {
        public Task<ActionResult<object>> ObterFatura(long id)
        {
            throw new NotImplementedException();
        }
    }
}
