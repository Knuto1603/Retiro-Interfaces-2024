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
                List<CursoModel> cursos = GestionaCursos.ObtenerListaCursos(); // Obtener cursos desde la base de datos
                CargarDatos(cursos); // Mostrar en el GridView
            }
        }
        
        private void CargarDatos(List<CursoModel> listaCursos)
        {
            try
            {
                DataTable dt = new DataTable();

                // Definir columnas para el DataTable
                dt.Columns.Add("Código", typeof(string));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Tipo", typeof(string));
                dt.Columns.Add("Créditos", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                // Llenar el DataTable con la lista de cursos
                foreach (var curso in listaCursos)
                {
                    dt.Rows.Add(curso.getCodigo(), curso.getNombre(), curso.getTipo(), curso.getCreditos(), curso.getEstado());
                }
                
                // Asignar el DataTable al GridView y enlazar los datos
                GridView1.DataSource = dt;
                GridView1.DataBind();
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