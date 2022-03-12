using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace agendaNET.DAO
{
    public class UsuarioDAO
    {
        private SqlConnection _con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["CONEXAO"].ToString();
            _con = new SqlConnection(constr);
        }

        public bool Logar(string Login, string Senha)
        {

            var ret = false;
            Connection();
            _con.Open();
            SqlCommand comando = new SqlCommand("loginAgenda", _con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@usuario", SqlDbType.VarChar, 20).Value = Login;
            comando.Parameters.Add("@senha", SqlDbType.VarChar, 7).Value = Senha;
            ret = ((int)comando.ExecuteScalar() > 0);
            return ret;


        }
    }
}