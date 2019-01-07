using System;
using System.Collections.Generic;
using System.Linq;
using org.foi.uzdiz.darzunec.dz3.Models;
using org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.Models;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Helper
{
    public class Odvoz
    {
        static List<Vozilo> listaVozilaZaSkupljanje = new List<Vozilo>();

        static List<Vozilo> listaVozilaZaPraznjenje = new List<Vozilo>();

        public static int brojacCiklusa = 1;

        public static int ciklus = 0;

        public static string podrucjeZaObradu;

        public static List<string> listaVozilaZaObradu;

        public static SingletonParametri parametri;

        public static void ProvediNaredbe(SingletonParametri singParametri)
        {
            parametri = singParametri;
            foreach (var dispecer in Citac.ListaDispecer)
            {
                string naredba = dispecer.Komanda;

                switch (naredba)
                {
                    case "PRIPREMI":

                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Pripremi vozila");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        PripremaVozila(dispecer.lista1);
                        break;
                    case "KRENI":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Vozila krećeju pokupljati otpad");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        VozilaKrecu(dispecer.BrojCiklusa);
                        brojacCiklusa = 0;
                        break;
                    case "KVAR":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Kvar vozila");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        VozilaKvar(dispecer.lista1);
                        break;
                    case "STATUS":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Status svih vozila");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        StatusVozila(dispecer.lista1);
                        break;
                    case "ISPRAZNI":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Pražnjenje vozila");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        PraznjenjeVozila(dispecer.lista1);
                        break;
                    case "KONTROLA":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Vozilo ide na kontrolu");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        break;
                    case "OBRADI":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Odabir područja za obradu");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        OdabirPodrucjaZaObradu(dispecer.lista1, dispecer.lista2);
                        break;
                    case "GODIŠNJI ODMOR":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Godišnji odmor");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        GodisnjiOdmor(dispecer.lista1);
                        break;
                    case "BOLOVANJE":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Bolovanje");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        Bolovanje(dispecer.lista1);
                        break;
                    case "OTKAZ":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Otkaz");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        Otkaz(dispecer.lista1);
                        break;
                    case "PREUZMI":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Preuzmi vozilo");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        PreuzmiVozilo(dispecer.lista1,dispecer.lista2);
                        break;
                    case "NOVI":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA: Dodavanje novog vozača");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        NoviVozaci(dispecer.lista1);
                        break;
                    case "VOZAČI":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA:Vozači ");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        IspisVozaca();
                        break;
                    case "IZLAZ":
                        IspisKonzola.IspisKonzola.IspisUvjetni("- - - > NAREDBA:IZLAZ ");
                        IspisKonzola.IspisKonzola.IspisUvjetni("");
                        Environment.Exit(0);
                        break;
                    default:
                        IspisKonzola.IspisKonzola.IspisUvjetni("Ne postoji naredba");
                        break;
                }
            }
        }

        private static void OdabirPodrucjaZaObradu(List<string> lista1, List<string> lista2)
        {

        }

        private static void PreuzmiVozilo(List<string> lista1, List<string> lista2)
        {
            Vozaci vozacMakni = null;
            foreach (Vozilo vozilo in Citac.ListaVozila)
            {
                foreach (Vozaci vozac in vozilo.Vozaci)
                {
                    if (vozac.Ime == lista1[0])
                    {
                        vozacMakni = vozac;
                    }
                }
                vozilo.Vozaci.Remove(vozacMakni);
            }
            foreach (Vozilo vozilo in Citac.ListaVozila)
            {
                if (vozilo.Id == lista2[0])
                {
                    vozilo.Vozaci.Add(vozacMakni);
                }
            }

        }

        private static void Otkaz(List<string> lista1)
        {
            foreach (var ime in lista1)
            {
                foreach (var vozac in Citac.Vozaci)
                {
                    if (ime == vozac.Ime)
                    {
                        vozac.StatusVozaca = "Otkaz";
                    }
                }
            }
        }

        private static void Bolovanje(List<string> lista1)
        {
            foreach (var ime in lista1)
            {
                foreach (var vozac in Citac.Vozaci)
                {
                    if (ime == vozac.Ime)
                    {
                        vozac.StatusVozaca = "Bolovanje";
                    }
                }
            }
        }

        private static void IspisVozaca()
        {
            IspisKonzola.IspisKonzola.IspisUvjetni("Ispis statusa svih vozača: ");
            IspisKonzola.IspisKonzola.IspisVozaca();
        }

        private static void GodisnjiOdmor(List<string> vozaci)
        {
            foreach (var ime in vozaci)
            {
                foreach (var vozac in Citac.Vozaci)
                {
                    if (ime == vozac.Ime)
                    {
                        vozac.StatusVozaca = "Godišnji odmor";
                    }
                }
            }

        }

        private static void NoviVozaci(List<string> vozaci)
        {
            foreach (var vozac in vozaci)
            {
                Vozaci v = new Vozaci();
                v.Ime = vozac;
                v.StatusVozaca = "Novi";
                Citac.Vozaci.Add(v);
            }
            IspisKonzola.IspisKonzola.IspisUvjetni("Dodani su novi vozači!");
        }

        private static void StatusVozila(List<string> listaVozilaDispecer)
        {
            IspisKonzola.IspisKonzola.IspisUvjetni("Ispis statusa sih vozila: ");
            foreach (var vozilo in Citac.ListaVozila)
            {
                IspisKonzola.IspisKonzola.IspisUvjetni("Vozilo: " + vozilo.Id + " " + vozilo.Naziv + " Status:" + vozilo.Status + " Popunjenost: " + vozilo.Popunjenost + " Dostupno: " + vozilo.Dostupno);
            }
        }

        private static void PraznjenjeVozila(List<string> listaVozilaDispecer)
        {
            foreach (var vozilo in Citac.ListaVozila)
            {
                if (vozilo.Status == "Praznjenje")
                {
                    vozilo.Dostupno = vozilo.Nosivost;
                    vozilo.Popunjenost = 0;
                    vozilo.Status = "Pripremljeno";
                    IspisKonzola.IspisKonzola.IspisUvjetni("Vozilo " + vozilo.Id + " " + vozilo.Naziv + " je ispraznilo svoj otpad!");
                }
            }
        }

        private static void VozilaKvar(List<string> listaVozilaDispecer)
        {
            foreach (var voziloId in listaVozilaDispecer)
            {
                List<Vozilo> v = Citac.ListaVozila.Where(p => p.Id == voziloId).ToList();
                foreach (var voz in v)
                {
                    voz.Status = "Kvar";
                }
            }
            foreach (var vozilo in Citac.ListaVozila)
            {
                if (vozilo.Status == "Kvar")
                {
                    IspisKonzola.IspisKonzola.IspisUvjetni("Vozilo " + vozilo.Id + " " + vozilo.Naziv + "  Status: " + vozilo.Status);
                }
            }
        }

        private static void VozilaKrecu(int brojCiklusa)
        {
            DefinirajPreuzimanje();

            DodijeliVrsteSpremnika();

            DajRasporedSpremnika();

            SkupljajOtpad(brojCiklusa);
            
        }


        private static void DajRasporedSpremnika()
        {

            foreach (var vozilo in Citac.ListaVozila)
            {
                Kolekcija kolekcija = new Kolekcija();

                foreach (int brojUlice in vozilo.redoslijedKretanja)
                {
                    Ulica ulica = Citac.ListaUlica[brojUlice];
                    List<Spremnik> listaSpremnika = ulica.ListaSpremnikaUlice.Where(s => s.Naziv == vozilo.VrstaSpremnika).ToList();
                    for (int i = 0; i < listaSpremnika.Count; i++)
                    {
                        kolekcija[i] = listaSpremnika[i];
                    }
                }

                Iterator iterator = kolekcija.KreirajIterator();
                vozilo.Iterator = iterator;
            }
        }

        private static void DodijeliVrsteSpremnika()
        {
            foreach (var vozilo in Citac.ListaVozila)
            {
                vozilo.DodijeliVrstuSpremnika(vozilo);
            }
        }

        private static void SkupljajOtpad(int brojCiklusa)
        {
            while (brojCiklusa > brojacCiklusa)
            {
                foreach (var vozilo in listaVozilaZaSkupljanje)
                {
                    if (listaVozilaZaSkupljanje.Count > 0 && !vozilo.Iterator.JelGotovo)
                    {

                        Spremnik s = vozilo.Iterator.TrenutniSpremnik;
                        if (s.KolicinaOtpada > 0)
                        {
                            if (vozilo.Dostupno > s.KolicinaOtpada)
                            {
                                IspisKonzola.IspisKonzola.IspisUvjetni("-----------------------------------------------------------------------");
                                vozilo.Popunjenost += s.KolicinaOtpada;
                                vozilo.Dostupno = vozilo.Nosivost - vozilo.Popunjenost;
                                s.KolicinaOtpada = 0;
                                vozilo.Iterator.Sljedeci();
                                IspisKonzola.IspisKonzola.IspisUvjetni(ciklus + " CIKLUS" + " Vozilo " + vozilo.Naziv + " Nosivost: " + vozilo.Nosivost + " Pokupilo: " + vozilo.Popunjenost);
                                ciklus++;

                            }
                            else
                            {
                                vozilo.Status = "Praznjenje";
                                ciklus++;
                            }
                           
                        }
                    }
                    brojacCiklusa++;

                }
            }

        }

        private static void DefinirajPreuzimanje()
        {
            int preuzimanje = int.Parse(Program.singletonParametri.DohvatiParametar("preuzimanje"));

            if (preuzimanje == 0)
            {
                List<int> redoslijedStaticni = DajRedoslijedUlica();

                foreach (var vozilo in Citac.ListaVozila)
                {
                    vozilo.redoslijedKretanja = redoslijedStaticni;
                }
            }
            else
            {
                foreach (var vozilo in Citac.ListaVozila)
                {
                    vozilo.redoslijedKretanja = DajRedoslijedUlica();
                }
            }
        }

        public static List<int> DajRedoslijedUlica()
        {
            List<int> redoslijedUlica = new List<int>();

            int sjemeGeneratora = int.Parse(Program.singletonParametri.DohvatiParametar("sjemeGeneratora"));
            SingletonGenSlucajnihBrojeva genSlucajnihBrojeva = SingletonGenSlucajnihBrojeva.DohvatiInstancu(sjemeGeneratora);

            do
            {
                int slucajniBroj = genSlucajnihBrojeva.SlucajniBrojInt(0, Citac.ListaUlica.Count );
                if (!redoslijedUlica.Contains(slucajniBroj))
                {
                    redoslijedUlica.Add(slucajniBroj);
                }

            } while (redoslijedUlica.Count != Citac.ListaUlica.Count);

            return redoslijedUlica;
        }

        private static void PripremaVozila(List<string> stringVozila)
        {
            foreach (var idVozila in stringVozila)
            {
                foreach (var vozilo in Citac.ListaVozila)
                {
                    if (vozilo.Id == idVozila)
                    {
                        vozilo.Status = "Pripremljeno";
                        if (vozilo.Tip == 0)
                        {
                            vozilo.CiklusKapacitet = int.Parse(parametri.DohvatiParametar("kapacitetDizelVozila"));
                            vozilo.CiklusPunjenja = int.Parse(parametri.DohvatiParametar("punjenjeDizelVozila"));
                        }
                        else
                        {
                            vozilo.CiklusKapacitet = int.Parse(parametri.DohvatiParametar("kapacitetElektroVozila"));
                            vozilo.CiklusPunjenja = int.Parse(parametri.DohvatiParametar("punjenjeElektroVozila"));
                        }
                        listaVozilaZaSkupljanje.Add(vozilo);
                        IspisKonzola.IspisKonzola.IspisUvjetni("Vozilo " + vozilo.Id + " je dodano u listu pripremljenih vozila!");
                       
                    }
                }
            }
        }
    }
}
