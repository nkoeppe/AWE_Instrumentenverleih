using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kundenverwaltung_
{
    public class Kunde
    {
        private int _id;
        private string _name;
        private string _vorname;
        private string _ort;
        private string _strasse;
        private string _hausnummer;
        private string _telefonnummer;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Vorname { get => _vorname; set => _vorname = value; }
        public string Ort { get => _ort; set => _ort = value; }
        public string Strasse { get => _strasse; set => _strasse = value; }
        public string Hausnummer { get => _hausnummer; set => _hausnummer = value; }
        public string Telefonnummer { get => _telefonnummer; set => _telefonnummer = value; }

        public Kunde()
        {

        }
        public Kunde(string name, string vorname, string ort, string strasse, string hausnummer, string telefonnummer)
        {
            this.Name = name;
            this.Vorname = vorname;
            this.Ort = ort;
            this.Strasse = strasse;
            this.Hausnummer = hausnummer;
            this.Telefonnummer = telefonnummer;

        }
    }
}