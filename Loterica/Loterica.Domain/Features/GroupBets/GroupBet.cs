using Loterica.Domain.Features.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Domain.Features.GroupBets
{
    public class GroupBet
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Organizer { get; set; }
        public List<Bet> Bets { get; set; }

        public void Validate()
        {
            if (CreateDate > DateTime.Now)
                throw new InvalidCreateGroupBetDateException();
            if (String.IsNullOrEmpty(Organizer))
                throw new InvalidOrganizerException();
            if (Bets.Count == 0)
                throw new GroupBetEmptyBetsException();
        }
    }
}
