﻿using System;
using Sorveteria.Model;

namespace Sorveteria.Dao
{
    public class Ping : OracleRepository
    {
        public RequestMessage<DateTime> TemosConexao()
        {
            BeginNewQueryStatement("SELECT SYSDATE DATA FROM DUAL");
            OpenConnection();

            using (var r = ExecuteReader())
                if (r.Read())
                {
                    return new RequestMessage<DateTime>
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Message = "Connectado com sucesso!",
                        Content = r.GetValueOrDefault<DateTime>("DATA")
                    };
                }
            ;
            return new RequestMessage<DateTime>
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Message = "Não foi possível connectar!"
            };
        }
    };
}
