using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Application.Interfaces
{
    public interface IBoletimService
    {

        Task<ActionResult<object>> Obter(long id);

    }
}
