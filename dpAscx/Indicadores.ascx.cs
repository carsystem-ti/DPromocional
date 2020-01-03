using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DPromocional.dao;
namespace DPromocional.dpAscx
{
    public partial class Indicadores : System.Web.UI.UserControl
    {
        daoIndicadores bdi = new daoIndicadores();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void BuscaIndicadores()
        {
            DataTable dti = new DataTable();
            dti = bdi.pro_getIndicadores();
            if (dti.Rows.Count > 0)
            {
             
            }
        }
    }
}