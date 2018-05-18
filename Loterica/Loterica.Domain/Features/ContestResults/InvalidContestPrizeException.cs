using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.ContestResults
{
    public class InvalidContestPrizeException : BusinessException
    {
        public InvalidContestPrizeException() : base("O valor do concurso não pode ser gerado porque ele não teve nenhuma aposta")
        {
        }
    }
}
