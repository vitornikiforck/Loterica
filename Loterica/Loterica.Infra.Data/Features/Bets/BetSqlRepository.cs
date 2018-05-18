using Loterica.Domain.Exceptions;
using Loterica.Domain.Features.Bets;
using Loterica.Domain.Features.Contests;
using Loterica.Domain.Features.GroupBets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Infra.Data.Features.Bets
{
    public class BetSqlRepository : IBetRepository
    {
        #region SQL Script
        private const string _sqlInsertBet = @"INSERT INTO TBAposta
                                                VALUES (@DataAposta, @NumerosAposta, @Valor, @Concurso_Id, @Bolao_Id)";
        private const string _sqlUpdateBet = @"UPDATE TBAposta
                                                SET
                                                    DataAposta = @DataAposta,
                                                    NumerosAposta = @NumerosAposta,
                                                    Valor = @Valor,
                                                    Concurso_Id = @Concurso_Id,
                                                    Bolao_Id = @Bolao_Id
                                                WHERE
                                                    IdAposta = @IdAposta";
        private const string _sqlGetById = @"SELECT IdAposta, DataAposta, NumerosAposta, Valor, Concurso_Id, Bolao_Id FROM TBAposta
                                                WHERE IdAposta = @IdAposta";
        private const string _sqlGetAll = @"SELECT IdAposta, DataAposta, NumerosAposta, Valor, Concurso_Id, Bolao_Id FROM TBAposta";
        private const string _sqlDeleteBet = @"DELETE FROM TBAposta
                                                WHERE IdAposta = @IdAposta";
        #endregion

        public void Delete(Bet bet)
        {
            if (bet.Id == 0)
                throw new IdentifierUndefinedException();

            var parms = new object[] { "IdAposta", bet.Id };

            Db.Delete(_sqlDeleteBet, parms);
        }

        public Bet Get(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            var parms = new object[] { "IdAposta", id };
            return Db.Get(_sqlGetById, Make, parms);
        }

        public IEnumerable<Bet> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Bet Save(Bet bet)
        {
            bet.Validate();
            bet.Id = Db.Insert(_sqlInsertBet, Take(bet));

            return bet;
        }

        public Bet Update(Bet bet)
        {
            bet.Validate();
            Db.Update(_sqlUpdateBet, Take(bet));

            return bet;
        }

        /// <summary>
        /// Cria um objeto Bet baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Bet> Make = reader =>
           new Bet
           {
               Id = Convert.ToInt64(reader["IdAposta"]),
               BetDate = Convert.ToDateTime(reader["DataAposta"]),
               NumbersBet = NumbersBetStringToList(Convert.ToString(reader["NumerosAposta"])),
               Contest = new Contest() { Id = Convert.ToInt64(reader["Concurso_Id"]) },
               GroupBet = new GroupBet() { Id = (reader["Bolao_Id"] != DBNull.Value) ? Convert.ToInt64((reader["Bolao_Id"])) : 0 }
           };

        /// <summary>
        /// Cria a lista de parametros do objeto Bet para passar para o comando Sql
        /// </summary>
        /// <param name="bet">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Bet bet)
        {
            return new object[]
            {
                "@IdAposta", bet.Id,
                "@DataAposta", bet.BetDate,
                "@NumerosAposta", NumbersBetListToString(bet.NumbersBet),
                "@Valor", bet.Value,
                "@Concurso_Id", bet.Contest.Id,
                "@Bolao_Id", (bet.GroupBet != null) ? (Object)bet.GroupBet.Id : DBNull.Value
            };
        }

        private static List<int> NumbersBetStringToList(string NumbersBet)
        {
            List<int> numbersBet = new List<int>();

            string[] numbers = NumbersBet.Split(' ');

            for (int i = 0; i < numbers.Length; i++)
                numbersBet.Add(Convert.ToInt32(numbers[i]));

            return numbersBet;
        }

        private string NumbersBetListToString(List<int> NumbersBet)
        {
            string numbersBet = string.Empty;

            if (NumbersBet.Count > 0)
            {
                foreach (int i in NumbersBet)
                {
                    if (i < 10)
                        numbersBet += "0" + i.ToString() + " ";
                    else
                        numbersBet += i.ToString() + " ";
                }
            }

            numbersBet = numbersBet.Remove(numbersBet.Length - 1);

            return numbersBet;
        }
    }
}
