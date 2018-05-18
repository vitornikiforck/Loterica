using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.Bets
{
    public interface IBetRepository
    {
        Bet Save(Bet bet);
        Bet Update(Bet bet);
        Bet Get(long id);
        IEnumerable<Bet> GetAll();
        void Delete(Bet bet);
    }
}
