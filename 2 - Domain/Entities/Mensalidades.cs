using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Mensalidade : Entity
    {
        public Mensalidade() {

        }
        public Mensalidade(DateTime vencimento, decimal valor) {
            Vencimento = vencimento;
            Valor = valor;
        }


        public void ProrrogarVencimento(DateTime NovoVencimento) => this.Vencimento = NovoVencimento;
        public void AlterarValor(decimal valor) => this.Valor = valor;

        public DateTime Vencimento { get; private set; }
        public decimal Valor { get; private set; }
        public Guid MatriculaId { get; private set; }
        public Matricula Matricula { get; private set; }
    }
}
