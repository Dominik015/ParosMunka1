using System;
using System.Collections.Generic;

namespace Triangle_Program
{
    internal class Program
    {
        static bool futas = true;

        static void Main(string[] args)
        {
            UdvozloKep();
            // todo: Dániel
            List<string> menupontok = new List<string>()
            {
                "Kerület számítása",
                "Terület számítása",
                "Hiányzó oldal számítása derékszögű háromszögnél",
                "Háromszög ábrázolása",
                "Kilépés"
            };

            ListazMenu(menupontok);

            do
            {
                Console.WriteLine();
                Console.Write("Mit szeretne csinálni? ");
                byte inputUtasitas = Convert.ToByte(Console.ReadLine());
                ElvegzendoFeladat(inputUtasitas);
            }
            while (futas);

            Console.WriteLine("Vége!");
        }

        private static void ListazMenu(List<string> menupontok)
        {
            Console.WriteLine(
                "| " + menupontok[0] + " [1] | " +
                menupontok[1] + " [2] | " +
                menupontok[2] + " [3] | " +
                menupontok[3] + " [4] | " +
                menupontok[4] + " [5] |"
            );
        }

        private static void ElvegzendoFeladat(byte inputUtasitas)
        {
            switch (inputUtasitas)
            {
                case 1:
                    Console.Write("Adja meg az A oldalt: ");
                    double aOldal = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Adja meg a B oldalt: ");
                    double bOldal = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Adja meg a C oldalt: ");
                    double cOldal = Convert.ToDouble(Console.ReadLine());

                    KeruletSzamitas(aOldal, bOldal, cOldal);
                    break;

                case 2:
                    Console.Write("Adja meg az alapot: ");
                    double alap = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Adja meg a magasságot: ");
                    double magassag = Convert.ToDouble(Console.ReadLine());

                    TeruletSzamitas(alap, magassag);
                    break;

                case 3:

                    Console.Write("A oldal: ");
                    string a = Console.ReadLine();

                    Console.Write("B oldal: ");
                    string b = Console.ReadLine();

                    Console.Write("C oldal: ");
                    string c = Console.ReadLine();

                    Console.Write("Alfa szög: ");
                    string alfa = Console.ReadLine();

                    Console.Write("Béta szög: ");
                    string beta = Console.ReadLine();

                    Console.Write("Gamma szög: ");
                    string gamma = Console.ReadLine();

                    HianyzoAdatokSzamitasa(a, b, c, alfa, beta, gamma);
                    break;

                case 4:
                    Console.WriteLine("Ábrázolás nincs kész.");
                    break;

                case 5:
                    futas = false;
                    break;

                default:
                    Console.WriteLine("");
                    break;
            }
        }
        // todo: Dominik
        private static double KeruletSzamitas(double a, double b, double c)
        {
            double kerulet = a + b + c;
            Console.WriteLine($"A háromszög kerülete: {kerulet}");
            return kerulet;
        }

        private static double TeruletSzamitas(double alap, double magassag)
        {
            double terulet = alap * magassag / 2;
            Console.WriteLine($"A háromszög területe: {terulet}");
            return terulet;
        }

        private static void HianyzoAdatokSzamitasa(
            string aOld,
            string bOld,
            string cOld,
            string alfaSzog,
            string betaSzog,
            string gammaSzog)
        {
            bool vanA = !string.IsNullOrWhiteSpace(aOld);
            bool vanB = !string.IsNullOrWhiteSpace(bOld);
            bool vanC = !string.IsNullOrWhiteSpace(cOld);

            bool alfa90 = alfaSzog == "90";
            bool beta90 = betaSzog == "90";
            bool gamma90 = gammaSzog == "90";

            if (!(alfa90 || beta90 || gamma90))
            {
                Console.WriteLine("Csak derékszögű háromszög számítása van.");
                return;
            }

            if (vanA && vanB && !vanC)
            {
                double a = Convert.ToDouble(aOld);
                double b = Convert.ToDouble(bOld);
                double c = Math.Sqrt(a * a + b * b);
                Console.WriteLine($"Hiányzó C oldal: {c}");
                return;
            }

            if (vanA && vanC && !vanB)
            {
                double a = Convert.ToDouble(aOld);
                double c = Convert.ToDouble(cOld);
                double b = Math.Sqrt(c * c - a * a);
                Console.WriteLine($"Hiányzó B oldal: {b}");
                return;
            }

            if (vanB && vanC && !vanA)
            {
                double b = Convert.ToDouble(bOld);
                double c = Convert.ToDouble(cOld);
                double a = Math.Sqrt(c * c - b * b);
                Console.WriteLine($"Hiányzó A oldal: {a}");
                return;
            }
            else
                Console.WriteLine("Nincs elég adat a számításhoz.");
        }

        private static void UdvozloKep()
        {
            Console.Clear();
            Console.WriteLine("Üdvözlöm a háromszög szuper alkalmazásban!");
        }
    }
}
