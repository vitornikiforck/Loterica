using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.GroupBets
{
    public class InvalidCreateGroupBetDateException : BusinessException
    {
        public InvalidCreateGroupBetDateException() : base("A data de criação do bolão deve ser menor que a data atual.")
        {
        }
    }
}
