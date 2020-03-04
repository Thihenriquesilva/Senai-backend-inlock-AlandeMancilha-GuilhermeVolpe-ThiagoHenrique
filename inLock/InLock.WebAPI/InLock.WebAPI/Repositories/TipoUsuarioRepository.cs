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
        private string _stringConexao = "Data Source=HP440G1\\SQLEXPRESS; initial catalog=DB_InLock; user Id=sa; pwd=Amss@951620";

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> listaTiposUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                string query = "SELECT IdTipoUsuario, TituloTipoUsuario FROM TBL_TipoUsuario";


                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            TituloTipoUsuario = rdr["TituloTipoUsuario"].ToString()
                        };

                        listaTiposUsuario.Add(tipoUsuario);
                    }
                }
            }
            return listaTiposUsuario;
        }


        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                string query = "INSERT INTO TBL_TipoUsuario(TituloTipoUsuario) VALUES (@TituloTipoUsuario) ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("TituloTipoUsuario", novoTipoUsuario.TituloTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
