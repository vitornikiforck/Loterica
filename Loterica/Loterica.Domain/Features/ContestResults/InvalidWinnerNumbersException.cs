using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.ContestResults
{
    public class InvalidWinnerNumbersException : BusinessException
    {
        public InvalidWinnerNumbersException() : base("Os números ganhadores do resultado do concurso não podem ser repetidos")
        {
        }
    }
}
