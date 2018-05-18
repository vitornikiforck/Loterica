using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Contests
{
    public class InvalidDateContestException : BusinessException
    {
        public InvalidDateContestException() : base("A data atual não pode ser maior que a data do concurso")
        {
        }
    }
}
