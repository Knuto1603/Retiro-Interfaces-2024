<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAlumno.master" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="Retiro_Interfaces_2024.Views.Solicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoAlumno" runat="server">

    <style>
    .grid-style {
        width: 100%;
        border-collapse: collapse;
        text-align: center;
    }

    .grid-style th, 
    .grid-style td {
        border: 1px solid #ddd;
        padding: 10px;
        text-align: center;
    }

    .grid-style th {
        background-color: #f2f2f2;
        font-weight: bold;
    }

    .fila-grid {
        text-align: center;
    }
    </style>

    <div class="contenido">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="grid-style">
            <Columns>
                <asp:BoundField DataField="codigoSolicitud" HeaderText="CODIGO" ItemStyle-CssClass="fila-grid" />
                <asp:BoundField DataField="Curso" HeaderText="CURSO"></asp:BoundField>
                <asp:BoundField DataField="codigoVoucher" HeaderText="VOUCHER"></asp:BoundField>
                <asp:BoundField DataField="fechaHora" HeaderText="FECHA"></asp:BoundField>
                <asp:BoundField DataField="estado" HeaderText="ESTADO"></asp:BoundField>
                <asp:BoundField DataField="motivo" HeaderText="MOTIVO"></asp:BoundField>
                <asp:BoundField DataField="detallemotivo" HeaderText="DETALLE"></asp:BoundField>
                <asp:BoundField DataField="urlEvidencia" HeaderText="URL"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
