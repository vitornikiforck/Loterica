using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.GroupBets
{
    public interface IGroupBetRepository
    {
        GroupBet Save(GroupBet groupBet);
        GroupBet Update(GroupBet groupBet);
        GroupBet Get(long id);
        IEnumerable<GroupBet> GetAll();
        void Delete(GroupBet groupBet);
    }
}
