<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSecretario.master" AutoEventWireup="true" CodeBehind="VistaSolicitudSec.aspx.cs" Inherits="Retiro_Interfaces_2024.Views.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoAlumno" runat="server">


    <div class="contenido-motivo">

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
                    <p>
                        Cu Alumno:
                 <asp:Label ID="lblCuAlumno" runat="server"></asp:Label>
                    </p>
                    <p>
                        Nombre:
                 <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </p>
                    <p>
                        Apellido:
                 <asp:Label ID="lblApellido" runat="server"></asp:Label>
                    </p>
                    <p>
                        Escuela Profesional:
                 <asp:Label ID="lblEscuela" runat="server"></asp:Label>
                    </p>
                    <p>
                        Facultad:
                 <asp:Label ID="lblFacultad" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="section">
                    <h2>Datos del Curso</h2>
                    <p>
                        Código:
                 <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                    </p>
                    <p>
                        Nombre:
                 <asp:Label ID="lblNombreCurso" runat="server"></asp:Label>
                    </p>
                    <p>
                        Créditos:
                 <asp:Label ID="lblCreditos" runat="server"></asp:Label>
                    </p>
                    <p>
                        Docente:
                 <asp:Label ID="lblDocente" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="section">
                    <h2>Motivos</h2>
                    <asp:TextBox ID="txtMotivos" runat="server" TextMode="MultiLine" CssClass="motivos-textbox" Enabled="false"></asp:TextBox>
                </div>
                <div class="section">
                    <h2>Enlaces de Evidencias</h2>
                    <div id="linkContainer" runat="server">
                        <!--Enlaces agregados dinamicamente en el back-->

                    </div>
                </div>
               
            </div>
        </div>





        <asp:TextBox ID="motivo" runat="server" CssClass="motivo" OnTextChanged="motivo_TextChanged"></asp:TextBox>
        <asp:ListBox ID="desicion" runat="server" SelectionMode="Multiple" CssClass="form-control" OnSelectedIndexChanged="desicion_SelectedIndexChanged">
            <asp:ListItem Text="Aprobar" Value="Aprobar" />
            <asp:ListItem Text="Rechazar" Value="Rechazar" />
        </asp:ListBox>

        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
        </div>



    </div>

</asp:Content>
