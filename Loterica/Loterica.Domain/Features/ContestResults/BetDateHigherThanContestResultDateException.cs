using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.ContestResults
{
    public class BetDateHigherThanContestResultDateException : BusinessException
    {
        public BetDateHigherThanContestResultDateException() : base("A data do resultado do concurso não pode ser anterior à data das apostas.")
        {
        }
    }
}
