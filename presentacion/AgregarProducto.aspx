﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="presentacion.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <h3 class="my-3">Agregá tu producto</h3>
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
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <asp:Label Text="Marca" CssClass="form-label" runat="server" />
            <div class="dropdown mb-3">
                <asp:DropDownList CssClass="dropdown" ID="ddlMarca" runat="server">
                    <asp:ListItem Text="Samsung" />
                </asp:DropDownList>
            </div>
            <asp:Label Text="Categoria" CssClass="form-label" runat="server" />
            <div class="dropdown mb-3">
                <asp:DropDownList CssClass="dropdown" ID="ddlCategoria" runat="server">
                    <asp:ListItem Text="Celular" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="formFile" class="form-label">Imágen producto</label>
                <asp:TextBox ID="urlImagen" CssClass="form-control" runat="server" OnTextChanged="urlImagen_TextChanged" AutoPostBack="true"/>
                <asp:Image ID="ImgFoto" CssClass=" p-3 w-50 h-auto" runat="server"  />
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click" />
                <a href="ProductoLista.aspx" class="btn btn-danger">Volver</a>
            </div>
        </div>
    </div>
</asp:Content>