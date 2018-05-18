using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.ContestResults
{
    public class ContestDateHigherThanContestResultDateException : BusinessException
    {
        public ContestDateHigherThanContestResultDateException( ) : base("A data do resultado do concurso não pode ser anterior a data do concurso.")
        {
        }
    }
}
