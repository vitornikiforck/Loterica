using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Bets
{
    public class InvalidBetDateException : BusinessException
    {
        public InvalidBetDateException() : base("Data de aposta é inválida")
        {

        }
    }
}
