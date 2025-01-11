<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAlumno.master" AutoEventWireup="true" CodeBehind="CursosDisp.aspx.cs" Inherits="Retiro_Interfaces_2024.Views.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoAlumno" runat="server">
    <div class="contenido">
        <!-- Modal -->
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Validación de Voucher</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="TextInput" data-val-required="El campo C&#243;digo de Alumno es requerido" class="form-label p-login">Código de Voucher:</label>
                            <input type="text" class="form-control" id="voucherCode" placeholder="Código de Voucher">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-primary" id="btnAccept">Verificar</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- GridView -->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Curso" HeaderText="Nombre Curso" ItemStyle-CssClass="fila-grid" />
                <asp:BoundField DataField="Profesor" HeaderText="Nombre Profesor" ItemStyle-CssClass="fila-grid" />
                <asp:BoundField DataField="Grupo" HeaderText="Grupo" ItemStyle-CssClass="fila-grid" />
                <asp:BoundField DataField="Aula" HeaderText="Aula" ItemStyle-CssClass="fila-grid" />
                <asp:TemplateField ItemStyle-CssClass="fila-grid">
                    <ItemTemplate>
                        <asp:Button ID="btnAccion" runat="server" Text="Solicitar" CommandName="Accion" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <!-- HiddenField -->
        <asp:HiddenField ID="hfModalState" runat="server" />
    </div>

    <!-- Overlay para bloquear la página principal -->
    <div id="overlay" style="display:none; position: fixed; top: 0; left: 0; width: 100%; height: 100%; background: rgba(0, 0, 0, 0.5); z-index: 9999;"></div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            // Verifica si el HiddenField indica que la modal debe mostrarse
            var modalState = document.getElementById('<%= hfModalState.ClientID %>').value;
            if (modalState === "true") {
                var myModal = new bootstrap.Modal(document.getElementById('staticBackdrop'));
                myModal.show();
            }

            // Lógica para validar el input y cerrar la modal
            document.getElementById('btnAccept').addEventListener('click', function () {
                var inputField = document.getElementById('voucherCode');
                var inputValue = inputField.value.trim();

                if (inputValue === "") {
                    alert('Por favor ingrese un código de voucher válido.');
                    inputField.focus();
                } else {
                    // Validación exitosa, cerrar la modal
                    var myModalEl = document.getElementById('staticBackdrop');
                    var modalInstance = bootstrap.Modal.getInstance(myModalEl);
                    modalInstance.hide();

                    // Lógica adicional: redirigir o realizar otras acciones
                    window.open('Solicitud.aspx', '_blank', 'width=800,height=600');
                }
            });
        });
    </script>

</asp:Content>
