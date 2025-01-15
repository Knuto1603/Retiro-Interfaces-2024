<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSecretario.master" AutoEventWireup="true" CodeBehind="SolRevisadasSec.aspx.cs" Inherits="Retiro_Interfaces_2024.Views.SolRevisadasSec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoAlumno" runat="server">

     <div class="contenido">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="grid-style">
         <Columns>
             <asp:BoundField DataField="Voucher" HeaderText="Código de Voucher" ItemStyle-CssClass="fila-grid" />
             <asp:BoundField DataField="Curso" HeaderText="Curso" ItemStyle-CssClass="fila-grid" />
             <asp:BoundField DataField="Fecha" HeaderText="Fecha" ItemStyle-CssClass="fila-grid" />
             <asp:BoundField DataField="Motivo" HeaderText="Motivo" ItemStyle-CssClass="fila-grid" />
             <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-CssClass="fila-grid" />
         </Columns>
     </asp:GridView>
 </div>

</asp:Content>
