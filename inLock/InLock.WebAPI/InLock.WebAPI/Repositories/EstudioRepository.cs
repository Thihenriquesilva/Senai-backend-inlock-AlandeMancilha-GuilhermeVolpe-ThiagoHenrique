using InLock.WebAPI.Domains;
using InLock.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.WebAPI.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string _stringConexao = "Data Source=HP440G1\\SQLEXPRESS; initial catalog=DB_InLock; user Id=sa; pwd=Amss@951620";


        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                string query = "INSERT INTO TBL_Estudio(NomeEstudio) VALUES (@NomeEstudio)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NomeEstudio", novoEstudio.NomeEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<EstudioDomain> Listar()
        {
            // CRIA UMA LISTA EstudioDomain ONDE SERÃO ARMAZENADOS OS DADOS
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            // DECLARA O SqlConnection PASSANDO A STRING DE CONEXÃO
            using (SqlConnection con = new SqlConnection(_stringConexao))
            {
                // INSTRUÇÃO T-SQL A SER EXECUTADA
                string query = "SELECT * FROM TBL_Estudio";

                // ABRE A CONEXÃO COM O BANCO DE DADOS
                con.Open();

                // DECLARA O SqlDataReader PARA RECEBER OS DADOS DA LEITURA DO BANCO DE DADOS
                SqlDataReader rdr;

                // DECLARA O SqlCommand PASSANDO A query A SER EXECUTADA E A CONEXÃO
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // EXECUTA A QUERY E ARMAZENA OS DADOS NO rdr
                    rdr = cmd.ExecuteReader();

                    // ENQUANTO HOUVER REGISTROS PARA SEREM LIDOS NO rdr, O LAÇO SE REPETIRÁ.
                    while (rdr.Read())
                    {
                        // INSTANCIA UM OBJETO estudio DA CLASSE EstudioDomain
                        EstudioDomain estudio = new EstudioDomain
                        {   
                            //ATRIBUI AS PROPRIEDADES OS VALORES DAS COLUNAS DA TBL_Estudio

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        // ADICIONA O OBJETO estudio À listaEstudios
                        listaEstudios.Add(estudio);
                    }
                }
            }
            //RETORNA listaEstudios
            return listaEstudios;
        }   
        
    }
}
