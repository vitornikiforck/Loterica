using Loterica.Domain.Features.Bets;
using Loterica.Domain.Features.ContestResults;
using Loterica.Domain.Features.Contests;
using Loterica.Domain.Features.GroupBets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Common.Tests.Base
{
    public static partial class ObjectMother
    {
        #region Bet
        //Gera uma aposta válida aleatória
        public static Bet RandomValidBetWithoutId()
        {
            Bet bet = new Bet();
            Random random = new Random();

            List<int> numbersBet = new List<int>();

            int totalNumbers = random.Next(6, 16);
            int i = 0;
            while (i < totalNumbers)
            {
                int randomNumber = random.Next(1, 61);

                if (!numbersBet.Contains(randomNumber))
                {
                    numbersBet.Add(randomNumber);
                    i++;
                }
            }
            numbersBet.Sort();

            bet.BetDate = DateTime.Now.AddMinutes(-1);
            bet.NumbersBet = numbersBet;

            return bet;
        }

        //Aposta válida com Id
        public static Bet ValidBetWithId()
        {
            Bet bet = new Bet();
            bet.Id = 1;
            bet.BetDate = DateTime.Now.AddMinutes(-1);
            bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6 };
            return bet;
        }

        public static Bet ValidBetWithContest()
        {
            Bet bet = new Bet();
            bet.Id = 1;
            bet.BetDate = DateTime.Now.AddMinutes(-1);
            bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6 };
            bet.Contest = ValidContestWithoutId();
            return bet;
        }

        //Aposta com data inválida
        public static Bet InvalidBetDate()
        {
            Bet bet = new Bet();
            bet.BetDate = DateTime.Now.AddMinutes(1);
            bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6 };
            return bet;
        }

        //Aposta com um número inválido
        public static Bet InvalidNumbersBet()
        {
            Bet bet = new Bet();
            bet.BetDate = DateTime.Now.AddMinutes(-1);
            bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 61 };
            return bet;
        }

        public static Bet InvalidQuantityNumbersBet()
        {
            Bet bet = new Bet();
            bet.BetDate = DateTime.Now.AddMinutes(-1);
            bet.NumbersBet = new List<int>() { 1, 2, 3, 4 };
            return bet;
        }

        public static Bet RepeatedNumbersBet()
        {
            Bet bet = new Bet();
            bet.BetDate = DateTime.Now.AddMinutes(-1);
            bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 1, 60 };
            return bet;
        }

        //Aposta com valor inválido
        public static Bet NumbersBetOverflow()
        {
            Bet bet = new Bet();
            bet.BetDate = DateTime.Now.AddMinutes(-1);
            //Por possuir mais números que o máximo permitido para apostar irá retornar uma exceção
            bet.NumbersBet = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            return bet;
        }

        public static Bet LackNumbersBet()
        {
            Bet bet = new Bet();
            bet.BetDate = DateTime.Now.AddMinutes(-1);
            //Por possuir mais números que o máximo permitido para apostar irá retornar uma exceção
            bet.NumbersBet = new List<int>() { 1, 2, 3, 4 };
            return bet;
        }
        #endregion

        #region GroupBet
        public static GroupBet ValidGroupBetWithId()
        {
            GroupBet groupBet = new GroupBet();
            groupBet.Id = 1;
            groupBet.CreateDate = DateTime.Now.AddDays(-1);
            groupBet.Organizer = "Organizador";

            return groupBet;
        }
        public static GroupBet InvalidCreateGroupBetDate()
        {
            GroupBet groupBet = new GroupBet();
            groupBet.Id = 1;
            groupBet.CreateDate = DateTime.Now.AddDays(1);
            groupBet.Organizer = "Organizador";

            return groupBet;
        }

        public static GroupBet InvalidGroupBetOrganizer()
        {
            GroupBet groupBet = new GroupBet();
            groupBet.Id = 1;
            groupBet.CreateDate = DateTime.Now.AddDays(-1);
            groupBet.Organizer = "";

            return groupBet;
        }

        public static GroupBet GroupBetEmptyBets()
        {
            GroupBet groupBet = new GroupBet();
            groupBet.Id = 1;
            groupBet.CreateDate = DateTime.Now.AddDays(-1);
            groupBet.Organizer = "Organizador";
            groupBet.Bets = new List<Bet>();

            return groupBet;
        }

        public static GroupBet GroupBetWithBet()
        {
            GroupBet groupBet = new GroupBet();
            groupBet.Id = 1;
            groupBet.CreateDate = DateTime.Now.AddDays(-1);
            groupBet.Organizer = "Organizador";
            groupBet.Bets = new List<Bet>() { ValidBetWithContest() };

            return groupBet;
        }
        #endregion

        #region Contest
        public static Contest ValidContestWithoutId()
        {
            Contest contest = new Contest();
            contest.ContestDate = DateTime.Now.AddDays(1);

            return contest;
        }

        public static Contest ValidContestWithId()
        {
            Contest contest = new Contest();
            contest.Id = 1;
            contest.ContestDate = DateTime.Now.AddDays(1);

            return contest;
        }

        public static Contest InvalidContestWithoutId()
        {
            Contest contest = new Contest();
            contest.ContestDate = DateTime.Now.AddDays(-1);

            return contest;
        }
        #endregion

        #region ContestResult
        public static ContestResult ContestResultWithoutId()
        {
            ContestResult contestResult = new ContestResult();

            contestResult.Bets = new List<Bet>();
            contestResult.ContestResultDate = DateTime.Now.AddDays(1);
            contestResult.WinnerNumbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            return contestResult;
        }

        public static ContestResult ContestResultWithBet()
        {
            ContestResult contestResult = new ContestResult();

            contestResult.Id = 1;
            contestResult.Contest = new Contest() { ContestDate = DateTime.Now };
            contestResult.Bets = new List<Bet>() { ValidBetWithContest() };
            contestResult.ContestResultDate = DateTime.Now.AddDays(1);
            contestResult.WinnerNumbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            return contestResult;
        }
        #endregion
    }
}
