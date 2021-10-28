using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SCA.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Web.DataAcces
{

    public class ServicioAsistencia
    {
        private readonly DbContextAsistencia _dbAsistencia;
        public ServicioAsistencia(DbContextAsistencia dbAsistencia)
        {
            _dbAsistencia = dbAsistencia;
        }


        // Método Generico Insert, Update,Delete
        private SqlTransaction tr;
        public async Task<string> executeCommandParameter(string nombreSP, string nameParameter, string parameter)
        {
            string rpta = "";
            using (SqlConnection con = new SqlConnection(_dbAsistencia.Database.GetDbConnection().ConnectionString))
            {
                try
                {
                    con.Open();
                    tr = con.BeginTransaction();
                    SqlCommand cmd = new SqlCommand(nombreSP, con, tr);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue(nameParameter, parameter);
                    object data = await cmd.ExecuteScalarAsync();
                    if (data != null) rpta = data.ToString();
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    rpta = ex.Message.ToString();
                }
            }
            return rpta;
        }

        public async Task<string> executeCommand(string nombreSP)
        {
            string rpta = "";
            using (SqlConnection con = new SqlConnection(_dbAsistencia.Database.GetDbConnection().ConnectionString))
            {
                try
                {
                    con.Open();

                    tr = con.BeginTransaction();
                    SqlCommand cmd = new SqlCommand(nombreSP, con, tr);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    object data = await cmd.ExecuteScalarAsync();
                    if (data != null) rpta = data.ToString();
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    rpta = ex.Message.ToString();
                }
            }
            return rpta;
        }

        //end
        // CREANDO METODOS


        public List<rptListaRegistroAsistencia> rptListarAsistencia()//int Coun_Id
        {
            List<rptListaRegistroAsistencia> list = new List<rptListaRegistroAsistencia>();

            using (SqlConnection conn = new SqlConnection(_dbAsistencia.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_rptListaAsistencia", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.Add("@IdCustomer", SqlDbType.Int).Value = (object)Coun_Id ?? DBNull.Value;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            rptListaRegistroAsistencia obj = new rptListaRegistroAsistencia
                            {
                                //[Id],
                                //[Descripcion],
                                //[IdCustomer]
                                IdEstudiante = (dr["IdEstudiante"] != DBNull.Value) ? Convert.ToInt32(dr["IdEstudiante"]) : 0,
                                DniEstudiante = (dr["DniEstudiante"] != DBNull.Value) ? Convert.ToString(dr["DniEstudiante"]) : null,
                                Fecha = (dr["Fecha"] != DBNull.Value) ? Convert.ToString(dr["Fecha"]) : null,
                                IdTipoAsistencia = (dr["IdTipoAsistencia"] != DBNull.Value) ? Convert.ToInt32(dr["IdTipoAsistencia"]) : 0,
                            };

                            list.Add(obj);
                        }

                        dr.Close();
                        dr.DisposeAsync();
                    }

                    cmd.Dispose();
                }

                conn.Close();
                conn.Dispose();
            }

            return list;
        }

        public List<rptListaRegistroEstudianteAsistencia> rptListarEstudianteAsistencia()//int Coun_Id
        {
            List<rptListaRegistroEstudianteAsistencia> list = new List<rptListaRegistroEstudianteAsistencia>();

            using (SqlConnection conn = new SqlConnection(_dbAsistencia.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_rptListaEstudianteAsistencia", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.Add("@IdCustomer", SqlDbType.Int).Value = (object)Coun_Id ?? DBNull.Value;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            rptListaRegistroEstudianteAsistencia obj = new rptListaRegistroEstudianteAsistencia
                            {
                                IdEstudiante = (dr["IdEstudiante"] != DBNull.Value) ? Convert.ToInt32(dr["IdEstudiante"]) : 0,
                                Grado = (dr["Grado"] != DBNull.Value) ? Convert.ToString(dr["Grado"]) : null,
                                Seccion = (dr["Seccion"] != DBNull.Value) ? Convert.ToString(dr["Seccion"]) : null,
                                Apellidos = (dr["Apellidos"] != DBNull.Value) ? Convert.ToString(dr["Apellidos"]) : null,
                                Nombres = (dr["Nombres"] != DBNull.Value) ? Convert.ToString(dr["Nombres"]) : null,
                                Dni = (dr["Dni"] != DBNull.Value) ? Convert.ToString(dr["Dni"]) : null,
                            };

                            list.Add(obj);
                        }

                        dr.Close();
                        dr.DisposeAsync();
                    }

                    cmd.Dispose();
                }

                conn.Close();
                conn.Dispose();
            }

            return list;
        }

        public List<ListarFechas> rptListaFechasAsistencia()//int Coun_Id
        {
            List<ListarFechas> list = new List<ListarFechas>();

            using (SqlConnection conn = new SqlConnection(_dbAsistencia.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_rptListFechaAsistencia", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // cmd.Parameters.Add("@IdCustomer", SqlDbType.Int).Value = (object)Coun_Id ?? DBNull.Value;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ListarFechas obj = new ListarFechas
                            {
                                Fecha = (dr["fecha"] != DBNull.Value) ? Convert.ToString(dr["fecha"]) : null,
                            };

                            list.Add(obj);
                        }
                        dr.Close();
                        dr.DisposeAsync();
                    }
                    cmd.Dispose();
                }
                conn.Close();
                conn.Dispose();
            }

            return list;
        }

        
    }
}
