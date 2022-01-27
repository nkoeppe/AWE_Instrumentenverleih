using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data.Sql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kundenverwaltung_.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Kunde> Get()
        {
            List<Kunde> temp = new List<Kunde>();
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id=root; Password=usbw";
            MySqlConnection connect = new MySqlConnection(connectionString);
            string sql_query = "SELECT * FROM kunden";
            MySqlCommand comm = new MySqlCommand(sql_query,connect);


            try
            {
                connect.Open();

            }
            catch
            {

            }
            MySqlDataReader reader = comm.ExecuteReader();
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
            connect.Close();
            return temp;
        }

        // GET api/values/5
        public string Get(int id)
        {
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id=root; Password=usbw";
            MySqlConnection connect = new MySqlConnection(connectionString);
            string sql_query = $"SELECT * FROM kunden WHERE Id= {id}";
            MySqlCommand comm = new MySqlCommand(sql_query, connect);

            try
            {
                comm.Connection.Open();

            }
            catch(Exception e)
            {

            }
            MySqlDataReader reader = comm.ExecuteReader();

            Kunde neuerKunde = new Kunde();
            while (reader.Read())
            {
                
                neuerKunde.Id = Convert.ToInt32(reader.GetString(0));
                neuerKunde.Vorname = reader.GetString(1);
                neuerKunde.Name = reader.GetString(2);
                neuerKunde.Ort = reader.GetString(3);
                neuerKunde.Strasse = reader.GetString(4);
                neuerKunde.Hausnummer = reader.GetString(5);
                neuerKunde.Telefonnummer = reader.GetString(6);
            }

            string temp = JsonConvert.SerializeObject(neuerKunde);
            reader.Close();
            connect.Close();
            return temp;
        }

        // POST api/values
        public void Post([FromBody] Kunde temp)
        {
          
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id=root; Password=usbw";
            MySqlConnection connect = new MySqlConnection(connectionString);
            string sql_query = $"INSERT INTO kunden (Name,Vorname,Ort,strasse,hausnummer,Telefonnummer) VALUES ('{temp.Name}','{temp.Vorname}','{temp.Ort}','{temp.Strasse}','{temp.Hausnummer}','{temp.Telefonnummer}')";
            MySqlCommand comm = new MySqlCommand(sql_query, connect);

            try
            {
                comm.Connection.Open(); 
                comm.ExecuteReader();
            }
            catch(Exception e)
            {

            }
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Kunde temp)
        {
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id=root; Password=usbw";
            MySqlConnection connect = new MySqlConnection(connectionString);
            string sql_query = $"UPDATE Kunden SET Name = '{temp.Name}', Vorname = '{temp.Vorname}', Ort = '{temp.Ort}', strasse = '{temp.Strasse}', hausnummer = '{temp.Hausnummer}', Telefonnummer = '{temp.Telefonnummer}' WHERE ID={id}";
            MySqlCommand comm = new MySqlCommand(sql_query, connect);

            try
            {
                comm.Connection.Open();
                comm.ExecuteReader();

            }
            catch(Exception e)
            {

            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            string connectionString = "Server=localhost; Database=instrumenteverleih; User Id= root; Password=usbw";
            MySqlConnection connect = new MySqlConnection(connectionString);
            string sql_query = $"DELETE FROM Kunden WHERE ID="+id;
            MySqlCommand comm = new MySqlCommand(sql_query, connect);

            try
            {
                comm.Connection.Open();
                comm.ExecuteReader();
            }
            catch(Exception e)
            {

            }
            
        }
    }
}
