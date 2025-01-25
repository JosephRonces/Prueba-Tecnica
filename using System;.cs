using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace EventManagerAPI.Controllers
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int RolID { get; set; }
    }

    public class Evento
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioID { get; set; }
    }

    [RoutePrefix("api/evento")]
    public class EventoController : ApiController
    {
        private readonly MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEventos()
        {
            List<Evento> eventos = new List<Evento>();
            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Evento", _connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    eventos.Add(new Evento
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Titulo = reader["Titulo"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Lugar = reader["Lugar"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        UsuarioID = Convert.ToInt32(reader["UsuarioID"])
                    });
                }
                reader.Close();
            }
            finally
            {
                _connection.Close();
            }
            return Ok(eventos);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateEvento([FromBody] Evento evento)
        {
            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Evento (Titulo, Descripcion, Lugar, Fecha, UsuarioID) VALUES (@Titulo, @Descripcion, @Lugar, @Fecha, @UsuarioID)", _connection);
                cmd.Parameters.AddWithValue("@Titulo", evento.Titulo);
                cmd.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                cmd.Parameters.AddWithValue("@Lugar", evento.Lugar);
                cmd.Parameters.AddWithValue("@Fecha", evento.Fecha);
                cmd.Parameters.AddWithValue("@UsuarioID", evento.UsuarioID);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
            return Ok("Evento creado exitosamente");
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateEvento(int id, [FromBody] Evento evento)
        {
            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Evento SET Titulo=@Titulo, Descripcion=@Descripcion, Lugar=@Lugar, Fecha=@Fecha, UsuarioID=@UsuarioID WHERE ID=@ID", _connection);
                cmd.Parameters.AddWithValue("@Titulo", evento.Titulo);
                cmd.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                cmd.Parameters.AddWithValue("@Lugar", evento.Lugar);
                cmd.Parameters.AddWithValue("@Fecha", evento.Fecha);
                cmd.Parameters.AddWithValue("@UsuarioID", evento.UsuarioID);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
            return Ok("Evento actualizado exitosamente");
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteEvento(int id)
        {
            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Evento WHERE ID=@ID", _connection);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
            return Ok("Evento eliminado exitosamente");
        }
    }
}