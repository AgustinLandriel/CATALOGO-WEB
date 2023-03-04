<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductoLista.aspx.cs" Inherits="presentacion.ProductoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <asp:GridView runat="server" ID="dgvProductos" DataKeyNames="id" AutoGenerateColumns="false" CssClass="table table-striped">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
             <asp:BoundField HeaderText="Producto" DataField="Nombre" />
             <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
             <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
             <asp:BoundField HeaderText="Precio" DataField="Precio" />
             <asp:CommandField HeaderText="Editar" SelectText="Modificar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
            <a href="#" class="btn btn-primary">Agregar producto</a>
    </div>

</asp:Content>
