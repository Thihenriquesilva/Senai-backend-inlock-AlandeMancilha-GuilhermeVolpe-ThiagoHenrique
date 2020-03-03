using InLock.WebAPI.Domains;
using InLock.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV1201\\SQLEXPRESS; initial catalog=DB_InLock; user Id=sa; pwd=sa@132";


        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tiposUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, TituloTipoUsuario FROM TBL_TipoUsuario";
                

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tpUsers = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            TituloTipoUsuario = rdr["TituloTipoUsuario"].ToString()
                        };

                        tiposUsuario.Add(tpUsers);
                    }
                }
            }
            return tiposUsuario;
        }

        public void Cadastrar (TipoUsuarioDomain tipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TBL_TipoUsuario(TituloTipoUsuario) VALUES (@TituloTipoUsuario) ";

                using(SqlCommand cmd = new SqlCommand (queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("TituloTipoUsuario", tipoUsuario.TituloTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
