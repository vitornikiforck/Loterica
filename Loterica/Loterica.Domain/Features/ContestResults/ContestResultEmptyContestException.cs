using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.ContestResults
{
    public class ContestResultEmptyContestException : BusinessException
    {
        public ContestResultEmptyContestException() : base("Não pode haver um resultado de um concurso que não existe.")
        {
        }
    }
}
