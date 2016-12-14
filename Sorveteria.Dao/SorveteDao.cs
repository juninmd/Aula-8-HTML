using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Sorveteria.Model;

namespace Sorveteria.Dao
{
    public class SorveteDao : OracleRepository
    {

        private const string PackageName = "SOR_PG_SORVETE";


        private enum Procedures
        {
            SOR_SP_I_SORVETE,
            SOR_SP_U_SORVETE,
            SOR_SP_D_SORVETE,
            SOR_SP_S_SORVETE,
            SOR_SP_S_SORVETE_ID,
        }


        public RequestMessage<SOR_T_SORVETE> GetById(long ID)
        {
            var result = new RequestMessage<SOR_T_SORVETE>
            {
                Procedure = $"{PackageName}.{Procedures.SOR_SP_S_SORVETE_ID}",
            };

            BeginNewStatement(result.Procedure);
            AddParameter("ID", ID);

            OpenConnection();
            using (var reader = ExecuteReader())
            {
                if (reader.Read())
                {
                    result.Content = new SOR_T_SORVETE
                    {
                        IDSORVETE = "IDSORVETE".GetValueOrDefault<long>(reader),
                        NOME = "NOME".GetValueOrDefault<string>(reader),
                        DESCRICAO = "DESCRICAO".GetValueOrDefault<string>(reader),
                        PRECO = "PRECO".GetValueOrDefault<long>(reader),
                        IDFORNECEDOR = "IDFORNECEDOR".GetValueOrDefault<long>(reader),
                        URLFOTO = "URLFOTO".GetValueOrDefault<string>(reader),
                    };
                    return result;
                }
            }

            result.Message = $"O request de {ID} não foi encontrada.";
            result.StatusCode = HttpStatusCode.NoContent;
            result.Content = new SOR_T_SORVETE();

            return result;
        }

        public RequestMessage<List<SOR_T_SORVETE>> GetAll()
        {
            var result = new RequestMessage<List<SOR_T_SORVETE>>
            {
                Procedure = $"{PackageName}.{Procedures.SOR_SP_S_SORVETE}",
                Content = new List<SOR_T_SORVETE>()
            };

            BeginNewStatement(result.Procedure);

            OpenConnection();
            using (var reader = ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Content.Add(new SOR_T_SORVETE
                    {
                        IDSORVETE = "IDSORVETE".GetValueOrDefault<decimal>(reader),
                        NOME = "NOME".GetValueOrDefault<string>(reader),
                        DESCRICAO = "DESCRICAO".GetValueOrDefault<string>(reader),
                        PRECO = "PRECO".GetValueOrDefault<double>(reader),
                        IDFORNECEDOR = "IDFORNECEDOR".GetValueOrDefault<decimal>(reader),
                        URLFOTO = "URLFOTO".GetValueOrDefault<string>(reader),
                    });
                }
            }

            if (!result.Content.Any())
                result.StatusCode = HttpStatusCode.NoContent;

            return result;
        }

        public RequestMessage<string> Add(SOR_T_SORVETE entidade, bool commit = false)
        {

            BeginNewStatement(PackageName, Procedures.SOR_SP_I_SORVETE);

            AddResult();
            AddParameter("IDSORVETE", entidade.IDSORVETE);
            AddParameter("NOME", entidade.NOME);
            AddParameter("DESCRICAO", entidade.DESCRICAO);
            AddParameter("PRECO", entidade.PRECO);
            AddParameter("IDFORNECEDOR", entidade.IDFORNECEDOR);

            return RequestProc("", commit);
        }


        public RequestMessage<string> Update(SOR_T_SORVETE entidade, bool commit = false)
        {

            BeginNewStatement(PackageName, Procedures.SOR_SP_U_SORVETE);

            AddResult();
            AddParameter("IDSORVETE", entidade.IDSORVETE);
            AddParameter("NOME", entidade.NOME);
            AddParameter("DESCRICAO", entidade.DESCRICAO);
            AddParameter("PRECO", entidade.PRECO);
            AddParameter("IDFORNECEDOR", entidade.IDFORNECEDOR);

            return RequestProc("", commit);
        }

    }
}

