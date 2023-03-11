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
    }
}