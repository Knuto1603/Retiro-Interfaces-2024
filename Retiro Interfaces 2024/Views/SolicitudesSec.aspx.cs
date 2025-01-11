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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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



    }
}