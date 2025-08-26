using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Configuration;
using Seguridad;
using System.Data;

namespace AccesoDatos
{
    public class AccesoSQL
    {
        #region Atributos
        private string cadenadeconexion = ConfigurationManager.AppSettings["conexionBD"].ToString();
        private SqlConnection Objconexion;

        #endregion

        #region Constructor          
        public AccesoSQL()
        {
            try
            {
                Objconexion = new SqlConnection(Encriptacion.Desencriptar(cadenadeconexion));               
                ABRIR();
            }
            catch (SqlException exSQL)
            {
                throw exSQL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }
        }
        #endregion

        #region Metodos

        #region privados

        private void ABRIR()
        {
            if (Objconexion.State == System.Data.ConnectionState.Closed)
                Objconexion.Open();
        }
        private void CERRAR()
        {
            if (Objconexion.State == System.Data.ConnectionState.Open)
                Objconexion.Close();
        }

        #endregion

        #region Publicos    

        #region Transaccion

        public void Agregar_En_Cola(SQLPeticion P_Entidad, ref List<SqlCommand> P_ListaPeticiones)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = Objconexion,
                CommandType = System.Data.CommandType.Text,
                CommandText = P_Entidad.Peticion
            };

            if (P_Entidad.ListaParametros.Count > 0)
                cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

