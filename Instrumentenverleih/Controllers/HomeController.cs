using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data.Sql;
using Instrumentenverleih.Models;

namespace Instrumentenverleih.Controllers
{
    public class HomeController : ApiController
    {
        // GET api/values
        public List<Instrument> Get()
        {
            List<Instrument> instrumentList = new List<Instrument>();
            string connectionString = "Server=localhost; Database=instrumentenverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = "SELECT * FROM Instrument";
            SqlCommand command = new SqlCommand(sql_query, conn);

            try
            {
                command.Connection.Open();

            }
            catch
            {

            }
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Instrument neuesInstrument = new Instrument();
                neuesInstrument.Id = Convert.ToInt32(reader.GetString(0));
                neuesInstrument.Name = reader.GetString(1);
                //neuesInstrument.Hersteller = Convert.ToInt32(reader.GetString(2));
                neuesInstrument.Preis = Convert.ToInt32(reader.GetString(3));
                neuesInstrument.Ausgeliehen = Convert.ToBoolean(reader.GetString(3));
                instrumentList.Add(neuesInstrument);
            }
            reader.Close();
            conn.Close();
            return instrumentList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            string connectionString = "Server=localhost; Database=instrumentenverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = $"SELECT * FROM Instrument WHERE Id= {id}";
            SqlCommand command = new SqlCommand(sql_query, conn);

            try
            {
                command.Connection.Open();

            }
            catch
            {

            }
            SqlDataReader reader = command.ExecuteReader();

            Instrument neuesInstrument = new Instrument();
            neuesInstrument.Id = Convert.ToInt32(reader.GetString(0));
            neuesInstrument.Name = reader.GetString(1);
            //neuesInstrument.Hersteller = Convert.ToInt32(reader.GetString(2));
            neuesInstrument.Preis = Convert.ToInt32(reader.GetString(3));
            neuesInstrument.Ausgeliehen = Convert.ToBoolean(reader.GetString(3));

            string temp = JsonConvert.SerializeObject(neuesInstrument);
            reader.Close();
            conn.Close();
            return temp;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            Instrument temp = JsonConvert.DeserializeObject<Instrument>(value);
            string connectionString = "Server=localhost; Database=instrumentenverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = "INSERT INTO Instrument";
            SqlCommand command = new SqlCommand(sql_query, conn);

            try
            {
                command.Connection.Open();

            }
            catch
            {

            }
            command.ExecuteReader();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            Instrument temp = JsonConvert.DeserializeObject<Instrument>(value);
            string connectionString = "Server=localhost; Database=instrumentenverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = "INSERT INTO Instrument";
            SqlCommand command = new SqlCommand(sql_query, conn);

            try
            {
                command.Connection.Open();

            }
            catch
            {

            }
            command.ExecuteReader();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            string connectionString = "Server=localhost; Database=instrumentenverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = $"DELETE Instrument WHERE Id= {id}";
            SqlCommand command = new SqlCommand(sql_query, conn);

            try
            {
                command.Connection.Open();

            }
            catch
            {

            }
            command.ExecuteReader();
        }
    }
}