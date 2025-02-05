<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Retiro_Interfaces_2024.Views.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <title>Inicio de Sesión</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DatosNavbar" runat="server">
    <small>No ha iniciado sesión</small>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">

    <div class="container">
        
        <div class="row" id="login">

            <!--Carrucel-->
            <div class="col-md-6 ">
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                    <!-- Indicadores -->
                    <div class="carousel-indicators">
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="3" aria-label="Slide 3"></button>
                    </div>
                    <!-- Imágenes del Carrusel -->
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="\Content\img\1.jpg" class="d-block w-100" alt="Primera Imagen">
                        </div>
                        <div class="carousel-item">
                            <img src="\Content\img\2.jpg" class="d-block w-100" alt="Segunda Imagen">
                        </div>
                        <div class="carousel-item">
                            <img src="\Content\img\3.jpg" class="d-block w-100" alt="Tercera Imagen">
                        </div>
                        <div class="carousel-item">
                            <img src="\Content\img\4.jpg" class="d-block w-100" alt="Tercera Imagen">
                        </div>
                    </div>
                    <!-- Controles -->
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Anterior</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Siguiente</span>
                    </button>
                </div>
                <div class="form-group2">
                    <label>Alumno</label>
                    <label class="switch">
                        <asp:CheckBox ID="cambio" runat="server" />
                        <span class="slider"></span>
                    </label>
                    <label>Secretario Académico</label>
                </div>
            </div>

            <!--Log In-->
            <div class="col-md-6 ">
                <fieldset>
                    <legend>Bienvenido</legend>
                    <div class="derecha">
                        <div class="form-group">
                            <p class="p-login">
                                Atencion !! Los estudiantes reportados por la Unidad de Registro
                            <br />
                                Academico,como observacion de documentos(Promocion 2023), NO se
                            <br />
                                activara horario de inscripcion.
                            <a href="https://academico.unp.edu.pe/doc/listaobservadosURA.pdf" target="_blank">Ver Lista</a>
                            </p>
                        </div>
                        <div class="form-group">
                            <label for="disabledSelect" class="form p-login">Instancia: </label>
                            <select id="disabledSelect" class="form-select">
                                <option>PREGRADO</option>
                                <option>PROGRAMA DE EDUCACIÓN</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="TextInput" data-val-required="El campo C&#243;digo de Alumno es requerido" class="form-label p-login">Código de Alumno:</label>
                            <input type="text" class="form-control" placeholder="Su código universitario" id="codUniversitario" runat="server">
                        </div>

                        <div class="form-group">
                            <label for="TextInput" class="form-label p-login">Clave Web:</label>
                            <input type="password" data-val-required="El campo Clave Web es requerido" class="form-control" placeholder="Su Clave de acceso" id="contraseña" runat="server">
                        </div>
                        <div class="izquierda ">
                            <div class="form-group">
                                <label for="TextInput" class="form-label p-login">Codigo Captcha  :</label>
                                <div class="g-recaptcha" data-sitekey="6LdJy4wqAAAAAJJrGcn6d-oNbhzUHE0eRJNQ6N_E"></div>
                            </div>
                            <br />
                            <a href="https://academico.unp.edu.pe/Cuenta/ResetPassword">¿Ha olvidado su clave de ingreso?</a>
                            <br />
                            <asp:Button ID="btnEnviar" runat="server" Text="Iniciar Sesión" OnClick="btnSubmit_Click" CssClass="btnEnviar"/>
                        </div>
                    </div>
                </fieldset>

            </div>
            Unidentified
        </div>

    </div>

</asp:Content>
