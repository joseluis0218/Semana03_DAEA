using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso01
{
    class ClsDatos
    {

        public SqlConnection LeerCadena()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

            return connection;
        }
        public SqlDataReader ListaClientes()
        {
            try
            {
                SqlConnection connection = LeerCadena();
                connection.Open();
                SqlCommand command = new SqlCommand("USP_ListaClientes");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return dataReader;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Empleado> ListarEmpleado()
        {
            SqlConnection connection = LeerCadena();
            connection.Open();

            List<Empleado> lista = new List<Empleado>();
            Empleado empleado;
            SqlDataReader dataReader;

            try
            {
                SqlCommand command = new SqlCommand("USP_ListaEmpleados");
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    empleado = new Empleado();

                    empleado.IdEmpleado = (int)(dataReader[0]);
                    empleado.Apellido = (string)(dataReader[1]);
                    empleado.Nombre = (string)(dataReader[2]);
                    empleado.Nacimiento = (DateTime)(dataReader[3]);
                    empleado.Direccion = (string)(dataReader[4]);

                    lista.Add(empleado);
                }


            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            connection.Close();
            return lista;

        }

        public List<Pais> ListaPais()
        {
            SqlConnection connection = LeerCadena();
            connection.Open();

            List<Pais> lista = new List<Pais>();
            Pais pais;
            SqlDataReader dataReader;

            try
            {
                SqlCommand command = new SqlCommand("USP_ListaPaises");
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    pais = new Pais();

                    pais.NombrePais = (string)(dataReader[0]);                    pais.NombrePais = (string)(dataReader[0]);

                    lista.Add(pais);
                }

            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            connection.Close();

            return lista;
        }

        public List<Proveedor> ListaProveedor()
        {
            SqlConnection connection = LeerCadena();
            connection.Open();

            List<Proveedor> lista = new List<Proveedor>();
            Proveedor proveedor;
            SqlDataReader dataReader;

            try
            {
                SqlCommand command = new SqlCommand("USP_ListaProveedores");
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    proveedor = new Proveedor();
                    proveedor.Codigo = (int)(dataReader[0]);
                    proveedor.NombreProveedor = (string)(dataReader[1]);
                    proveedor.Pais = (string)(dataReader[2]);
                    proveedor.Ciudad = (string)(dataReader[3]);
                    proveedor.Region = (string)(dataReader[4]);
                    proveedor.CodigoPostal = (string)(dataReader[5]);

                    lista.Add(proveedor);
                }

            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            connection.Close();

            return lista;
        }


    }
}
