using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using datos;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                List<Marca> lista = new List<Marca>();
                datos.setSP("SP_LISTAR_MARCAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Lector["id"];
                    marca.Descripcion = datos.Lector["descripcion"].ToString();

                    lista.Add(marca);
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
