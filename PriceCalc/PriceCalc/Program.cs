using System;

namespace PriceCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Luodaan taas muuttujia.
            int ika;
            string varusmies;
            string jasenyys;
            string opiskelija;

            //Konsoli kysyy arvot muuttujille yksi kerrallaan.
            Console.WriteLine("Vastatkaa näihin kysymyksiin:");
            Console.WriteLine("Mikä on ikänne? (Pelkkä numero.)");
            ika = int.Parse(Console.ReadLine());

            Console.WriteLine("Oletteko varusmies? (k/e)");
            varusmies = Console.ReadLine();

            Console.WriteLine("Oletteko mtk:n jäsen? (k/e)");
            jasenyys = Console.ReadLine();

            Console.WriteLine("Oletteko opiskelija? (k/e)");
            opiskelija = Console.ReadLine();

            //Tulostetaan vastaus funktion kautta.
            Console.WriteLine();
            Laskenta(ika, varusmies, jasenyys, opiskelija);


        }

        //Funktio laskentaa varten.
        static void Laskenta(int ika, string vm, string jas, string opis)
        {
            //"hinta" on lipun täysihinta, "ale" on prosenttimäärä lipun maksettavasta hinnasta (100 - alennusprosentti)
            //"ale" oletusarvona 1, jos mikään alennus ei päde niin antaa suoraan täyden hinnan.
            decimal hinta = 16;
            decimal ale = 1;

            //Käydään if-rakenteella kaikki mahdolliset alennukset läpi, suurimmasta pienimpään. Suurin alennus jää täten muistiin.
            //Vauvoille annetaan hinta suoraan nollaksi, muilla annetaan "ale" muuttujalle arvo.
            if (ika < 7)
            {
                hinta = 0;
            }
            else if (jas == "k" && opis == "k")
            {
                ale = 0.40m;
            }
            else if (ika >= 65)
            {
                ale = 0.50m;
            } else if (7 <= ika && ika <= 15)
            {
                ale = 0.50m;
            } else if (vm == "k")
            {
                ale = 0.50m;
            } else if (opis == "k" && jas == "e")
            {
                ale = 0.55m;
            } else if (jas == "k" && opis == "e")
            {
                ale = 0.85m;
            } 

            //Lasketaan ja tulostetaan lipun lopullinen hinta.
            hinta = Decimal.Multiply(hinta, ale);
            Console.WriteLine("Lipun hinta on " + hinta + " euroa.");
        }
    }
}
