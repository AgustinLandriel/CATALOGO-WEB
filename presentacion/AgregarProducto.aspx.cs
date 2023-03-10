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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    // Si id no es vacio y es postback pasa a la pagina de modificar

                    //el [0] es para que me devuelva solo una posicion. Ya que el objeto no es una lista 
                    Articulo articuloSeleccionado = negocio.ListarArticulos(id)[0];

                    txtNombre.Text = articuloSeleccionado.Nombre;
                    txtCodigo.Text = articuloSeleccionado.Codigo;
                    txtCodigo.Text = articuloSeleccionado.Descripcion;
                    urlImagen.Text = articuloSeleccionado.ImagenUrl;
                    ImgFoto.ImageUrl = articuloSeleccionado.ImagenUrl;
                    txtPrecio.Text = articuloSeleccionado.Precio.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Articulo articulo = new Articulo();

                //Creo el articulo con los datos del formulario
                articulo.Nombre = txtNombre.Text ;
                articulo.Codigo = txtCodigo.Text;
                articulo.Descripcion = txtDescripcion.Text ;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.ImagenUrl = urlImagen.Text;
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                negocio.AgregarProducto(articulo);
                Response.Redirect("ProductoLista.aspx");
                
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
            }
        }


        protected void urlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                    ImgFoto.ImageUrl = urlImagen.Text;
            }
            catch (Exception)
            {

                ImgFoto.ImageUrl = "https://www.slntechnologies.com/wp-content/uploads/2017/08/ef3-placeholder-image.jpg";
            }
        }
    }
}