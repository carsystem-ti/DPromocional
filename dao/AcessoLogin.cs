using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DPromocional.dao
{
   

    public class AcessoLogin: Dados
    {
        public enum dsFuncao
        {
            AdmSistema = 0,
            supervisor = 1,
            vendedor = 2
        }

        public int idUsuario { get; private set; }
        public string Nome { get; private set; }
        public string Franquia { get; private set; }
        public dsFuncao Funcao { get; private set; }
        public string Codigo { get; private set; }
        public int idFranquia { get; private set; }
        public bool UsaDP { get; private set; }

        public AcessoLogin()
        {
        }

        public AcessoLogin(string usuario, string senha)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@Usuario", usuario),
                                                    new SqlParameter("@senha", senha)
                                            };
                getDataReaderProc("cnxDpromocional", "DinheiroP.pro_getLogin", parametros);
                Codigo = usuario.Substring(0, 6);                
            }
            catch
            {
                throw;
            }
        }

        protected override void leReader(SqlDataReader dataReader)
        {
            if (dataReader.Read())
            {
                idUsuario = dataReader.GetInt16(0); // id_usuario
                Nome = dataReader.GetString(1); // ds_nome
                Franquia = dataReader.GetString(2); // ds_franquia                
                Funcao = (dsFuncao) dataReader.GetInt16(3); // id_funcao
                idFranquia = dataReader.GetInt32(4); // id_usuario
                UsaDP = dataReader.GetBoolean(5);
            }
            else
                throw new Exception("Usuário não encontrado !");
        }
    }
}