﻿using System.Collections.Generic;
using org.foi.uzdiz.darzunec.dz3.Models;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models
{
    class Vozilo
    {
        public string Id { get; set; }

        public string Naziv { set; get; }

        public int Tip { get; set; }

        public int Vrsta { get; set; }

        public float Nosivost { get; set; }

        public float Popunjenost { get; set; }

        public float Dostupno { get; set; }

        public string VrstaSpremnika { get; set; }

        public string Status { get; set; }

        public Iterator Iterator { get; set; }

        public List<Vozaci> Vozaci = new List<Vozaci>();

        public List<int> redoslijedKretanja = new List<int>();

        

        public Vozilo(string[] input)
        {
            Id = input[0];
            Naziv = input[1];
            Tip = int.Parse(input[2]);
            Vrsta = int.Parse(input[3]);
            Nosivost = float.Parse(input[4]);
            Status = "Parking";
            Dostupno = Nosivost;

            string[] polje = input[5].Split(',');
            foreach (var item in polje)
            {

                Vozaci vozac = new Vozaci();
                vozac.Ime = item.Replace(" ", string.Empty); ;
                vozac.StatusVozaca = "Aktivni";
                Vozaci.Add(vozac);
            }
        }

        public void DodijeliVrstuSpremnika(Vozilo v)
        {
            if (v.Vrsta == 0)
            {
                v.VrstaSpremnika = "staklo";
            }
            else if (v.Vrsta == 1)
            {
                v.VrstaSpremnika = "papir";
            }

            else if (v.Vrsta == 2)
            {
                v.VrstaSpremnika = "metal";
            }

            else if (v.Vrsta == 3)
            {
                v.VrstaSpremnika = "bio";
            }
            else
            {
                v.VrstaSpremnika = "mješano";
            }

        }
    }
}
