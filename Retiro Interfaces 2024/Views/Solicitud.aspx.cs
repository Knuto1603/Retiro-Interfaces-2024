using Retiro_Interfaces_2024.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Retiro_Interfaces_2024.Views
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        AlumnoModel miAlumno = WebForm2.alumno;
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                // Obtener los datos del QueryString

                string curso = Request.QueryString["curso"];
                string profesor = Request.QueryString["profesor"];

                // Llamar al método para mostrar los datos
                obtenerDatos(curso, profesor);

            }
            
            lblNombre.Text = miAlumno.getPersona().getNombre();
            lblApellido.Text = miAlumno.getPersona().getApellido();
            lblCuAlumno.Text = miAlumno.getCodigoUniversitario();
            lblEscuela.Text = miAlumno.getEscuela().getNombre();
            lblFacultad.Text = miAlumno.getEscuela().getFacultad().getNombre();


        }

        public void obtenerDatos(String curso, String profesor)
        {
            lblDocente.Text = profesor;
            lblNombreCurso.Text = curso;
        }


        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            string script = $@"
            alert('Solicitud Registrada con Éxito');
            setTimeout(function() {{
                window.location.href = 'InicioAlumno.aspx';
            }}, 2000);"; // 2000 ms = 2 segundos de espera.

            // Registrar el script para que se ejecute en el cliente.
            ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, true);
        }



     }
}