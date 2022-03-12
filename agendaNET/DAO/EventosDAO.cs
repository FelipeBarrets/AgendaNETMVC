using agendaNET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace agendaNET.DAO
{
    public class EventosDAO
    {

        private SqlConnection _con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["CONEXAO"].ToString();
            _con = new SqlConnection(constr);
        }



        public List<Eventos> listaEventos(string usuario)
        {
            Connection();
            List<Eventos> dadosConsulta = new List<Eventos>();
            using (SqlCommand cmd = new SqlCommand("buscaEventos", _con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criador", usuario);
                _con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Eventos dados = new Eventos();

                    //PREENCHE OS DADOS DA TABELA DE Eventos
                    #region dados Eventos 


                    try { dados.idEventos = Convert.ToString(reader["idEventos"]); } catch (Exception e) { dados.idEventos = ""; };
                    try { dados.NomeEvento = Convert.ToString(reader["NomeEvento"]); } catch (Exception e) { dados.NomeEvento = ""; };
                    try { dados.descrição = Convert.ToString(reader["descrição"]); } catch (Exception e) { dados.descrição = ""; };
                    try { dados.Data = Convert.ToString(reader["Data"]); } catch (Exception e) { dados.Data = ""; };
                    try { dados.local = Convert.ToString(reader["local"]); } catch (Exception e) { dados.local = ""; };
                    try { dados.participantes = Convert.ToString(reader["participantes"]); } catch (Exception e) { dados.participantes = ""; };
                    try { dados.Tipo = Convert.ToString(reader["Tipo"]); } catch (Exception e) { dados.Tipo = ""; };
                    try { dados.criadorEvento = Convert.ToString(reader["criadorEvento"]); } catch (Exception e) { dados.criadorEvento = ""; };

                    #endregion


                    dadosConsulta.Add(dados);
                }
                _con.Close();
                return dadosConsulta;




            }



        }
        
        public List<Eventos> buscaEvento(string campoBusca, string usuario)
        {
            Connection();
            List<Eventos> dadosConsulta = new List<Eventos>();
            using (SqlCommand cmd = new SqlCommand("buscaEventosPorCampo", _con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criador", usuario);
                cmd.Parameters.AddWithValue("@campoBusca", campoBusca);
                _con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Eventos dados = new Eventos();

                    //PREENCHE OS DADOS DA TABELA DE Eventos
                    #region dados Eventos 


                    try { dados.idEventos = Convert.ToString(reader["idEventos"]); } catch (Exception e) { dados.idEventos = ""; };
                    try { dados.NomeEvento = Convert.ToString(reader["NomeEvento"]); } catch (Exception e) { dados.NomeEvento = ""; };
                    try { dados.descrição = Convert.ToString(reader["descrição"]); } catch (Exception e) { dados.descrição = ""; };
                    try { dados.Data = Convert.ToString(reader["Data"]); } catch (Exception e) { dados.Data = ""; };
                    try { dados.local = Convert.ToString(reader["local"]); } catch (Exception e) { dados.local = ""; };
                    try { dados.participantes = Convert.ToString(reader["participantes"]); } catch (Exception e) { dados.participantes = ""; };
                    try { dados.Tipo = Convert.ToString(reader["Tipo"]); } catch (Exception e) { dados.Tipo = ""; };
                    try { dados.criadorEvento = Convert.ToString(reader["criadorEvento"]); } catch (Exception e) { dados.criadorEvento = ""; };

                    #endregion


                    dadosConsulta.Add(dados);
                }
                _con.Close();
                return dadosConsulta;




            }



        }

        public Eventos buscaEditEvento(string numeroId, string nomeUsuario)
        {

            Connection();
            Eventos dados = new Eventos();

            using (SqlCommand cmd = new SqlCommand("buscaEventosEdit", _con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criador", nomeUsuario);
                //cmd.Parameters.AddWithValue("@VLoBusca1", nomeUsuario);
                cmd.Parameters.AddWithValue("@idEvento", numeroId);

                _con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    #region dados remoção
                    try { dados.idEventos = Convert.ToString(reader["idEventos"]); } catch (Exception e) { dados.idEventos = ""; };
                    try { dados.NomeEvento = Convert.ToString(reader["NomeEvento"]); } catch (Exception e) { dados.NomeEvento = ""; };
                    try { dados.descrição = Convert.ToString(reader["descrição"]); } catch (Exception e) { dados.descrição = ""; };
                    try { dados.Data = Convert.ToString(reader["Data"]); } catch (Exception e) { dados.Data = ""; };
                    try { dados.local = Convert.ToString(reader["local"]); } catch (Exception e) { dados.local = ""; };
                    try { dados.participantes = Convert.ToString(reader["participantes"]); } catch (Exception e) { dados.participantes = ""; };
                    try { dados.Tipo = Convert.ToString(reader["Tipo"]); } catch (Exception e) { dados.Tipo = ""; };
                    try { dados.criadorEvento = Convert.ToString(reader["criadorEvento"]); } catch (Exception e) { dados.criadorEvento = ""; };

                    #endregion



                }
                _con.Close();
                return dados;
            }

        }

        public void inserirEvento(Eventos dados) {

            Connection();
            _con.Open();
            SqlCommand comando = new SqlCommand("eventosInserir", _con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@idEvento", SqlDbType.VarChar, 20).Value = dados.idEventos;
            comando.Parameters.Add("@nomeEvento", SqlDbType.VarChar, 150).Value = dados.NomeEvento;
            comando.Parameters.Add("@descricao", SqlDbType.VarChar, 150).Value = dados.descrição;
            comando.Parameters.Add("@data", SqlDbType.VarChar, 24).Value = dados.Data;
            comando.Parameters.Add("@local", SqlDbType.VarChar, 60).Value = dados.local;
            comando.Parameters.Add("@participantes", SqlDbType.Int).Value = dados.participantes;
            comando.Parameters.Add("@tipo", SqlDbType.VarChar, 50).Value = dados.Tipo;
            comando.Parameters.Add("@criador", SqlDbType.VarChar, 50).Value = dados.criadorEvento;

            comando.ExecuteNonQuery();
            _con.Close();
            

        }


    }
}