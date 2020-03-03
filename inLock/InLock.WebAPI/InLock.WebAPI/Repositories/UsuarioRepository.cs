using InLock.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Repositories
{
    public class UsuarioRepository
    {

        //private string stringConexao = "Data Source=DEV1201\\SQLEXPRESS; initial catalog=DB_InLock; user Id=sa; pwd=sa@132";

        //private string stringConexao = "Data Source=LAPTOP-OMA8SO3J\\SQLEXPRESS; initial catalog=DB_InLock; user Id=sa; pwd=thi@2357";
        private string stringConexao = "Server = localhost\\SQLEXPRESS;Database=DB_InLock;Trusted_Connection=True";


        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> users = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM TBL_Usuario INNER JOIN TBL_TipoUsuario ON FK_IdTipoUsuario = IdTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain user = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            Fk_TipoUsuario = Convert.ToInt32(rdr["FK_IdTipoUsuario"]),
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["FK_IdTipoUsuario"]),
                                TituloTipoUsuario = Convert.ToString(rdr["TituloTipoUsuario"])
                            }
                        };

                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert= "INSERT INTO TBL_Usuario(Email, Senha, FK_IdTipoUsuario) VALUES (@Email, @Senha, @FK_IdTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
                    cmd.Parameters.AddWithValue("@FK_IdTipoUsuario", novoUsuario.Fk_TipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

