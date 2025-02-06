using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Retiro_Interfaces_2024.Controllers;

namespace Retiro_Interfaces_2024.Views
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private static GestionaConexion conn = new GestionaConexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            try
            {
                string procedimiento = "ObtenerSolicitudesPendientes";
                using (var reader = conn.ConsultarProcedimiento(procedimiento))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos: {ex.Message}");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accion")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string idSolicitud = row.Cells[0].Text;
                Response.Redirect("VistaSolicitudSec.aspx?id=" + idSolicitud);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("VistaSolicitudSec.aspx");
        }
    }

}