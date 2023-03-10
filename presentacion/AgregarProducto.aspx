<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="presentacion.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <asp:Label Text="Agregá tu producto" CssClass="my-3 h3" ID="lblTitle" runat="server" />

        <div class="col-6 p-3 shadow-lg">
            <div class="mb-3">
                <asp:Label Text="Nombre" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre del producto" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Codigo" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Codigo del producto" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Descripcion" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control resize" />
            </div>
            <asp:Label Text="Marca" CssClass="form-label" runat="server" />
            <div class="dropdown mb-3">
                <asp:DropDownList CssClass="dropdown" ID="ddlMarca" runat="server">
                </asp:DropDownList>
            </div>
            <asp:Label Text="Categoria" CssClass="form-label" runat="server" />
            <div class="dropdown mb-3">
                <asp:DropDownList CssClass="dropdown" ID="ddlCategoria" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Imágen producto</label>
                <asp:TextBox ID="urlImagen" CssClass="form-control" runat="server" OnTextChanged="urlImagen_TextChanged" AutoPostBack="true"/>
                <asp:Image ID="ImgFoto" CssClass="w-50 h-auto" runat="server"  />
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click" />
                <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" runat="server" Visible ="false" OnClick="btnEliminar_Click" />
                <a href="ProductoLista.aspx" class="btn btn-danger">Volver</a>
            </div>
        </div>
        
        <asp:Label Text="" ID="lblAlerta" runat="server" />
        
    </div>
</asp:Content>
