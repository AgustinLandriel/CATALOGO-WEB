<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="presentacion.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h3>Ups, ocurrió un error!</h3>
        <asp:Label runat="server" Text="" id="lblError"></asp:Label>
        <a href="ProductoLista.aspx" class="btn btn-danger">Volver</a>
    </div>
</asp:Content>
