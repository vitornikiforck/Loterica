using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Bets
{
    public class InvalidNumbersBetException : BusinessException
    {
        public InvalidNumbersBetException() : base("Os números da aposta não podem ser maiores que 60")
        {
        }
    }
}
