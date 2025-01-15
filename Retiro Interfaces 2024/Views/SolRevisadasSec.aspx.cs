using Retiro_Interfaces_2024.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Retiro_Interfaces_2024.Views
{
    public partial class SolRevisadasSec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            // Instanciar la clase GestionaConexion
            GestionaConexion conexion = new GestionaConexion();

            try
            {
                // Nombre del procedimiento almacenado
                string procedimiento = "CargarDatosSecretario";

                // Ejecutar el procedimiento almacenado y obtener los datos
                using (var reader = conexion.ConsultarProcedimiento(procedimiento))
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

    }
}