using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using TicketManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        // GET: api/<TicketsController>
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "SELECT * FROM ticket";
            var tickets = mySqlConnection.Query<Ticket>(sql);
            return tickets.ToList();
        }

        // GET api/<TicketsController>/5
        [HttpGet("{id}")]
        public Ticket Get(int id)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("@id", id);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "SELECT * FROM ticket WHERE Id = @id";
            var ticket = mySqlConnection.QueryFirstOrDefault<Ticket>(sql, param);
            return ticket;
        }

        // POST api/<TicketsController>
        [HttpPost]
        public int Post([FromBody] Ticket value)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            var guid = Guid.NewGuid();
            param.Add("@id", value.Id);
            param.Add("@code", guid);
            param.Add("@seatNumber", value.SeatNumber);
            param.Add("@id_film", value.ID_Film);
            param.Add("@id_customer", value.ID_Customer);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "INSERT INTO ticket(Id, Code, SeatNumber, ID_Film, ID_Customer) VALUES (@id, @code, @seatNumber, @id_film, @id_customer)";
            var res = mySqlConnection.Execute(sql, param);
            return res;
        }

        // PUT api/<TicketsController>/5
        [HttpPut]
        public int Put([FromBody] Ticket value)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("@id", value.Id);
            param.Add("@seatNumber", value.SeatNumber);
            param.Add("@id_film", value.ID_Film);
            param.Add("@id_customer", value.ID_Customer);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "UPDATE ticket SET SeatNumber = @seatNumber, ID_Film = @id_film, ID_Customer = @id_customer WHERE Id = @id;";
            var res = mySqlConnection.Execute(sql, param);
            return res;
        }

        // DELETE api/<TicketsController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("@id", id);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "DELETE FROM ticket WHERE Id = @id;";
            var res = mySqlConnection.Execute(sql, param);
            return res;
        }
    }
}
