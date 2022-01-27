using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Instrumentenverleih.Models
{
    public class Instrument
    {
        private int id;
        private string name;
        private Hersteller hersteller;
        private double preis;
        private bool ausgeliehen;

        public string Name { get => name; set => name = value; }
        public Hersteller Hersteller { get => hersteller; set => hersteller = value; }
        public double Preis { get => preis; set => preis = value; }
        public bool Ausgeliehen { get => ausgeliehen; set => ausgeliehen = value; }
        public int Id { get => id; set => id = value; }

        public Instrument()
        {
            Id = 0;
            name = "";
            hersteller = new Hersteller();
            preis = 0;
            ausgeliehen = false;
        }

        public Instrument(int id, string name, Hersteller hersteller, double preis, bool ausgeliehen)
        {
            this.Id = id;
            this.name = name;
            this.hersteller = hersteller;
            this.preis = preis;
            this.ausgeliehen = ausgeliehen;
        }
    }
}