using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Retiro_Interfaces_2024
{
    public partial class MasterAlumno : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCuAlumno.Text = Session["codUniversitario"].ToString();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Elimina toda la sesión
            Session.Clear(); // Limpia los datos almacenados
            Response.Redirect("Login.aspx"); // Redirige al login
        }




    }


}