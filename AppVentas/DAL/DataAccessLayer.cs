using AppVentas.Models.Productos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppVentas.Models;

namespace AppVentas.DAL
{
    public class DataAccessLayer
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["TiendaDbContext"].ConnectionString;

        public async Task<List<Producto>> MostrarProductosAsync()
        {
            var productos = new List<Producto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_MostrarProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(new Producto
                            {
                                ProductoId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetFloat(2),
                                Talla = reader.GetString(3),
                                Descripcion = reader.GetString(4),
                                Categoria = reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return productos;
        }

        public async Task<List<Producto>> BuscarProductosAsync(string nombre, string categoria)
        {
            var productos = new List<Producto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_BuscarProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", (object)nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Categoria", (object)categoria ?? DBNull.Value);
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(new Producto
                            {
                                ProductoId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetFloat(2),
                                Talla = reader.GetString(3),
                                Descripcion = reader.GetString(4),
                                Categoria = reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return productos;
        }

        public async Task AgregarAlCarritoAsync(int clienteId, int productoId, int cantidad)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_AgregarAlCarrito", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ClienteId", clienteId);
                    command.Parameters.AddWithValue("@ProductoId", productoId);
                    command.Parameters.AddWithValue("@Cantidad", cantidad);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Carrito>> ObtenerCarritoAsync(int clienteId)
        {
            var carrito = new List<Carrito>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_ObtenerCarrito", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ClienteId", clienteId);
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            carrito.Add(new Carrito
                            {
                                CarritoId = reader.GetInt32(0),
                                ProductoId = reader.GetInt32(1),
                                Nombre = reader.GetString(2),
                                Precio = reader.GetFloat(3),
                                Cantidad = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }

            return carrito;
        }
    }
}