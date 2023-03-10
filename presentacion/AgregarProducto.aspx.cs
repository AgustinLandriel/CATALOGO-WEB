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
            //Cargar los dropdown de Marca y Categoria

            if (!IsPostBack)
            {
                MarcaNegocio negocioMarca = new MarcaNegocio();
                ddlMarca.DataSource = negocioMarca.ListarMarcas();
                ddlMarca.DataValueField = "id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();

                CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                ddlCategoria.DataSource = negocioCategoria.ListarMarcas();
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
            }

            try
            {
                ProductoNegocio negocio = new ProductoNegocio();

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    lblTitle.Text = "Modificar o eliminar producto";

                    // Si id no es vacio y es postback pasa a la pagina de modificar
                    //el [0] es para que me devuelva solo una posicion. Ya que el objeto no es una lista 
                    Articulo articuloSeleccionado = negocio.ListarArticulos(id)[0];

                    txtNombre.Text = articuloSeleccionado.Nombre;
                    txtCodigo.Text = articuloSeleccionado.Codigo;
                    txtDescripcion.Text = articuloSeleccionado.Descripcion;
                    ddlCategoria.SelectedIndex = articuloSeleccionado.Categoria.Id;
                    ddlCategoria.SelectedIndex = articuloSeleccionado.Marca.Id;
                    urlImagen.Text = articuloSeleccionado.ImagenUrl;
                    ImgFoto.ImageUrl = articuloSeleccionado.ImagenUrl;
                    txtPrecio.Text = articuloSeleccionado.Precio.ToString();


                    btnAgregar.Text = "Modificar";
                    btnAgregar.CssClass = "btn btn-warning";
                    btnEliminar.Visible = true;
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
                articulo.Nombre = txtNombre.Text;
                articulo.Codigo = txtCodigo.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.ImagenUrl = urlImagen.Text;
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);


                //Si el id no es nulo es por que voy a modificarlo
                if (Request.QueryString["id"] != null)
                {
                    lblAlerta.Text = "Articulo modificado correctamente!";
                    lblAlerta.CssClass = "alert alert-warning";
                    negocio.ModificarProducto(articulo);

                    return;
                }

                negocio.AgregarProducto(articulo);
                lblAlerta.Text = "Articulo agregado correctamente!";
                lblAlerta.CssClass = "alert alert-success";

            }
            catch (Exception ex)
            {
                //Session("error", ex.ToString());
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            int id = int.Parse(Request.QueryString["id"].ToString()); // Guardo el ID del articulo
            negocio.EliminarProducto(id);

            lblAlerta.Text = "Articulo ELIMINADO correctamente!";
            lblAlerta.CssClass = "alert alert-danger";

        }
    }
}