            P_ListaPeticiones.Add(cmd);
        }

        public bool EjecutarTransaccion(List<SqlCommand> P_ListaPeticion)
        {
            SqlTransaction objtran;
            ABRIR();
            objtran = Objconexion.BeginTransaction();

            try
            {
                foreach (SqlCommand cmd in P_ListaPeticion)
                {
                    cmd.Transaction = objtran;
                    cmd.Connection = Objconexion;
                    cmd.ExecuteNonQuery();
                }
                objtran.Commit();
            }
            catch (Exception ex)
            {
                objtran.Rollback();
                return false;
            }
            finally
            {
                CERRAR();
            }
            return true;
        }
        #endregion

        public bool EjecutarSentencia(SQLPeticion P_Entidad)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = Objconexion,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                ABRIR();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            #endregion
            #endregion
        }
        public List<Paquete> ConsultaPaquetesPorUsuario(SQLPeticion P_Entidad)
        {
            DataTable dt = new DataTable();
            List<Paquete> lstresultado = new List<Paquete>();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = Objconexion,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                SqlDataAdapter objconsulta = new SqlDataAdapter(cmd);
                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Paquete p = new Paquete
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                            Codigo = fila["Codigo"].ToString(),
                            Descripcion = fila["Descripcion"].ToString(),
                            Valor = Convert.ToDouble(fila["Valor"]),
                            Peso = Convert.ToDouble(fila["Peso"])
                        };

                        lstresultado.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultado;
        }

        public List<Paquete> ConsultaPaquetes(SQLPeticion P_Entidad)
        {
            DataTable dt = new DataTable();
            List<Paquete> lstresultado = new List<Paquete>();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = Objconexion,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                SqlDataAdapter objconsulta = new SqlDataAdapter(cmd);
                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Paquete p = new Paquete
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                            Codigo = fila["Codigo"].ToString(),
                            Descripcion = fila["Descripcion"].ToString(),
                            Valor = Convert.ToDouble(fila["Valor"]),
                            Peso = Convert.ToDouble(fila["Peso"])
                        };

                        lstresultado.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultado;
        }

        public Usuario ConsultaUsuarioPorCorreo(SQLPeticion P_Entidad)
        {
            DataTable dt = new DataTable();
            Usuario resultado = null;

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = Objconexion,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                SqlDataAdapter objconsulta = new SqlDataAdapter(cmd);
                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    resultado = new Usuario
                    {
                        Id = Convert.ToInt32(fila["Id"]),
                        Correo = fila["Correo"].ToString(),
                        Contraseña = fila["Contraseña"].ToString(),
                        NombreCompleto = fila["NombreCompleto"].ToString(),
                        Telefono = fila["Telefono"].ToString(),
                        IntentosFallidos = Convert.ToInt32(fila["IntentosFallidos"]),
                        BloqueadoHasta = fila["BloqueadoHasta"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(fila["BloqueadoHasta"]),
                        FechaExpiracionContraseña = Convert.ToDateTime(fila["FechaExpiracionContraseña"]),
                        ContraseñaTemporal = Convert.ToBoolean(fila["ContraseñaTemporal"]),
                        Rol = fila["Rol"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return resultado;
        }

        public List<Usuario> ConsultarUsuarios(SQLPeticion P_Entidad)
        {
            DataTable dt = new DataTable();
            List<Usuario> lstresultado = new List<Usuario>();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = Objconexion,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                SqlDataAdapter objconsulta = new SqlDataAdapter(cmd);
                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Usuario u = new Usuario
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            Correo = fila["Correo"].ToString(),
                            Contraseña = fila["Contraseña"].ToString(),
                            NombreCompleto = fila["NombreCompleto"].ToString(),
                            Telefono = fila["Telefono"].ToString(),
                            IntentosFallidos = Convert.ToInt32(fila["IntentosFallidos"]),
                            BloqueadoHasta = fila["BloqueadoHasta"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(fila["BloqueadoHasta"]),
                            FechaExpiracionContraseña = Convert.ToDateTime(fila["FechaExpiracionContraseña"]),
                            ContraseñaTemporal = Convert.ToBoolean(fila["ContraseñaTemporal"]),
                            Rol = fila["Rol"].ToString()
                        };

                        lstresultado.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultado;
        }

        public List<Pedido> ConsultaPedidosPorUsuario(SQLPeticion P_Entidad)
        {
            DataTable dt = new DataTable();
            List<Pedido> lstresultado = new List<Pedido>();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = Objconexion,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                SqlDataAdapter objconsulta = new SqlDataAdapter(cmd);
                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Pedido p = new Pedido
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            IdPaquete = Convert.ToInt32(fila["IdPaquete"]),
                            IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                            FechaCreacion = Convert.ToDateTime(fila["FechaCreacion"]),
                            Estado = fila["Estado"].ToString(),
                            UbicacionRecogida = fila["UbicacionRecogida"].ToString(),
                            TipoEntrega = fila["TipoEntrega"].ToString(),
                            UbicacionEntrega = fila["UbicacionEntrega"].ToString(),
                            Pagado = Convert.ToBoolean(fila["Pagado"])
                        };

                        lstresultado.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultado;
        }

        public List<Pedido> ConsultaPedidos(SQLPeticion P_Entidad)
        {
            DataTable dt = new DataTable();
            List<Pedido> lstresultado = new List<Pedido>();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = Objconexion,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                SqlDataAdapter objconsulta = new SqlDataAdapter(cmd);
                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Pedido p = new Pedido
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            IdPaquete = Convert.ToInt32(fila["IdPaquete"]),
                            IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                            FechaCreacion = Convert.ToDateTime(fila["FechaCreacion"]),
                            Estado = fila["Estado"].ToString(),
                            UbicacionRecogida = fila["UbicacionRecogida"].ToString(),
                            TipoEntrega = fila["TipoEntrega"].ToString(),
                            UbicacionEntrega = fila["UbicacionEntrega"].ToString(),
                            Pagado = Convert.ToBoolean(fila["Pagado"])
                        };

                        lstresultado.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultado;
        }

        public List<Historial> ConsultarHistorialesPorUsuario(SQLPeticion P_Entidad)
        {
            DataTable dt = new DataTable();
            List<Historial> lstresultado = new List<Historial>();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = Objconexion,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                SqlDataAdapter objconsulta = new SqlDataAdapter(cmd);
                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Historial h = new Historial
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            IdPedido = Convert.ToInt32(fila["IdPedido"]),
                            Fecha = Convert.ToDateTime(fila["Fecha"]),
                            Accion = fila["Accion"].ToString()
                        };

                        lstresultado.Add(h);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultado;
        }

        public List<Historial> ConsultarHistorialesPorPedido(SQLPeticion P_Entidad)
        {
            DataTable dt = new DataTable();
            List<Historial> lstresultado = new List<Historial>();

            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = Objconexion,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = P_Entidad.Peticion
                };

                if (P_Entidad.ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(P_Entidad.ListaParametros.ToArray());

                SqlDataAdapter objconsulta = new SqlDataAdapter(cmd);
                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        Historial h = new Historial
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            IdPedido = Convert.ToInt32(fila["IdPedido"]),
                            Fecha = Convert.ToDateTime(fila["Fecha"]),
                            Accion = fila["Accion"].ToString()
                        };

                        lstresultado.Add(h);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultado;
        }
    }

}

