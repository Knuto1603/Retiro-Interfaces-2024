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
                <div id="linkContainer">
                    <input type="text" class="form-control link-input" name="links[]" placeholder="Ingresa un enlace" />
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
            var contador = 0;
            const container = document.getElementById("linkContainer");
            //Inhabilirar el campo anterior
            const elementos = container.getElementsByClassName("form-control")
            contador = elementos.length - 1;

            if (contador < 4) {
                elementos.item(contador).disabled = true;
                //Agregar campo nuevo
                const newInput = document.createElement("input");
                newInput.type = "text";
                newInput.className = "form-control link-input";
                newInput.name = "links[]";
                newInput.placeholder = contador.toString();
                container.appendChild(newInput);
            } else {
                alert("Solo puede agragar maximo 5 enlaces.");
            }
            
        }

        function removeLinkInput(){
            var contador = 0;
            const container = document.getElementById("linkContainer");
            const inputs = container.getElementsByClassName("form-control");
            //Inhabilirar el campo anterior
            const elementos = container.getElementsByClassName("form-control")
            contador = elementos.length - 2;
            if (contador >= 0) {
                elementos.item(contador).disabled = false;
                const lastInput = inputs[inputs.length - 1];
                container.removeChild(lastInput);
            }

            //Agregar campo nuevo
        }
</script>

</asp:Content>
