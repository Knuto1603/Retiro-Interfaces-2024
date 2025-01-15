using Retiro_Interfaces_2024.Models;
using Retiro_Interfaces_2024.Views;
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
            AlumnoModel miAlumno = WebForm2.alumno;
            lblCuAlumno.Text = miAlumno.getCodigoUniversitario();
            lblEscuela.Text = miAlumno.getEscuela().getNombre();
            lblFacultad.Text = miAlumno.getEscuela().getFacultad().getNombre();
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx"); // Redirige al login
        }
    }
}