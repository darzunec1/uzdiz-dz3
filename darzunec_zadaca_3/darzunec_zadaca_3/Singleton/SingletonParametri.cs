using System;
using System.Collections.Generic;
using System.IO;

namespace org.foi.uzdiz.dzunec.dz2.dzunec_zadaca_2
{
    public interface IParametar
    {
        string DohvatiParametar(string nazivParametra);
    }

    //singelton klasa koja nasljeđuje interface
    public class SingletonParametri : IParametar
    {
        private static SingletonParametri instancaParametra = null;
        private Dictionary<string, string> parametri = new Dictionary<string, string>();

        private SingletonParametri(string nazivDatParametra)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Učitavanje parametra iz datoteke DZ_3_parametri");
            Console.WriteLine("-----------------------------------------------");
            try
            {
                string[] red = File.ReadAllLines(nazivDatParametra);

                foreach (var item in red)
                {
                    string[] rezultat = item.Split(':');
                    parametri.Add(rezultat[0], rezultat[1]);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nije pronađena putanja, " + ex);
            }

        }

        public string DohvatiParametar(string nazivParametra)
        {  
            return parametri[nazivParametra];
        }

        public static SingletonParametri DohvatiInstancu(string nazivDatParametra)
        {
            if (instancaParametra == null)
            {
                instancaParametra = new SingletonParametri(nazivDatParametra);
            }
            return instancaParametra;
        }
    }
}
