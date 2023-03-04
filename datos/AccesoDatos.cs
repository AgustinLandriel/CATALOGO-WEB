using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace datos
{
    public class AccesoDatos
    {

        SqlConnection conexion;
        SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector {

            get {return lector;}
           
        }

        //Creo la conexion cuando se llama a la clase
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=Catalogo_DB; integrated security=true;");
            comando = new SqlCommand();

        }


        //Comando para la SP

        public  void setSP (string storeProcedure)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = storeProcedure;
        }

        public void setVariables(string var, object dato)
        {
            comando.Parameters.AddWithValue(var, dato);
        }

        public void EjecutarLectura()
        {
            conexion.Open();

            try
            {
                lector = comando.ExecuteReader(); // Le asigno a lector el valor de la consulta

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void EjecutarAccion()
        {
            conexion.Open();
            comando.Connection = conexion;

            try
            {
                comando.ExecuteNonQuery(); // Le asigno a lector el valor de la consulta

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }

            conexion.Close();
        }

    }
}
