using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Kundenverwaltung_.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Kunde> Get()
        {
            List<Kunde> temp = new List<Kunde>();
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = "SELECT * FROM kunde";
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
                Kunde neuerKunde = new Kunde();
                neuerKunde.Id = Convert.ToInt32(reader.GetString(0));
                neuerKunde.Vorname = reader.GetString(1);
                neuerKunde.Name = reader.GetString(2);
                neuerKunde.Ort = reader.GetString(3);
                neuerKunde.Strasse = reader.GetString(4);
                neuerKunde.Hausnummer = reader.GetString(5);
                neuerKunde.Telefonnummer = reader.GetString(6);

                temp.Add(neuerKunde);
            }


            reader.Close();
            conn.Close();
            return temp;
        }

        // GET api/values/5
        public string Get(int id)
        {
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = $"SELECT * FROM kunde WHERE Id= {id}";
            SqlCommand command = new SqlCommand(sql_query, conn);

            try
            {
                command.Connection.Open();

            }
            catch
            {

            }
            SqlDataReader reader = command.ExecuteReader();

            Kunde neuerKunde = new Kunde();
            neuerKunde.Id = Convert.ToInt32(reader.GetString(0));
            neuerKunde.Vorname = reader.GetString(1);
            neuerKunde.Name = reader.GetString(2);
            neuerKunde.Ort = reader.GetString(3);
            neuerKunde.Strasse = reader.GetString(4);
            neuerKunde.Hausnummer = reader.GetString(5);
            neuerKunde.Telefonnummer = reader.GetString(6);

            string temp = JsonConvert.SerializeObject(neuerKunde);
            reader.Close();
            conn.Close();
            return temp;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            Kunde temp = JsonConvert.DeserializeObject<Kunde>(value);
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = "INSERT INTO Kunde ";
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
            Kunde temp = JsonConvert.DeserializeObject<Kunde>(value);
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = "INSERT INTO Kunde ";
            string sql_query2 = "INSERT INTO Ort";
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
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id= root; Password=usbw";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql_query = $"DELETE Kunde WHERE Id= {id}  ";
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
