using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Application.Interfaces
{
    public interface IMensalidadesService
    {

        Task<ActionResult<object>> ObterFatura(long id);
    }
}
