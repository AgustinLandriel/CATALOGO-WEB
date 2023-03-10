using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using datos;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> ListarMarcas()
        {
              AccesoDatos datos = new AccesoDatos();
            try
            {
                List<Categoria> lista = new List<Categoria>();
                datos.setSP("SP_LISTAR_CATEGORIAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)datos.Lector["id"];
                    categoria.Descripcion = datos.Lector["descripcion"].ToString();

                    lista.Add(categoria);
                }

                datos.CerrarConexion();

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
    }
}
