using System.Collections.Generic;
using System.Net;
using Sorveteria.Model;

namespace Sorveteria.Dao
{
    public class FornecedorDao : OracleRepository
    {

        private const string PackageName = "SOR_PG_FORNECEDOR";


        private enum Procedures
        {
            SOR_SP_I_FORNECEDOR,
            SOR_SP_U_FORNECEDOR,
            SOR_SP_D_FORNECEDOR,
            SOR_SP_S_FORNECEDOR,
            SOR_SP_S_FORNECEDOR_ID
        }


        public RequestMessage<SOR_T_FORNECEDOR> GetById(long ID)
        {
            var result = new RequestMessage<SOR_T_FORNECEDOR>
            {
                Procedure = $"{PackageName}.{Procedures.SOR_SP_S_FORNECEDOR_ID}",
                MethodApi = ""
            };

            BeginNewStatement(result.Procedure);
            AddParameter("ID", ID);

            OpenConnection();
            using (var reader = ExecuteReader())
            {
                if (reader.Read())
                {
                    result.Content = new SOR_T_FORNECEDOR
                    {
                        IDFORNECEDOR = "IDFORNECEDOR".GetValueOrDefault<long>(reader),
                        NOME = "NOME".GetValueOrDefault<string>(reader),
                        CNPJ = "CNPJ".GetValueOrDefault<long>(reader),
                        ENDERECO = "ENDERECO".GetValueOrDefault<string>(reader),
                        TELEFONE = "TELEFONE".GetValueOrDefault<long>(reader),
                    };
                    return result;
                }
            }

            result.Message = $"O request de {ID} não foi encontrada.";
            result.StatusCode = HttpStatusCode.NoContent;
            result.Content = new SOR_T_FORNECEDOR();

            return result;
        }

        public RequestMessage<List<SOR_T_FORNECEDOR>> GetAll()
        {
            var result = new RequestMessage<List<SOR_T_FORNECEDOR>>
            {
                Procedure = $"{PackageName}.{Procedures.SOR_SP_S_FORNECEDOR}",
                MethodApi = "",
                Content = new List<SOR_T_FORNECEDOR>()
            };

            BeginNewStatement(result.Procedure);

            OpenConnection();
            using (var reader = ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Content.Add(new SOR_T_FORNECEDOR
                    {
                        IDFORNECEDOR = "IDFORNECEDOR".GetValueOrDefault<long>(reader),
                        NOME = "NOME".GetValueOrDefault<string>(reader),
                        CNPJ = "CNPJ".GetValueOrDefault<long>(reader),
                        ENDERECO = "ENDERECO".GetValueOrDefault<string>(reader),
                        TELEFONE = "TELEFONE".GetValueOrDefault<long>(reader),
                    });
                    return result;
                }
            }

            result.StatusCode = HttpStatusCode.NoContent;

            return result;
        }


        public RequestMessage<string> Add(SOR_T_FORNECEDOR entidade, bool commit = false)
        {

            BeginNewStatement(PackageName, Procedures.SOR_SP_I_FORNECEDOR);

            AddResult();
            AddParameter("NOME", entidade.NOME);
            AddParameter("CNPJ", entidade.CNPJ);
            AddParameter("ENDERECO", entidade.ENDERECO);
            AddParameter("TELEFONE", entidade.TELEFONE);

            return RequestProc("", commit);
        }


        public RequestMessage<string> Update(SOR_T_FORNECEDOR entidade, bool commit = false)
        {

            BeginNewStatement(PackageName, Procedures.SOR_SP_U_FORNECEDOR);

            AddResult();
            AddParameter("IDFORNECEDOR", entidade.IDFORNECEDOR);
            AddParameter("NOME", entidade.NOME);
            AddParameter("CNPJ", entidade.CNPJ);
            AddParameter("ENDERECO", entidade.ENDERECO);
            AddParameter("TELEFONE", entidade.TELEFONE);

            return RequestProc("", commit);
        }

    }
}
