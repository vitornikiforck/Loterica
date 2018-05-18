using Loterica.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Common.Tests.Base
{
    public class BaseSqlTest
    {

        private const string RECREATE_BET_TABLE = "DELETE FROM [dbo].[TBAposta] DBCC CHECKIDENT('TBAposta', RESEED, 0)";
        private const string RECREATE_GROUPBET_TABLE = "DELETE FROM [dbo].[TBBolao] DBCC CHECKIDENT('TBBolao', RESEED, 0)";
        private const string RECREATE_CONTEST_TABLE = "DELETE FROM [dbo].[TBConcurso] DBCC CHECKIDENT('TBConcurso', RESEED, 0)";
        //private const string RECREATE_BET_TABLE = "TRUNCATE TABLE [dbo].[TBAposta]";
        //private const string RECREATE_GROUPBET_TABLE = "TRUNCATE TABLE [dbo].[TBBolao]";
        //private const string RECREATE_CONTEST_TABLE = "TRUNCATE TABLE [dbo].[TBConcurso]";
        private const string INSERT_CONTEST_TABLE = "INSERT INTO TBConcurso(DataConcurso) VALUES (GETDATE())";
        private const string INSERT_GROUPBET_TABLE = "INSERT INTO TBBolao(DataCriacao, Organizador) VALUES (GETDATE(), 'Lotérica')";
        private const string INSERT_BET = "INSERT INTO TBAposta(DataAposta, NumerosAposta, Valor, Concurso_Id, Bolao_Id) VALUES (GETDATE(), '01 02 03 04 05 06', 3.50, 1, 1)";
        
        public static void SeedDatabase()
        {
            Db.Update(RECREATE_BET_TABLE);
            Db.Update(RECREATE_CONTEST_TABLE);
            Db.Update(RECREATE_GROUPBET_TABLE);
            Db.Update(INSERT_CONTEST_TABLE);
            Db.Update(INSERT_GROUPBET_TABLE);
            Db.Update(INSERT_BET);
        }
    }
}
