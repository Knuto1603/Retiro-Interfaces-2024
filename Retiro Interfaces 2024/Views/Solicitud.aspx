<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Solicitud.aspx.cs" Inherits="Retiro_Interfaces_2024.Views.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DatosNavbar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="NavBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Contenido" runat="server">

    <div class="container">
        <h1 class="title">SOLICITUD DE RETIRO</h1>
        <div class="header">
            <div class="fecha">
                <asp:Label ID="lblFecha" runat="server" Text="" CssClass="fecha-label"></asp:Label>

            </div>
        </div>
        <div class="content">
            <div class="section">
                <h2>Datos del Alumno</h2>
                <p>Cu Alumno:
                    <asp:Label ID="lblCuAlumno" runat="server"></asp:Label></p>
                <p>Nombre:
                    <asp:Label ID="lblNombre" runat="server"></asp:Label></p>
                <p>Apellido:
                    <asp:Label ID="lblApellido" runat="server"></asp:Label></p>
                <p>Escuela Profesional:
                    <asp:Label ID="lblEscuela" runat="server"></asp:Label></p>
                <p>Facultad:
                    <asp:Label ID="lblFacultad" runat="server"></asp:Label></p>
            </div>
            <div class="section">
                <h2>Datos del Curso</h2>
                <p>Código:
                    <asp:Label ID="lblCodigo" runat="server"></asp:Label></p>
                <p>Nombre:
                    <asp:Label ID="lblNombreCurso" runat="server"></asp:Label></p>
                <p>Créditos:
                    <asp:Label ID="lblCreditos" runat="server"></asp:Label></p>
                <p>Docente:
                    <asp:Label ID="lblDocente" runat="server"></asp:Label></p>
            </div>
            <div class="section">
                <h2>Motivos</h2>
                <asp:TextBox ID="txtMotivos" runat="server" TextMode="MultiLine" CssClass="motivos-textbox"></asp:TextBox>
            </div>
            <div class="section">
                <h2>Enlaces de Evidencias</h2>
                <div ID="linkContainer" runat="server">
                    <input type="text" class="form-control link-input" name="links[]" placeholder="Ingrese un enlace" />
                </div>
                <button type="button" onclick="addLinkInput()">Agregar otro enlace</button>
                <button type="button" onclick="removeLinkInput()">Eliminar enlace</button>
            </div>  
            <itemtemplate>
                <asp:Button ID="btnSolicitar" runat="server" Text="Solicitar" CssClass="btn btn-primary" OnClick="btnSolicitar_Click" />
            </itemtemplate>
        </div>
    </div>

    <script>
        // Agregar un nuevo campo de entrada para enlaces
        function addLinkInput() {
            const container = document.getElementById("<%= linkContainer.ClientID %>");
            if (!container) {
                console.error("El contenedor de enlaces no fue encontrado.");
                return;
            }

            let elementos = container.getElementsByClassName("form-control");
            let contador = elementos.length - 1;

            if (contador < 2) {
                if (elementos.length > 0) {
                    elementos.item(contador).disabled = true;
                }

                const newInput = document.createElement("input");
                newInput.type = "text";
                newInput.className = "form-control link-input";
                newInput.name = "links[]";
                newInput.placeholder = "Ingrese un enlace";
                container.appendChild(newInput);
            } else {
                alert("Solo puede agregar un máximo de 3 enlaces.");
            }
        }


        function removeLinkInput() {
            const container = document.getElementById("<%= linkContainer.ClientID %>");
            if (!container) {
                console.error("El contenedor de enlaces no fue encontrado.");
                return;
            }

            const elementos = container.getElementsByClassName("form-control");
            if (elementos.length === 0) {
                console.warn("No hay enlaces para eliminar.");
                return;
            }

            const lastInput = elementos[elementos.length - 1];
            container.removeChild(lastInput);

            if (elementos.length > 1) {
                elementos[elementos.length - 2].disabled = false;
            }
        }

    </script>

</asp:Content>
