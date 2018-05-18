using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Bets
{
    public class RepeatedNumberException : BusinessException
    {
        public RepeatedNumberException() : base("Os números da aposta não podem ser repetidos")
        {
        }
    }
}
