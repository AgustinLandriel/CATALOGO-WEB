using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace presentacion
{
    public partial class ProductoLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            Session.Add("listaArticulo", negocio.ListarArticulos());
            dgvProductos.DataSource = Session["listaArticulo"];
            dgvProductos.DataBind();
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvProductos.SelectedDataKey.Value.ToString());
            
            try
            {
                Response.Redirect("AgregarProducto.aspx?id=" + id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            
           List<Articulo> listaFiltrada = ((List<Articulo>)Session["listaArticulo"]).FindAll(x => x.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) || x.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower()));

            if (listaFiltrada == null || listaFiltrada.Count == 0)
            {
                lblBusquedaVacia.Text = "No hay articulo que coincidan con la busqueda";
                lblBusquedaVacia.CssClass = "my-5 text-danger";
                dgvProductos.DataSource = null;
                dgvProductos.DataBind();
            } else
            {
                dgvProductos.DataSource = listaFiltrada;
                dgvProductos.DataBind();
                lblBusquedaVacia.Text = "";
            }
        }

        protected void checkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = checkFiltro.Checked;
        }


        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFiltro.SelectedValue == "Precio")
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            } else if (ddlFiltro.SelectedValue == "Categoria")
            {
                ddlCriterio.Items.Clear();
                CategoriaNegocio negocio = new CategoriaNegocio();
                ddlCriterio.DataSource = negocio.ListarCategorias();
                ddlCriterio.DataValueField = "id";
                ddlCriterio.DataTextField = "descripcion";
                ddlCriterio.DataBind();
            }
            else if (ddlFiltro.SelectedValue == "Marca")
            {
                ddlCriterio.Items.Clear();
                MarcaNegocio negocio = new MarcaNegocio();
                ddlCriterio.DataSource = negocio.ListarMarcas();
                ddlCriterio.DataBind();
            }

        }
        protected void ddlCriterio_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}