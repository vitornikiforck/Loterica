using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Bets
{
    public interface IBetService
    {
        Bet Add(Bet bet);
        Bet Update(Bet bet);
        Bet Get(Bet bet);
        IEnumerable<Bet> GetAll();
        void Delete(Bet bet);
    }
}
