using Loterica.Domain.Exceptions;
using Loterica.Domain.Features.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Applications.Features.Bets
{
    public class BetService : IBetService
    {
        IBetRepository _betRepository;

        public BetService(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        public Bet Add(Bet bet)
        {
            bet.Validate();
            return _betRepository.Save(bet);
        }

        public void Delete(Bet bet)
        {
            if (bet.Id == 0)
                throw new IdentifierUndefinedException();

            _betRepository.Delete(bet);
        }

        public Bet Get(Bet bet)
        {
            if (bet.Id == 0)
                throw new IdentifierUndefinedException();

            return _betRepository.Get(bet.Id);
        }

        public IEnumerable<Bet> GetAll()
        {
            return _betRepository.GetAll();
        }

        public Bet Update(Bet bet)
        {
            bet.Validate();
            return _betRepository.Update(bet);
        }
    }
}
