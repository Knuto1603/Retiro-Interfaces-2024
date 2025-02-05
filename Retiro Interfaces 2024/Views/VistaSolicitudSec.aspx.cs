using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Retiro_Interfaces_2024.Views
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private string motiv="";
        private string desic = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            desic = desicion.SelectedValue.ToString();
            CargarEnlaces();
        }

        protected void desicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            desic = desicion.SelectedValue.ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if(motiv == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Motivo no puede estar vacío');", true);
            }
            else
            {

                // Ejecutar el procedimiento para guardar los datos



                //Finalmente redirige la vista a la página anterior
                Response.Redirect("SolicitudesSec.aspx");
            }
        }

        protected void motivo_TextChanged(object sender, EventArgs e)
        {
            motiv=motivo.Text;
        }

        private void CargarEnlaces()
        {
            // Simulación de recuperación de enlaces desde la base de datos
            string enlacesDesdeBD = "http://enlace1.com;http://enlace2.com;http://enlace3.com";

            // Dividir los enlaces por el carácter separador
            string[] enlaces = enlacesDesdeBD.Split(';');

            // Crear hipervínculos dinámicamente
            foreach (string enlace in enlaces)
            {
                HyperLink link = new HyperLink();
                link.NavigateUrl = enlace;
                link.Text = enlace;
                link.Target = "_blank"; // Abrir en una nueva pestaña
                linkContainer.Controls.Add(link);
                linkContainer.Controls.Add(new Literal { Text = "<br />" }); // Añadir un salto de línea
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("SolicitudesSec.aspx");
        }
    }
}