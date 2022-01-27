using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Instrumentenverleih.Models
{
    public class Hersteller
    {
        private int id;
        private string name;
        private int plz;
        private string ort;
        private string strasse;

        public string Name { get => name; set => name = value; }
        public int Plz { get => plz; set => plz = value; }
        public string Ort { get => ort; set => ort = value; }
        public string Strasse { get => strasse; set => strasse = value; }
        public int Id { get => id; set => id = value; }

        public Hersteller()
        {
            Id = 0;
            name = "";
            plz = 0;
            ort = "";
            strasse = "";
        }

        public Hersteller(int id, string name, int plz, string ort, string strasse)
        {
            this.Id = id;
            this.name = name;
            this.plz = plz;
            this.ort = ort;
            this.strasse = strasse;
        }
    }
}