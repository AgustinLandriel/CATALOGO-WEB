<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductoLista.aspx.cs" Inherits="presentacion.ProductoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col m-4">
            <h3 class="my-3">Listado de Productos</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <h6 class="my-3 text-dark">Buscar articulo <i class="bi bi-search"></i></h6>
            <asp:TextBox runat="server" ID="txtBusqueda" OnTextChanged="txtBusqueda_TextChanged" CssClass="form-control rounded-0 my-2 border-0 border-bottom border-3 border-danger bg-light w-40" placeholder="Buscá tu articulo favorito" />
            <asp:CheckBox Text="Busqueda avanzada " CssClass="form-check-input" runat="server" ID="checkFiltro" AutoPostBack="true" OnCheckedChanged="checkFiltro_CheckedChanged" />
        </div>
    </div>
    <% if (FiltroAvanzado)
        { %>
    <div class="row bg-dark rounded-3 text-white p-3">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtrar por" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlFiltro" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Categoria" />
                    <asp:ListItem Text="Marca" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Busqueda" CssClass="form-label" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" placeholder="Ingresá la busqueda" />
            </div>
        </div>
        <div class="col">
            <div class="mt-4">
                <asp:Button Text="Buscar" ID="btnBuscarFiltro" CssClass="btn btn-danger" runat="server" />
            </div>
        </div>
    </div>
    <%} %>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col">
                    <asp:GridView OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" runat="server" ID="dgvProductos" DataKeyNames="id" AutoGenerateColumns="false" CssClass=" my-5 table border-2 border border-light shadow-lg shadow">
                        <Columns>
                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                            <asp:BoundField HeaderText="Producto" DataField="Nombre" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:CommandField HeaderText="Editar" SelectText="Modificar" ItemStyle-CssClass="bi bi-pencil-square" ControlStyle-CssClass=" text-danger fw-bolder p-1 text-decoration-none" ShowSelectButton="true" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label Text="" ID="lblBusquedaVacia" runat="server" />
                    <a href="AgregarProducto.aspx" class="btn btn-success">Agregar articulo <i class="bi bi-plus-circle"></i></a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
