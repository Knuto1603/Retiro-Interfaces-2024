using Retiro_Interfaces_2024.Controllers;
using Retiro_Interfaces_2024.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Retiro_Interfaces_2024.Views
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private static GestionaConexion conn = new GestionaConexion();


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
            string motivo = comboBoxMotivo.Text;
            string codigoAlumno = lblCuAlumno.Text;
            string codigoCurso = lblCodigo.Text;
            string detalleMotivo = txtMotivos.Text;
            string enlaceEvidencia = Request.Form["links[]"]; // Captura el primer enlace ingresado

            using (SqlConnection conn1 = conn.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("InsertarSolicitudRetiro", conn1))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoAlumno", codigoAlumno);
                    cmd.Parameters.AddWithValue("@CodigoCurso", codigoCurso);
                    cmd.Parameters.AddWithValue("@CodigoVoucher", WebForm3.numvaucher);
                    cmd.Parameters.AddWithValue("@Motivo", motivo);
                    cmd.Parameters.AddWithValue("@DetalleMotivo", detalleMotivo);
                    cmd.Parameters.AddWithValue("@EnlaceEvidencia", enlaceEvidencia);

                    conn1.Open();
                    object result = cmd.ExecuteScalar();
                    conn1.Close();

                    if (result != null)
                    {
                        string codigoSolicitud = result.ToString();
                        Response.Write("<script>alert('Solicitud registrada con código: " + codigoSolicitud + "');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al registrar la solicitud');</script>");
                    }
                }
            }

            //
            string script = $@"alert('Solicitud Registrada con Éxito');
setTimeout(function() {{
     window.location.href = 'InicioAlumno.aspx';
 }}, 2000);"; // 2000 ms = 2 segundos de espera.
            ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, true);


            //Esto ya estaba
            Response.Redirect("InicioAlumno.aspx");
                    string alert = "alert('Solicitud Registrada con Éxito');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", alert, true);
 
        }
    }
}