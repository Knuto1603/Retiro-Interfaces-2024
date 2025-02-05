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
using Retiro_Interfaces_2024.Models;

namespace Retiro_Interfaces_2024.Views
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                CargarDatos(); // Mostrar en el GridView
            }
        }


        private void CargarDatos()
        {
            // Instanciar la clase GestionaConexion
            GestionaConexion conexion = new GestionaConexion();
            AlumnoModel miAlumno = WebForm2.alumno;


            try
            {
                // Nombre del procedimiento almacenado
                string procedimiento = "ObtenerDetallesInscripcion";
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@CodigoUniversitario", miAlumno.getCodigoUniversitario());

                // Ejecutar el procedimiento almacenado y obtener los datos
                using (var reader = conexion.ConsultarProcedimiento(procedimiento, parametros))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader); // Cargar los datos desde el SqlDataReader al DataTable

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Manejar el error (puedes mostrar un mensaje o registrar el error)
                Console.WriteLine($"Error al cargar datos: {ex.Message}");
            }
        }
            protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accion")
            {
                if (e.CommandName == "Accion") // Verificamos el comando del botón
                {
                    hfModalState.Value = "true";  // Esto indica que el modal se debe mostrar
                    
                    //Llenar los datos del curso seleccionado

                    
                    int rowIndex;
                    // Verificamos si el CommandArgument es un número
                    if (int.TryParse(e.CommandArgument.ToString(), out rowIndex))
                    {
                        // Accedemos a la fila correspondiente
                        GridViewRow row = GridView1.Rows[rowIndex];

                        // Extraemos los valores de cada celda
                        string cod_Curso = row.Cells[0].Text;
                        string curso = row.Cells[1].Text;      // Columna "Curso"
                        string profesor = row.Cells[2].Text;  // Columna "Profesor"
                        string grupo = row.Cells[3].Text;     // Columna "Grupo"
                        string aula = row.Cells[4].Text;      // Columna "Aula"
                        //Crear un nuevo objeto de curso con los datos obtenidos de la base de datos

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
            if(txtVoucher.Text == "")
            {
                string script = "alert('Ingrese un número de voucher');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
            }
            else
            {
                //Hacer verificación de número de voucher con procedimiento almacenado y gestion de voucher
                
                if (txtVoucher.Text == "12345")
                {
                    
                    Response.Redirect("Solicitud.aspx");
                }
                else
                {
                    string script = "alert('Número de Voucher no valido');";
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
                }
                    
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}