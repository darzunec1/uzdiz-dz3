﻿using System;
using System.IO;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.IspisKonzola;


namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2
{
    class Program
    {
        private static readonly Random rnd = new Random();

        public static SingletonParametri singletonParametri;

        public static SingletonGenSlucajnihBrojeva genSlucajnihBrojeva;

        public static int vrstaIspisa;

        public static string putanjaDatoteke;

        public static string datotekaParametra;

        internal static void Main(string[] args)
        {
            try
            {
                datotekaParametra = args[0];
            }
            catch (Exception ex)
            {
                IspisKonzola.IspisUvjetni("Neispravni parametri! " + ex.Message);
                Environment.Exit(0);
            }

            //inicijalizacija
            //dohvaćanje instance i putanje
            putanjaDatoteke = Path.GetDirectoryName(datotekaParametra);
            singletonParametri = SingletonParametri.DohvatiInstancu(datotekaParametra);

            vrstaIspisa = int.Parse(singletonParametri.DohvatiParametar("ispis"));

            //Generiranje slučajnog broja!
            int sjemeGeneratora = int.Parse(singletonParametri.DohvatiParametar("sjemeGeneratora"));
            genSlucajnihBrojeva = SingletonGenSlucajnihBrojeva.DohvatiInstancu(sjemeGeneratora);
            int brojDecimala = int.Parse(singletonParametri.DohvatiParametar("brojDecimala"));

            //Inicijalizacija datoteke za logiranje izlaznih podataka
            Inicijalizacija.Inicijaliziraj(singletonParametri, putanjaDatoteke);

            //Citanje datoteke
            Citac citac = new Citac();
            string cijelaPutanjaUlice = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("ulice"));
            citac.UcitajUlice(citac.ProcitajDatoteku(cijelaPutanjaUlice));

            string cijelaPutanjaSpremnici = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("spremnici"));
            citac.UcitajSpremnike(citac.ProcitajDatoteku(cijelaPutanjaSpremnici));

            string cijelaPutanjaPodrucja = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("područja"));
            citac.UcitajPodrucja(citac.ProcitajDatoteku(cijelaPutanjaPodrucja));

            string cijelaPutanjaVozila = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("vozila"));
            citac.UcitajVozila(citac.ProcitajDatoteku(cijelaPutanjaVozila));

            string cijelaPutanjaDispecer = Path.Combine(putanjaDatoteke, singletonParametri.DohvatiParametar("dispečer"));
            citac.UcitajDispecer(citac.ProcitajDatoteku(cijelaPutanjaDispecer));



            GeneriranjeSpremnikaOtpada.GeneriranjeSpremnika(citac);

            GeneriranjeSpremnikaOtpada.DodjelaOtpadaKorisnicima(singletonParametri, genSlucajnihBrojeva);

            //Kreni
            Početak();

        }

        private static void Početak()
        {
            IspisKonzola.IspisKorisnikaOtpad();

            OdlaganjeOtpada.KorisniciOdlazuOtpad();

            IspisKonzola.IspisSpremnikaPoUlicama();
            IspisKonzola.IspisUlicaOtpad();



            DodjelaPodrucja.DodijeliPotpodrucja();

            IspisKonzola.IspisPodrucjaComposite();
            IspisKonzola.DodajPodrucjaUUlice();
            IspisKonzola.IspisOtpadaPoPodrucju();

            Odvoz.ProvediNaredbe();

            //ispis podrucja

            PonudaKontejnera.Ponuda();


        }
    }

}
