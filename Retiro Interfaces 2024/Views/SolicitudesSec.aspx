<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSecretario.master" AutoEventWireup="true" CodeBehind="SolicitudesSec.aspx.cs" Inherits="Retiro_Interfaces_2024.Views.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoAlumno" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="IdSolicitud" HeaderText="ID" ItemStyle-CssClass="fila-grid" />
            <asp:BoundField DataField="NombreAlumno" HeaderText="Nombre Solicitante" ItemStyle-CssClass="fila-grid" />
            <asp:BoundField DataField="EstadoSolicitud" HeaderText="Estado" ItemStyle-CssClass="fila-grid" />
            <asp:TemplateField ItemStyle-CssClass="fila-grid">
                <ItemTemplate>
                    <asp:Button ID="btnAccion" runat="server" Text="Ver Solicitud" CommandName="Accion" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
