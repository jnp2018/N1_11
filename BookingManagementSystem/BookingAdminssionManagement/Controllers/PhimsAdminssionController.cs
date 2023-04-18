using BookingAdminssionManagement.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingAdminssionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhimsAdminssionController : ControllerBase
    {
        // GET: api/<PhimsController>
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "SELECT * FROM film";
            var film = mySqlConnection.Query<Film>(sql);
            return film.ToList();
        }

        // GET api/<PhimsController>/5
        [HttpGet("{id}")]
        public Film Get(int id)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("@id", id);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "SELECT * FROM film WHERE Id = @id";
            var film = mySqlConnection.QueryFirstOrDefault<Film>(sql, param);
            return film;
        }

        // POST api/<PhimsController>
        [HttpPost]
        public int Post([FromBody] Film value)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("@id", value.Id);
            param.Add("@filmname", value.FilmName);
            param.Add("@author", value.Author);
            param.Add("@type", value.Type);
            param.Add("@desc", value.Description);
            param.Add("@time", value.Time);
            param.Add("@year", value.PublishingYear);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "INSERT INTO film(Id, FilmName, Author, Type, Description, Time, PublishingYear) VALUES (@id, @filmname, @author, @type, @desc, @time, @year)";
            var res = mySqlConnection.Execute(sql, param);
            if (res > 0)
            {
                string from, to, pass, content;
                from = "boxuanhoang2016@gmail.com";
                to = "vietdoan08032001@gmail.com";
                pass = "Hoang1708";
                content = "Hello anh Việt đẹp trai";
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from);
                mail.Subject = "Heelo anh Vinh khoai to";
                mail.Body = content;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(mail);
                    Console.WriteLine("Oke anh zai");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
            else
            {
                Console.WriteLine("Lỗi");
            }
            return res;
        }

        // PUT api/<PhimsController>/5
        [HttpPut]
        public int Put([FromBody] Film value)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("@id", value.Id);
            param.Add("@filmname", value.FilmName);
            param.Add("@author", value.Author);
            param.Add("@type", value.Type);
            param.Add("@desc", value.Description);
            param.Add("@time", value.Time);
            param.Add("@year", value.PublishingYear);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "UPDATE film SET FilmName = @filmname, Author = @author', Type = @type, Description = @desc, Time = @time, PublishingYear = @year WHERE Id = @id;";
            var res = mySqlConnection.Execute(sql, param);
            return res;
        }

        // DELETE api/<PhimsController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            string connectionString = "Server = localhost; Port = 3306; Database = booking_film_ticket; Uid = root; Pwd = 08032001123Aa@;";
            var param = new Dictionary<string, object>();
            param.Add("@id", id);
            var mySqlConnection = new MySqlConnection(connectionString);
            string sql = "DELETE FROM film WHERE Id = @id;";
            var res = mySqlConnection.Execute(sql, param);
            return res;
        }
    }
}
