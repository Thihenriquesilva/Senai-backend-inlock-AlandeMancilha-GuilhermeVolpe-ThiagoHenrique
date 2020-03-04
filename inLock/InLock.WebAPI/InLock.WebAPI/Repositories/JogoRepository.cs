using InLock.WebAPI.Domains;
using InLock.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string _stringConexao = "Data Source=HP440G1\\SQLEXPRESS; initial catalog=DB_InLock; user Id=sa; pwd=Amss@951620";


        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                string query = "INSERT INTO TBL_Jogo(NomeJogo, Descricao, DataLancamento, Valor, FK_IdEstudio) VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor, @FK_IdEstudio)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@FK_IdEstudio", novoJogo.FK_IdEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<JogoDomain> Listar()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                string query = "SELECT * FROM TBL_Jogo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = rdr["DataLancamento"].ToString(),
                            Valor = Convert.ToDouble(rdr["Valor"]),
                            FK_IdEstudio = Convert.ToInt32(rdr["FK_IdEstudio"])
                        };

                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }

    }
}
