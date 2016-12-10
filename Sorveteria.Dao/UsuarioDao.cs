using System.Net;
using Sorveteria.Model;

namespace Sorveteria.Dao
{
    public class UsuarioDao : OracleRepository
    {

        private const string PackageName = "SOR_PG_USUARIO";


        private enum Procedures
        {
            SOR_SP_I_USUARIO,
            SOR_SP_U_USUARIO,
            SOR_SP_S_USUARIO_ID,
        }


        public RequestMessage<SOR_T_USUARIO> GetById(string email, string senha)
        {
            var result = new RequestMessage<SOR_T_USUARIO>
            {
                Procedure = $"{PackageName}.{Procedures.SOR_SP_S_USUARIO_ID}",
                MethodApi = ""
            };

            BeginNewStatement(result.Procedure);
            AddParameter("EMAIL", email);
            AddParameter("SENHA", senha);

            OpenConnection();
            using (var reader = ExecuteReader())
            {
                if (reader.Read())
                {
                    result.Content = new SOR_T_USUARIO
                    {
                        IDUSUARIO = "IDUSUARIO".GetValueOrDefault<long>(reader),
                        EMAIL = "EMAIL".GetValueOrDefault<string>(reader),
                        SENHA = "SENHA".GetValueOrDefault<string>(reader),
                    };
                    return result;
                }
            }

            result.Message = $"Senha inválida!.";
            result.StatusCode = HttpStatusCode.NoContent;
            result.Content = new SOR_T_USUARIO();

            return result;
        }


        public RequestMessage<string> Add(SOR_T_USUARIO entidade, bool commit = false)
        {

            BeginNewStatement(PackageName, Procedures.SOR_SP_I_USUARIO);

            AddResult();
            AddParameter("IDUSUARIO", entidade.IDUSUARIO);
            AddParameter("EMAIL", entidade.EMAIL);
            AddParameter("SENHA", entidade.SENHA);

            return RequestProc("", commit);
        }


        public RequestMessage<string> Update(SOR_T_USUARIO entidade, bool commit = false)
        {

            BeginNewStatement(PackageName, Procedures.SOR_SP_U_USUARIO);

            AddResult();
            AddParameter("IDUSUARIO", entidade.IDUSUARIO);
            AddParameter("EMAIL", entidade.EMAIL);
            AddParameter("SENHA", entidade.SENHA);

            return RequestProc("", commit);
        }

    }
}
