using Loterica.Domain.Exceptions;
using Loterica.Domain.Features.GroupBets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Applications.Features.GroupBets
{
    public class GroupBetService : IGroupBetService
    {
        IGroupBetRepository _groupBetRepository;

        public GroupBetService(IGroupBetRepository groupBetRepository)
        {
            _groupBetRepository = groupBetRepository;
        }

        public GroupBet Add(GroupBet groupBet)
        {
            groupBet.Validate();
            return _groupBetRepository.Save(groupBet);
        }

        public void Delete(GroupBet groupBet)
        {
            if (groupBet.Id == 0)
                throw new IdentifierUndefinedException();
            _groupBetRepository.Delete(groupBet);
        }

        public GroupBet Get(GroupBet groupBet)
        {
            if (groupBet.Id == 0)
                throw new IdentifierUndefinedException();
            return _groupBetRepository.Get(groupBet.Id);
        }

        public IEnumerable<GroupBet> GetAll()
        {
            return _groupBetRepository.GetAll();
        }

        public GroupBet Update(GroupBet groupBet)
        {
            groupBet.Validate();
            return _groupBetRepository.Update(groupBet);
        }
    }
}
