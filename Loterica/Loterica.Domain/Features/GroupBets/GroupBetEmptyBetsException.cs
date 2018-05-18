using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.GroupBets
{
    public class GroupBetEmptyBetsException : BusinessException
    {
        public GroupBetEmptyBetsException() : base("O bolão não pode ser criado sem apostas.")
        {
        }
    }
}
