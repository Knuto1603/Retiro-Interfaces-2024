using Newtonsoft.Json;
using Retiro_Interfaces_2024.Controllers;
using Retiro_Interfaces_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Retiro_Interfaces_2024.Views
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        public static AlumnoModel alumno;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public class RecaptchaResponse
        {
            public bool success { get; set; }
            public string challenge_ts { get; set; }
            public string hostname { get; set; }
        }

        protected void iniciarSesion()
        {
            string codU = codUniversitario.Value.ToString();
            string password = contraseña.Value.ToString();

            GestionaAlumno gAlumno = new GestionaAlumno();

            bool userValido = gAlumno.VerificarAlumno(codU);
            bool valido = gAlumno.VerificarContraseña(codU, password);

            if (userValido)
            {
                Response.Write("Usuario valido");
                if (valido)
                {

                    bool cam = cambio.Checked;
                    if (cam)
                    {
                        Response.Redirect("InicioSecretario.aspx");
                    }
                    else
                    {
                        alumno = gAlumno.crearAlumno(codU);
                        Response.Redirect("InicioAlumno.aspx");
                    }
                }
                else
                {
                    Response.Write("Contraseña no valida");
                }
            }
            else
            {
                Response.Write("Usuario no valido");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            iniciarSesion();
            

            /*
            string recaptchaResponse = Request.Form["g-recaptcha-response"];
            string secretKey = "6LdJy4wqAAAAAClHbGR7Y63YywzJXstXWTFdabt_"; // La clave secreta que obtuviste de Google
            string apiUrl = $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={recaptchaResponse}";

            using (WebClient client = new WebClient())
            {
                string result = client.DownloadString(apiUrl);
                RecaptchaResponse response = JsonConvert.DeserializeObject<RecaptchaResponse>(result);

                if (response.success)
                {
                    Response.Write("Validación exitosa.");
                }
                else
                {
                    Response.Write("Validación fallida.");
                }
            }*/

        }
    }
}