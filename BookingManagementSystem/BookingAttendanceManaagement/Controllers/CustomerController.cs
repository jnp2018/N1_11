using CustomerManagement.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingAttendanceManaagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<PhimsController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "SELECT * FROM customer";
            var customer = mySqlConnection.Query<Customer>(sql);
            return customer.ToList();
        }

        // GET api/<PhimsController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var mySqlConnection = new MySqlConnection(connectionString);
            var param = new Dictionary<string, object>();
            param.Add("@id", id);
            string sql = "SELECT * FROM customer WHERE Id = @id";
            var customer = mySqlConnection.QueryFirstOrDefault<Customer>(sql,param);
            return customer;
        }

        // POST api/<PhimsController>
        [HttpPost]
        public int Post([FromBody] Customer value)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("@id", value.ID);
            param.Add("@fullname", value.FullName);
            param.Add("@email", value.Email);
            param.Add("@phonenumber", value.PhoneNumber);
            param.Add("@address", value.Address);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "INSERT INTO customer(ID, FullName, Email, PhoneNumber, Address) VALUES (@id, @fullname, @email, @phonenumber, @address)";
            var res = mySqlConnection.Execute(sql, param);
            return res;
        }

        // PUT api/<PhimsController>/5
        [HttpPut]
        public int Put([FromBody] Customer value)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("@id", value.ID);
            param.Add("@fullname", value.FullName);
            param.Add("@email", value.Email);
            param.Add("@phonenumber", value.PhoneNumber);
            param.Add("@address", value.Address);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "UPDATE customer SET FullName = @fullname, Email = @email, PhoneNumber = @phonenumber, Address = @address WHERE Id = @id;";
            var res = mySqlConnection.Execute(sql, param);
            return res;
        }

        // DELETE api/<PhimsController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("id", id);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "DELETE FROM customer WHERE Id = @id;";
            var res = mySqlConnection.Execute(sql, param);
            return res;
        }
    }
}
