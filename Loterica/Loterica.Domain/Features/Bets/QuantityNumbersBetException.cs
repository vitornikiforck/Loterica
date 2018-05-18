using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Bets
{
    public class QuantityNumbersBetException : BusinessException
    {
        public QuantityNumbersBetException() : base("Uma aposta deve ter de 6 à 15 números")
        {
        }
    }
}
