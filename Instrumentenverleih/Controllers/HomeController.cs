using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using MySqlConnector;
using Instrumentenverleih.Models;

namespace Instrumentenverleih.Controllers
{
    public class HomeController : ApiController
    {
        // GET api/values
        [Route("api/values")]
        public List<Instrument> Get()
        {
            List<Instrument> instrumentList = new List<Instrument>();
            string connectionString = "server=localhost;database=instrumentenverleih; user id=user;password=aaa333---???";
            MySqlConnection conn = new MySqlConnection(connectionString);
            string sql_query = "SELECT * FROM instrument INNER JOIN hersteller ON instrument.herstellerFK = hersteller.id";
            MySqlCommand command = new MySqlCommand(sql_query, conn);

            try
            {
                command.Connection.Open();

            }
            catch(Exception e)
            {

            }
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Instrument neuesInstrument = new Instrument();
                    neuesInstrument.Id = Convert.ToInt32(reader.GetValue(0));
                    neuesInstrument.Name = Convert.ToString(reader.GetValue(1));
                    neuesInstrument.Preis = Convert.ToDouble(reader.GetValue(3));
                    neuesInstrument.Ausgeliehen = Convert.ToBoolean(reader.GetValue(4));
                    neuesInstrument.Hersteller.Id = Convert.ToInt32(reader.GetValue(5));
                    neuesInstrument.Hersteller.Name = Convert.ToString(reader.GetValue(6));
                    neuesInstrument.Hersteller.Plz = Convert.ToInt32(reader.GetValue(7));
                    neuesInstrument.Hersteller.Ort = Convert.ToString(reader.GetValue(8));
                    neuesInstrument.Hersteller.Strasse = Convert.ToString(reader.GetValue(9));
                    instrumentList.Add(neuesInstrument);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {

            }
            return instrumentList;
        }

        // GET api/values/5
        [Route("api/values/{id}")]
        public string Get(int id)
        {
            string connectionString = "server=localhost;database=instrumentenverleih; uid=user;password=aaa333---???";
            MySqlConnection conn = new MySqlConnection(connectionString);
            string sql_query = $"SELECT * FROM Instrument INNER JOIN hersteller ON instrument.herstellerFK = hersteller.id WHERE Id= {id}";
            MySqlCommand command = new MySqlCommand(sql_query, conn);

            try
            {
                command.Connection.Open();

            }
            catch
            {

            }
            string temp = "";
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Instrument neuesInstrument = new Instrument();
                    neuesInstrument.Id = Convert.ToInt32(reader.GetValue(0));
                    neuesInstrument.Name = Convert.ToString(reader.GetValue(1));
                    neuesInstrument.Preis = Convert.ToDouble(reader.GetValue(3));
                    neuesInstrument.Ausgeliehen = Convert.ToBoolean(reader.GetValue(4));
                    neuesInstrument.Hersteller.Id = Convert.ToInt32(reader.GetValue(5));
                    neuesInstrument.Hersteller.Name = Convert.ToString(reader.GetValue(6));
                    neuesInstrument.Hersteller.Plz = Convert.ToInt32(reader.GetValue(7));
                    neuesInstrument.Hersteller.Ort = Convert.ToString(reader.GetValue(8));
                    neuesInstrument.Hersteller.Strasse = Convert.ToString(reader.GetValue(9));
                    temp = JsonConvert.SerializeObject(neuesInstrument);
                }
                reader.Close();
            }
            catch(Exception e)
            {

            }

            conn.Close();
            return temp;
        }

        // POST api/values
        [Route("api/values/")]
        public void Post([FromBody] string value)
        {
            Instrument temp = JsonConvert.DeserializeObject<Instrument>(value);
            string connectionString = "server=localhost;database=instrumentenverleih; uid=user;password=aaa333---???";
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql_query = "INSERT INTO Hersteller (`ID`,`Name`, `PLZ`, `Ort`, `Straße/Nr.`) VALUES (NULL, '" + temp.Hersteller.Name + "', '" + temp.Hersteller.Plz + "', '" + temp.Hersteller.Ort + "', '" + temp.Hersteller.Strasse + "',)";
                MySqlCommand command = new MySqlCommand(sql_query, conn);
                sql_query = "INSERT INTO Instrument (`ID`,`Name`, `HerstellerFK`, `Preis`, `Ausgeliehen`) VALUES (NULL, '" + temp.Name + "', '" + command.LastInsertedId + "','" + temp.Preis + "','" + temp.Ausgeliehen + "' )";
                command = new MySqlCommand(sql_query, conn);
                try
                {
                    command.Connection.Open();

                }
                catch
                {

                }
                command.ExecuteReader();
            }
            catch (Exception e)
            {

            }
        }

        // PUT api/values/5
        [Route("api/values/{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Instrument temp = JsonConvert.DeserializeObject<Instrument>(value);
            string connectionString = "server=localhost;database=instrumentenverleih; uid=user;password=aaa333---???";
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql_query = "INSERT INTO Hersteller (`ID`,`Name`, `PLZ`, `Ort`, `Straße/Nr.`) VALUES (NULL, '" + temp.Hersteller.Name + "', '" + temp.Hersteller.Plz + "', '" + temp.Hersteller.Ort + "', '" + temp.Hersteller.Strasse + "',)";
                MySqlCommand command = new MySqlCommand(sql_query, conn);
                sql_query = "INSERT INTO Instrument (`ID`,`Name`, `HerstellerFK`, `Preis`, `Ausgeliehen`) VALUES (NULL, '" + temp.Name + "', '" + command.LastInsertedId + "','" + temp.Preis + "','" + temp.Ausgeliehen + "' )";
                command = new MySqlCommand(sql_query, conn);
                try
                {
                    command.Connection.Open();

                }
                catch
                {

                }
                command.ExecuteReader();
            }
            catch (Exception e)
            {

            }
        }

        // DELETE api/values/5
        [Route("api/values/{id}")]
        public void Delete(int id)
        {
            string connectionString = "server=localhost;database=instrumentenverleih; uid=user;password=aaa333---???";
            MySqlConnection conn = new MySqlConnection(connectionString);
            string sql_query = $"DELETE Instrument WHERE Id= {id}";
            MySqlCommand command = new MySqlCommand(sql_query, conn);

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