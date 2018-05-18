using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Bets
{
    public class BetEmptyContestException : BusinessException
    {
        public BetEmptyContestException() : base("Não pode fazer uma aposta sem estar em concurso")
        {
        }
    }
}
