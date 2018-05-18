using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.GroupBets
{
    public interface IGroupBetService
    {
        GroupBet Add(GroupBet groupBet);
        GroupBet Update(GroupBet groupBet);
        GroupBet Get(GroupBet groupBet);
        IEnumerable<GroupBet> GetAll();
        void Delete(GroupBet groupBet);
    }
}
