using App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace App.Data
{
    class EmpleadosDbContext
    {
        private readonly string _config;
        public EmpleadosDbContext() { _config = (App.Current as App).ConnectionString; }
        internal List<Empleado> ToList()
        {
            var data = new List<Empleado>();

            SqlConnection con = new SqlConnection(_config);
            SqlCommand cmd = new SqlCommand("SELECT [EmpleadoID], [Nombre], [Edad] FROM [Empleados]", con);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(new Empleado
                    {
                        EmpleadoID = (Guid)dr["EmpleadoID"],
                        Nombre = (string)dr["Nombre"],
                        Edad = (int)dr["Edad"]
                    });
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        internal Empleado Find(Guid id)
        {
            var data = new Empleado();

            SqlConnection con = new SqlConnection(_config);
            SqlCommand cmd = new SqlCommand("SELECT [EmpleadoID], [Nombre], [Edad] FROM [Empleados] WHERE [EmpleadoID] = @id", con);
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    data.EmpleadoID = (Guid)dr["EmpleadoID"];
                    data.Nombre = (string)dr["Nombre"];
                    data.Edad = (int)dr["Edad"];
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        internal void Add(Empleado data)
        {
            SqlConnection con = new SqlConnection(_config);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [Empleados] ([EmpleadoID], [Nombre], [Edad]) VALUES (@EmpleadoID, @Nombre, @Edad);", con);
            cmd.Parameters.Add("@EmpleadoID", SqlDbType.UniqueIdentifier).Value = data.EmpleadoID;
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = data.Nombre;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = (object)data.Edad ?? DBNull.Value;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        internal void Update(Guid id, Empleado data)
        {
            SqlConnection con = new SqlConnection(_config);
            SqlCommand cmd = new SqlCommand(@"UPDATE [Empleados] SET [EmpleadoID] = @EmpleadoID, [Nombre] = @Nombre, [Edad] = @Edad WHERE [EmpleadoID] = @Id;", con);

            cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
            cmd.Parameters.Add("@EmpleadoID", SqlDbType.UniqueIdentifier).Value = data.EmpleadoID;
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = data.Nombre;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = (object)data.Edad ?? DBNull.Value;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        internal void Remove(Guid id)
        {
            SqlConnection con = new SqlConnection(_config);
            SqlCommand cmd = new SqlCommand(@"DELETE FROM [Empleados] WHERE [EmpleadoID] = @EmpleadoID;", con);
            cmd.Parameters.Add("@EmpleadoID", SqlDbType.UniqueIdentifier).Value = id;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
