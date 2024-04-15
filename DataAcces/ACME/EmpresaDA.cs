using System.Data;
using Microsoft.Data.SqlClient;
using Models.ACME;
{

}

namespace DataAccess.ACME
{
    public class EmpresaDA
    {
        private Conexion _conexion = new Conexion();

        public void Insertar(EmpresaEntidad empresaEntidad)
        {
            SqlConnection sqlConn = _conexion.Connectar();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                sqlConn.Open();
                sqlComm.Connection= sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "InsertarEmpresa";
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa",SqlDbType.Int)).Direction = ParameterDirection.Output;
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.IDTipoEmpresa));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.Empresa));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.Direccion ));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.RUC));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.FechaCreacion));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.Presupuesto));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.Activo));

                sqlComm.ExecuteNonQuery();
                empresaEntidad.IDEmpresa = (int)sqlComm.Parameters[sqlComm.Parameters.IndexOf("@IDEmpresa")].Value;

                sqlConn.Close();

            }
            catch (Exception ex)
            {

                throw new Exception("EmpresaDA.Insertar: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }

        public void Modificar(EmpresaEntidad empresaEntidad)
        {
            SqlConnection sqlConn = _conexion.Connectar();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ModificarEmpresa";
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.IDEmpresa));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.IDTipoEmpresa));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.Empresa));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.Direccion));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.RUC));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.FechaCreacion));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.Presupuesto));
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.Activo));

               if(sqlComm.ExecuteNonQuery() != 1)
                {
                    throw new Exception("EmpresaDA.Modificar: Problema al actualizar");
                }
               

                sqlConn.Close();

            }
            catch (Exception ex)
            {

                throw new Exception("EmpresaDA.Modificar: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }


        public void Anular(EmpresaEntidad empresaEntidad)
        {
            SqlConnection sqlConn = _conexion.Connectar();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "AnularEmpresa";
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntidad.IDEmpresa));

                sqlComm.ExecuteNonQuery();

                sqlConn.Close();

            }
            catch (Exception ex)
            {

                throw new Exception("EmpresaDA.Anular: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }

        public List<EmpresaEntidad> Listar()
        {
            SqlConnection sqlConn = _conexion.Connectar();
            SqlDataReader sqlDataReader;
            SqlCommand sqlComm = new SqlCommand();

            List<EmpresaEntidad>? listaEmpresas = new List<EmpresaEntidad>();
            EmpresaEntidad? empresaEntidad;

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType= CommandType.StoredProcedure;
                sqlComm.CommandText = "ListarEmpresa";

                sqlDataReader = sqlComm.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    empresaEntidad = new();
                    empresaEntidad.IDEmpresa = (int)sqlDataReader["IDEmpresa"];
                    empresaEntidad.IDTipoEmpresa = (int)sqlDataReader["IDTipoEmpresa"];
                    empresaEntidad.Empresa = sqlDataReader["Empresa"].ToString() ?? string.Empty;
                    empresaEntidad.Direccion = sqlDataReader["Dirreccion"].ToString() ?? string.Empty;
                    empresaEntidad.RUC = sqlDataReader["RUC"].ToString() ?? string.Empty;
                    if (sqlDataReader["FechaCreacion"] != DBNull.Value)
                    {
                        empresaEntidad.FechaCreacion = (DateTime)sqlDataReader["FechaCreacion"];
                    }
                    if (sqlDataReader["Presupuesto"] != DBNull.Value)
                    {
                        empresaEntidad.Presupuesto = (decimal)sqlDataReader["Presupuesto"];
                    }
                    empresaEntidad.Activo = (bool)sqlDataReader["Activo"];

                    listaEmpresas.Add(empresaEntidad);
                }

                sqlConn.Close();

                return listaEmpresas;
            }
            catch (Exception ex)
            {

                throw new Exception("EmpresaDA.Listar: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }

        public EmpresaEntidad BuscarID(int IDEmpresa)
        {
            SqlConnection sqlConn = _conexion.Connectar();
            SqlDataReader sqlDataReader;
            SqlCommand sqlComm = new SqlCommand();

            EmpresaEntidad? empresaEntidad = null;

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "BuscarEmpresa";

                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", IDEmpresa));

                sqlDataReader = sqlComm.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    empresaEntidad = new();
                    empresaEntidad.IDEmpresa = (int)sqlDataReader["IDEmpresa"];
                    empresaEntidad.IDTipoEmpresa = (int)sqlDataReader["IDTipoEmpresa"];
                    empresaEntidad.Empresa = sqlDataReader["Empresa"].ToString() ?? string.Empty;
                    empresaEntidad.Direccion = sqlDataReader["Dirreccion"].ToString() ?? string.Empty;
                    empresaEntidad.RUC = sqlDataReader["RUC"].ToString() ?? string.Empty;
                    if (sqlDataReader["FechaCreacion"] != DBNull.Value)
                    {
                        empresaEntidad.FechaCreacion = (DateTime)sqlDataReader["FechaCreacion"];
                    }
                    if (sqlDataReader["Presupuesto"] != DBNull.Value)
                    {
                        empresaEntidad.Presupuesto = (decimal)sqlDataReader["Presupuesto"];
                    }
                    empresaEntidad.Activo = (bool)sqlDataReader["Activo"];
                  
                }

                sqlConn.Close();

                if(empresaEntidad == null)
                {
                    throw new Exception("EmpresaDA.BuscarID: El ID de Empresa no existe");
                }

                return empresaEntidad;
            }
            catch (Exception ex)
            {

                throw new Exception("EmpresaDA.BuscarID: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }
    }
}