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
        private string _stringConexao = "Data Source=HP440G1\\SQLEXPRESS; initial catalog=DB_InLock; user Id=sa; pwd=Amss@951620";


        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                string query = "SELECT * FROM TBL_Usuario INNER JOIN TBL_TipoUsuario ON FK_IdTipoUsuario = IdTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            FK_IdTipoUsuario = Convert.ToInt32(rdr["FK_IdTipoUsuario"]),
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["FK_IdTipoUsuario"]),
                                TituloTipoUsuario = Convert.ToString(rdr["TituloTipoUsuario"])
                            }
                        };

                        listaUsuarios.Add(usuario);
                    }
                }
            }
            return listaUsuarios;
        }


        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                string queryInsert = "INSERT INTO TBL_Usuario(Email, Senha, FK_IdTipoUsuario) VALUES (@Email, @Senha, @FK_IdTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
                    cmd.Parameters.AddWithValue("@FK_IdTipoUsuario", novoUsuario.FK_IdTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                string query = "SELECT IdUsuario, Email, FK_IdTipoUsuario, TituloTipoUsuario FROM TBL_Usuario INNER JOIN TBL_TipoUsuario ON FK_IdTipoUsuario = IdTipoUsuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain();

                        usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);
                        usuario.Email = rdr["Email"].ToString();
                        usuario.FK_IdTipoUsuario = Convert.ToInt32(rdr["FK_IdTipoUsuario"]);
                        usuario.TipoUsuario = new TipoUsuarioDomain();
                        usuario.TipoUsuario.IdTipoUsuario = Convert.ToInt32(rdr["FK_IdTipoUsuario"]);
                        usuario.TipoUsuario.TituloTipoUsuario = rdr["TituloTipoUsuario"].ToString();
                                        
                        return usuario;
                    }
                }
                return null;
            }
        }

    }
}
