using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrkartenAutomatv2CS
{
    class Program
    {
        static void Main(string[] args)
        {
            double preis = 0.0, rest = 0.0;
            int karte = 0;
            int menge = 0;

            //Aufruf Methoden

            karte = AuswahlFahrkarte();
            preis = PreisSelector(karte);
            menge = EingabeMenge();
            rest = BezahlVorgang(preis, menge);
            AusgabeDerKarten(menge);
            RueckgabeDesWechelgelds(rest);

            Console.WriteLine("Druecken sie Enter zum Beenden.");
            Console.ReadLine();
            return;
        }

        static int AuswahlFahrkarte()
        {
            // Auswahl der Fahrkarte
            int karte;
            Console.WriteLine("Fahrkartenautomat\n");
            Console.WriteLine("Waehlen sie ihr Karte aus:");
            Console.WriteLine("1) Normal (3,20 Euro)");
            Console.WriteLine("2) Ermaessigt (2,40 Euro)");
            Console.WriteLine("Geben sie 1 oder 2 ein: ");
            karte = Int32.Parse(Console.ReadLine());
            return karte;
        }

        static double PreisSelector(int karte)
        {
            // lege den zu zahlenden Betrag fest
            double preis;
            switch (karte)
            {
                case 1:
                    preis = 3.20;
                    break;
                case 2:
                    preis = 2.40;
                    break;
                default:
                    preis = 0.0;
                    break;

            }
            return preis;
        }

        static int EingabeMenge()
        {
            // Eingabe der Menge
            int menge = 1;
            Console.WriteLine("Geben sie die gewuenschte Menge ein: ");
            menge = Int32.Parse(Console.ReadLine());
            return menge;
        }

        static double BezahlVorgang(double preis, int menge)
        {
            // Bezahlvorgang
            Console.WriteLine("--- Bezahlvorgang ---");
            double einwurf;
            double zuZahlen = preis * menge;            
            do
            {
                Console.WriteLine("Es fehlen noch {0} Euro.", zuZahlen);
                Console.WriteLine("Bitte werfen sie ein Geldstueck ein: ");
                einwurf = Double.Parse(Console.ReadLine());

                // eingeworfenen Betrag anrechnen
                zuZahlen -= einwurf;                
            }
            while (zuZahlen >= 0.0);
            return zuZahlen;
        }
        
        static void AusgabeDerKarten(int menge)
        {
            // Ausgabe der Karten
            Console.WriteLine("\n--- Kartenausgabe ---\n");
            int ai;
            for (ai = 0; ai < menge; ai++)
            {
                Console.WriteLine("Karte {0} von {1} wurde ausgegeben.", ai + 1, menge);
            }
            Console.WriteLine("\nVielen Dank, bitte entnehmen sie ihre Karten.");
            return;
        }
        
        static void RueckgabeDesWechelgelds(double zuZahlen)
        {
            // Wechselgeld Rückgabe
            zuZahlen = zuZahlen * (-1.0) * 100;
            int rest = (int)zuZahlen;
            int i2 = 0;

            int[] geldwert = new int[8] { 200, 100, 50, 20, 10, 5, 2, 1 };
            int[] anzahl = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            while (rest != 0)
            {   
                if (rest >= geldwert[i2])
                {
                    rest = rest - geldwert[i2];
                    anzahl[i2] = anzahl[i2] + 1;
                }
                else
                {
                    i2 = i2 + 1;
                }
            }
            Console.WriteLine(" 2 Euro x {0}", anzahl[0]);
            Console.WriteLine(" 1 Euro x {0}", anzahl[1]);
            Console.WriteLine("50 Cent x {0}", anzahl[2]);
            Console.WriteLine("20 Cent x {0}", anzahl[3]);
            Console.WriteLine("10 Cent x {0}", anzahl[4]);
            Console.WriteLine(" 5 Cent x {0}", anzahl[5]);
            Console.WriteLine(" 2 Cent x {0}", anzahl[6]);
            Console.WriteLine(" 1 Cent x {0}", anzahl[7]);
            Console.WriteLine("Bitte entnehmen sie ihr Rueckgeld \n");
            return;
        }
        
    }
}
