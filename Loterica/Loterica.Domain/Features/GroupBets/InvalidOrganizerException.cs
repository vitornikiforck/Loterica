using Loterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.GroupBets
{
    public class InvalidOrganizerException : BusinessException
    {
        public InvalidOrganizerException() : base("O nome do organizador não pode ser vazio.")
        {
        }
    }
}
