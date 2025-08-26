using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace Negocio
{
    public class UsuarioLN
    {
        //Agregar usuario
        public static bool Agregar(Usuario P_Entidad)
        {
            SqlParameter parametroCorreo = new SqlParameter
            {
                ParameterName = @"@Correo",
                Value = P_Entidad.Correo,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroContraseña = new SqlParameter
            {
                ParameterName = @"@Contraseña",
                Value = P_Entidad.Contraseña,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroNombreCompleto = new SqlParameter
            {
                ParameterName = @"@NombreCompleto",
                Value = P_Entidad.NombreCompleto,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroTelefono = new SqlParameter
            {
                ParameterName = @"@Telefono",
                Value = P_Entidad.Telefono,
                SqlDbType = SqlDbType.VarChar,
                Size = 30,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroIntentosFallidos = new SqlParameter
            {
                ParameterName = @"@IntentosFallidos",
                Value = P_Entidad.IntentosFallidos,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroBloqueadoHasta = new SqlParameter
            {
                ParameterName = @"@BloqueadoHasta",
                Value = (object)P_Entidad.BloqueadoHasta ?? DBNull.Value,
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroFechaExpiracionContraseña = new SqlParameter
            {
                ParameterName = @"@FechaExpiracionContraseña",
                Value = P_Entidad.FechaExpiracionContraseña,
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroContraseñaTemporal = new SqlParameter
            {
                ParameterName = @"@ContraseñaTemporal",
                Value = P_Entidad.ContraseñaTemporal,
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroRol = new SqlParameter
            {
                ParameterName = @"@Rol",
                Value = P_Entidad.Rol,
                SqlDbType = SqlDbType.VarChar,
                Size = 80,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_AgregarUsuario @Correo, @Contraseña, @NombreCompleto, @Telefono, @IntentosFallidos, @BloqueadoHasta, @FechaExpiracionContraseña, @ContraseñaTemporal, @Rol",
                ListaParametros = new List<SqlParameter> { parametroCorreo, parametroContraseña, parametroNombreCompleto, parametroTelefono, parametroIntentosFallidos, parametroBloqueadoHasta, parametroFechaExpiracionContraseña, parametroContraseñaTemporal, parametroRol }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }

        // Modificar Usuario
        public static bool Modificar(Usuario P_Entidad)
        {
            SqlParameter parametroId = new SqlParameter
            {
                ParameterName = @"@Id",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroCorreo = new SqlParameter
            {
                ParameterName = @"@Correo",
                Value = P_Entidad.Correo,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroContraseña = new SqlParameter
            {
                ParameterName = @"@Contraseña",
                Value = P_Entidad.Contraseña,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroNombreCompleto = new SqlParameter
            {
                ParameterName = @"@NombreCompleto",
                Value = P_Entidad.NombreCompleto,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroTelefono = new SqlParameter
            {
                ParameterName = @"@Telefono",
                Value = P_Entidad.Telefono,
                SqlDbType = SqlDbType.VarChar,
                Size = 30,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroIntentosFallidos = new SqlParameter
            {
                ParameterName = @"@IntentosFallidos",
                Value = P_Entidad.IntentosFallidos,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroBloqueadoHasta = new SqlParameter
            {
                ParameterName = @"@BloqueadoHasta",
                Value = (object)P_Entidad.BloqueadoHasta ?? DBNull.Value,
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroFechaExpiracionContraseña = new SqlParameter
            {
                ParameterName = @"@FechaExpiracionContraseña",
                Value = P_Entidad.FechaExpiracionContraseña,
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroContraseñaTemporal = new SqlParameter
            {
                ParameterName = @"@ContraseñaTemporal",
                Value = P_Entidad.ContraseñaTemporal,
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroRol = new SqlParameter
            {
                ParameterName = @"@Rol",
                Value = P_Entidad.Rol,
                SqlDbType = SqlDbType.VarChar,
                Size = 80,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_ModificarUsuario @Id, @Correo, @Contraseña, @NombreCompleto, @Telefono, @IntentosFallidos, @BloqueadoHasta, @FechaExpiracionContraseña, @ContraseñaTemporal, @Rol",
                ListaParametros = new List<SqlParameter> { parametroId, parametroCorreo, parametroContraseña, parametroNombreCompleto, parametroTelefono, parametroIntentosFallidos, parametroBloqueadoHasta, parametroFechaExpiracionContraseña, parametroContraseñaTemporal, parametroRol }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }

        //Eliminar Usuario
        public static bool Eliminar(Usuario P_Entidad)
        {
            SqlParameter parametroCorreo = new SqlParameter
            {
                ParameterName = @"@Correo",
                Value = P_Entidad.Correo,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_EliminarUsuarioPorCorreo @Correo",
                ListaParametros = new List<SqlParameter> { parametroCorreo }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }


        //Consultar Usuario por correo
        public static Usuario ConsultarUsuarioPorCorreo(Usuario P_Entidad)
        {
            SqlParameter parametroCorreo = new SqlParameter
            {
                ParameterName = @"@Correo",
                Value = P_Entidad.Correo,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {

                Peticion = "EXEC PA_ConsultarUsuarioPorCorreo @Correo",
                ListaParametros = new List<SqlParameter> { parametroCorreo }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.ConsultaUsuarioPorCorreo(peticion);
        }

        //Consultar Usuarios
        public static List<Usuario> ConsultarUsuarios()
        {
            SQLPeticion peticion = new SQLPeticion
            {

                Peticion = "EXEC PA_ConsultarUsuarios",
                ListaParametros = new List<SqlParameter>()
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.ConsultarUsuarios(peticion);
        }

        //Agregar Paquete
        public static bool Agregar(Paquete P_Entidad)
        {
            SqlParameter parametroIdUsuario = new SqlParameter
            {
                ParameterName = @"@IdUsuario",
                Value = P_Entidad.IdUsuario,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroCodigo = new SqlParameter
            {
                ParameterName = @"@Codigo",
                Value = P_Entidad.Codigo,
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroDescripcion = new SqlParameter
            {
                ParameterName = @"@Descripcion",
                Value = P_Entidad.Descripcion,
                SqlDbType = SqlDbType.VarChar,
                Size = 255,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroValor = new SqlParameter
            {
                ParameterName = @"@Valor",
                Value = P_Entidad.Valor,
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroPeso = new SqlParameter
            {
                ParameterName = @"@Peso",
                Value = P_Entidad.Peso,
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_AgregarPaquete @IdUsuario, @Codigo, @Descripcion, @Valor, @Peso",
                ListaParametros = new List<SqlParameter> { parametroIdUsuario, parametroCodigo, parametroDescripcion, parametroValor, parametroPeso }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }

        //Modificar Paquete
        public static bool Modificar(Paquete P_Entidad)
        {
            SqlParameter parametroId = new SqlParameter
            {
                ParameterName = @"@Id",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroIdUsuario = new SqlParameter
            {
                ParameterName = @"@IdUsuario",
                Value = P_Entidad.IdUsuario,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroCodigo = new SqlParameter
            {
                ParameterName = @"@Codigo",
                Value = P_Entidad.Codigo,
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroDescripcion = new SqlParameter
            {
                ParameterName = @"@Descripcion",
                Value = P_Entidad.Descripcion,
                SqlDbType = SqlDbType.VarChar,
                Size = 255,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroValor = new SqlParameter
            {
                ParameterName = @"@Valor",
                Value = P_Entidad.Valor,
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroPeso = new SqlParameter
            {
                ParameterName = @"@Peso",
                Value = P_Entidad.Peso,
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_ModificarPaquete @Id, @IdUsuario, @Codigo, @Descripcion, @Valor, @Peso",
                ListaParametros = new List<SqlParameter> { parametroId, parametroIdUsuario, parametroCodigo, parametroDescripcion, parametroValor, parametroPeso }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }
        //Eliminar Paquete
        public static bool Eliminar(Paquete P_Entidad)
        {
            SqlParameter parametroId = new SqlParameter
            {
                ParameterName = @"@Id",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_EliminarPaquete @Id",
                ListaParametros = new List<SqlParameter> { parametroId }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }

        //Consultar Paquetes por usuario
        public static List<Paquete> ConsultarPaquetesPorUsuario(Usuario P_Entidad)
        {
            SqlParameter parametroIdUsuario = new SqlParameter
            {
                ParameterName = @"@IdUsuario",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {

                Peticion = "EXEC PA_ConsultarPaquetesPorUsuario @IdUsuario",
                ListaParametros = new List<SqlParameter> { parametroIdUsuario }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.ConsultaPaquetesPorUsuario(peticion);
        }

        public static List<Paquete> ConsultarPaquetes()
        {
            SQLPeticion peticion = new SQLPeticion
            {

                Peticion = "EXEC PA_ConsultarPaquetes",
                ListaParametros = new List<SqlParameter>()
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.ConsultaPaquetes(peticion);
        }

        //Agregar Pedido
        public static bool Agregar(Pedido P_Entidad)
        {
            SqlParameter parametroIdPaquete = new SqlParameter
            {
                ParameterName = @"@IdPaquete",
                Value = P_Entidad.IdPaquete,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroIdUsuario = new SqlParameter
            {
                ParameterName = @"@IdUsuario",
                Value = P_Entidad.IdUsuario,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroEstado = new SqlParameter
            {
                ParameterName = @"@Estado",
                Value = P_Entidad.Estado,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroUbicacionRecogida = new SqlParameter
            {
                ParameterName = @"@UbicacionRecogida",
                Value = P_Entidad.UbicacionRecogida,
                SqlDbType = SqlDbType.VarChar,
                Size = 255,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroTipoEntrega = new SqlParameter
            {
                ParameterName = @"@TipoEntrega",
                Value = P_Entidad.TipoEntrega,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroUbicacionEntrega = new SqlParameter
            {
                ParameterName = @"@UbicacionEntrega",
                Value = P_Entidad.UbicacionEntrega,
                SqlDbType = SqlDbType.VarChar,
                Size = 255,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroPagado = new SqlParameter
            {
                ParameterName = @"@Pagado",
                Value = P_Entidad.Pagado,
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_AgregarPedido @IdPaquete, @IdUsuario, @Estado, @UbicacionRecogida, @TipoEntrega, @UbicacionEntrega, @Pagado",
                ListaParametros = new List<SqlParameter> { parametroIdPaquete, parametroIdUsuario, parametroEstado, parametroUbicacionRecogida, parametroTipoEntrega, parametroUbicacionEntrega, parametroPagado }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }

        //Modificar Pedido
        public static bool Modificar(Pedido P_Entidad)
        {
            SqlParameter parametroId = new SqlParameter
            {
                ParameterName = @"@Id",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroIdPaquete = new SqlParameter
            {
                ParameterName = @"@IdPaquete",
                Value = P_Entidad.IdPaquete,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroIdUsuario = new SqlParameter
            {
                ParameterName = @"@IdUsuario",
                Value = P_Entidad.IdUsuario,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroEstado = new SqlParameter
            {
                ParameterName = @"@Estado",
                Value = P_Entidad.Estado,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroUbicacionRecogida = new SqlParameter
            {
                ParameterName = @"@UbicacionRecogida",
                Value = P_Entidad.UbicacionRecogida,
                SqlDbType = SqlDbType.VarChar,
                Size = 255,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroTipoEntrega = new SqlParameter
            {
                ParameterName = @"@TipoEntrega",
                Value = P_Entidad.TipoEntrega,
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroUbicacionEntrega = new SqlParameter
            {
                ParameterName = @"@UbicacionEntrega",
                Value = P_Entidad.UbicacionEntrega,
                SqlDbType = SqlDbType.VarChar,
                Size = 255,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroPagado = new SqlParameter
            {
                ParameterName = @"@Pagado",
                Value = P_Entidad.Pagado,
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_ModificarPedido @Id, @IdPaquete, @IdUsuario, @Estado, @UbicacionRecogida, @TipoEntrega, @UbicacionEntrega, @Pagado",
                ListaParametros = new List<SqlParameter> { parametroId, parametroIdPaquete, parametroIdUsuario, parametroEstado, parametroUbicacionRecogida, parametroTipoEntrega, parametroUbicacionEntrega, parametroPagado }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }

        //Eliminar Pedido
        public static bool Eliminar(Pedido P_Entidad)
        {
            SqlParameter parametroId = new SqlParameter
            {
                ParameterName = @"@Id",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_EliminarPedido @Id",
                ListaParametros = new List<SqlParameter> { parametroId }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }

        //Consultar Pedidos por usuario
        public static List<Pedido> ConsultarPedidosPorUsuario(Usuario P_Entidad)
        {
            SqlParameter parametroIdUsuario = new SqlParameter
            {
                ParameterName = @"@IdUsuario",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_ConsultarPedidosPorUsuario @IdUsuario",
                ListaParametros = new List<SqlParameter> { parametroIdUsuario }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.ConsultaPedidosPorUsuario(peticion);
        }

        public static List<Pedido> ConsultarPedidos()
        {
            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_ConsultarPedidos",
                ListaParametros = new List<SqlParameter>()
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.ConsultaPedidos(peticion);
        }

        public static bool PagarPedido(Pedido P_Entidad)
        {
            SqlParameter parametroId = new SqlParameter
            {
                ParameterName = @"@Id",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_PagarPedido @Id",
                ListaParametros = new List<SqlParameter> { parametroId }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }

        // Agregar Historial
        public static bool Agregar(Historial P_Entidad)
        {
            SqlParameter parametroIdPedido = new SqlParameter
            {
                ParameterName = @"@IdPedido",
                Value = P_Entidad.IdPedido,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroAccion = new SqlParameter
            {
                ParameterName = @"@Accion",
                Value = P_Entidad.Accion,
                SqlDbType = SqlDbType.VarChar,
                Size = 255,
                Direction = ParameterDirection.Input
            };
            SqlParameter parametroFecha = new SqlParameter
            {
                ParameterName = @"@Fecha",
                Value = P_Entidad.Fecha,
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_AgregarHistorial @IdPedido, @Accion, @Fecha",
                ListaParametros = new List<SqlParameter> { parametroIdPedido, parametroAccion, parametroFecha }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.EjecutarSentencia(peticion);
        }

        //Consultar Historiales por usuario
        public static List<Historial> ConsultarHistorialesPorUsuario(Usuario P_Entidad)
        {
            SqlParameter parametroIdUsuario = new SqlParameter
            {
                ParameterName = @"@IdUsuario",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_ConsultarHistorialesPorUsuario @IdUsuario",
                ListaParametros = new List<SqlParameter> { parametroIdUsuario }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.ConsultarHistorialesPorUsuario(peticion);
        }

        //Consultar Historiales por pedido
        public static List<Historial> ConsultarHistorialesPorPedido(Pedido P_Entidad)
        {
            SqlParameter parametroIdPedido = new SqlParameter
            {
                ParameterName = @"@IdPedido",
                Value = P_Entidad.Id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };

            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_ConsultarHistorialesPorPedido @IdPedido",
                ListaParametros = new List<SqlParameter> { parametroIdPedido }
            };
            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.ConsultarHistorialesPorPedido(peticion);
        }

    }
}
