using System.Collections.Generic;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2.org.foi.uzdiz.dzunec.dz2.Models
{
    public class Dispecer
    {
        public string Komanda { get; set; }

        public int BrojCiklusa { get; set; }

        public List<string> lista1 = new List<string>();

        public List<string> lista2 = new List<string>();

        public Dispecer(string[] input)
        {
            if (input[0].StartsWith("KRENI ", System.StringComparison.Ordinal))
            {
                string[] pomocno = input[0].Split(' ');
                Komanda = pomocno[0];
                BrojCiklusa = int.Parse(pomocno[1]);
            }
            else 
            {
                if (input.Length == 1)
                {
                    if (input[0].Contains(" "))
                    {
                        string[] podjela = input[0].Split(' ');
                        Komanda = podjela[0];
                        BrojCiklusa = int.Parse(podjela[1]);
                    }
                    else
                    {
                        Komanda = input[0];
                        BrojCiklusa = 0;
                    }
                }
                if (input.Length == 2)
                {
                    Komanda = input[0];
                    BrojCiklusa = 0;
                    string[] polje = input[1].Split(',');
                    foreach (var v in polje)
                    {
                        lista1.Add(v);
                    }

                }
                else
                {
                    Komanda = input[0];
                    BrojCiklusa = 0;
                    string[] polje = input[1].Split(',');
                    foreach (var v in polje)
                    {
                        lista1.Add(v);
                    }
                    polje = input[2].Split(',');
                    foreach (var item in polje)
                    {
                        lista2.Add(item);
                    }
                }

            }

        }
    }
}
