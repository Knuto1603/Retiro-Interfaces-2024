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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }

            // Verificar si se ha presionado el botón de aceptar

        }

        private void CargarDatos()
        {
            // Conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                UPPER(Cu.Nombre) AS Curso, 
                                Concat(UPPER(P.Nombre),' ',UPPER(P.Apellido)) as Profesor, 
                                UPPER(DI.Grupo) AS Grupo, 
                                UPPER(DI.Aula) AS Aula
                                FROM Detalle_Inscripcion DI
                                INNER JOIN Docente D
                                ON DI.ID_Docente = D.ID_Docente
                                INNER JOIN Cursos Cu
                                ON DI.ID_Curso = Cu.ID_Curso
                                INNER JOIN Persona P
                                ON D.ID_Persona = P.ID_Persona"; // Ajusta la consulta según tu base de datos
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accion")
            {
                if (e.CommandName == "Accion") // Verificamos el comando del botón
                {
                    hfModalState.Value = "true";  // Esto indica que el modal se debe mostrar

                    int rowIndex;
                    // Verificamos si el CommandArgument es un número
                    if (int.TryParse(e.CommandArgument.ToString(), out rowIndex))
                    {
                        // Accedemos a la fila correspondiente
                        GridViewRow row = GridView1.Rows[rowIndex];

                        // Extraemos los valores de cada celda
                        string curso = row.Cells[0].Text;      // Columna "Curso"
                        string profesor = row.Cells[1].Text;  // Columna "Profesor"
                        string grupo = row.Cells[2].Text;     // Columna "Grupo"
                        string aula = row.Cells[3].Text;      // Columna "Aula"



                        // Generar el script para mostrar un alert
                        string alertMessage = $"Curso: {curso}\\nProfesor: {profesor}\\nGrupo: {grupo}\\nAula: {aula}";
                        string script = $"alert('{alertMessage}');";

                        // Registrar el script para ejecutarlo en el cliente
                        ClientScript.RegisterStartupScript(this.GetType(), "ShowAlert", script, true);

                        Response.Redirect("Solicitud.aspx?curso=" + curso + "&profesor=" + profesor);

                        
                    }
                    else
                    {
                        // Si no se puede convertir a int, manejar el error (mostrar mensaje, etc.)
                        string errorScript = "alert('Error: No se pudo obtener el índice de la fila.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", errorScript, true);
                    }
                }
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            // Abrir una nueva ventana con el formulario
            string script = "window.open('/Login.aspx', '_blank', 'width=800,height=600');";
            ClientScript.RegisterStartupScript(this.GetType(), "openWindow", script, true);

            // Ocultar el overlay y cerrar el modal
            string hideOverlayScript = "document.getElementById('overlay').style.display = 'none';";
            string hideModalScript = "var myModal = new bootstrap.Modal(document.getElementById('staticBackdrop')); myModal.hide();";
            ClientScript.RegisterStartupScript(this.GetType(), "hideModalAndOverlay", hideOverlayScript + hideModalScript, true);
        }

    }
}