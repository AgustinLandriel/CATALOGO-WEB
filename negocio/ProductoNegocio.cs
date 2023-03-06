using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using datos;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Articulo> ListarArticulos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            datos.setQuery(@"select a.id,a.codigo,a.nombre,a.descripcion, a.imagenUrl, a.precio,cat.Id,cat.Descripcion as [Categoria],mar.id,mar.Descripcion as [Marca]
                                FROM ARTICULOS as a
                                INNER JOIN CATEGORIAS as cat
                                ON(a.IdCategoria = cat.Id)
                                INNER JOIN MARCAS as mar
                                ON(a.IdMarca = mar.Id)");

            datos.EjecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();

                    articulo.Id = (int)datos.Lector["id"];
                    articulo.Codigo = datos.Lector["codigo"].ToString();
                    articulo.Nombre = datos.Lector["nombre"].ToString();
                    articulo.ImagenUrl = datos.Lector["imagenUrl"].ToString();
                    articulo.Descripcion = datos.Lector["descripcion"].ToString();
                    articulo.Precio = (decimal)datos.Lector["precio"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["id"];
                    articulo.Marca.Descripcion = datos.Lector["Marca"].ToString();
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Descripcion = datos.Lector["Categoria"].ToString();
                    articulo.Categoria.Id = (int)datos.Lector["id"];

                    lista.Add(articulo);
                }
               
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void AgregarProducto(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            datos.setSP("@SP_ALTA");
            datos.setVariables("@codigo", articulo.Codigo);
            datos.setVariables("@nombre", articulo.Nombre);
            datos.setVariables("@descripcion", articulo.Descripcion);
            datos.setVariables("@marca", articulo.Marca.Id);
            datos.setVariables("@categoria", articulo.Categoria.Id);
            datos.setVariables("@imagenUrl", articulo.ImagenUrl);
            datos.setVariables("@precio", articulo.Precio);
            try
            {
                datos.EjecutarAccion();
             
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
