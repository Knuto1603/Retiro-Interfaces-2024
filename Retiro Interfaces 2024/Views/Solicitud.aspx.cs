using Retiro_Interfaces_2024.Controllers;
using Retiro_Interfaces_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Retiro_Interfaces_2024.Views
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        
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
                mostrarDatosCurso();
            }

            mostrarDatosAlumno();

        }

        public void mostrarDatosAlumno() {
            AlumnoModel miAlumno = WebForm2.alumno;
            lblNombre.Text = miAlumno.getPersona().getNombre();
            lblApellido.Text = miAlumno.getPersona().getApellido();
            lblCuAlumno.Text = miAlumno.getCodigoUniversitario();
            lblEscuela.Text = miAlumno.getEscuela().getNombre();
            lblFacultad.Text = miAlumno.getEscuela().getFacultad().getNombre();
        }

        public void mostrarDatosCurso() {

            CursoRetiroModel cursoRetiro;

            cursoRetiro = GestionaCursoRetiro.ObtenerCursoDeBD(WebForm3.cod_Curso);
            lblCodigo.Text = cursoRetiro.GetCodigo();
            lblNombreCurso.Text = cursoRetiro.GetNombre();
            lblCreditos.Text = cursoRetiro.GetCreditos();
            lblDocente.Text = cursoRetiro.GetDocente();

        }

        //preguntar a sergio que muestra esto
        public void obtenerDatos(String curso, String profesor)
        {
            lblDocente.Text = profesor;
            lblNombreCurso.Text = curso;
        }


        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioAlumno.aspx");
            string alert = "alert('Solicitud Registrada con Éxito');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", alert, true);
        }
    }
}