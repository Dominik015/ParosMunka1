// CSAPATTAGOK : Vékony Dominik és Párványik Dániel
using System.Diagnostics;

namespace Triangle_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdvozloKep();
            List<string> menupontok = new List<string>();
            menupontok.Add("Kerület számítása");
            menupontok.Add("Terület számítása");
            menupontok.Add("Hiányzó adatok számítása");
            menupontok.Add("Háromszög ábrázolása");
            menupontok.Add("Szerkeszthetőség");
            menupontok.Add("Kilépés");
            ListazMenu(menupontok);

            bool futas = true;
            do
            {
                Console.WriteLine("\n");
                Console.Write("Mit szeretne csinálni? : ");
                byte inputUtasitas = Convert.ToByte(Console.ReadLine());
                futas = ElvegzendoFeladat(inputUtasitas);
            }
            while (futas);

            Console.WriteLine("\n");
            int consoleYValue = Console.CursorTop;
            Console.SetCursorPosition(45, consoleYValue);
            Console.WriteLine("Vége!");
        }

        // TODO (Dani) : ListazMenu
        private static void ListazMenu(List<string> menupontok)
        {
            Console.WriteLine("\n");
            Console.WriteLine("| " + menupontok[0] + " [1] | " + menupontok[1] + " [2] | " + menupontok[2] + " [3] | \n" + "| " + menupontok[3] + " [4] | " + menupontok[4] + " [5] | " + menupontok[5] + " [6] |");
        }

        // TODO (Dani) : ElvegzendoFeladat
        private static bool ElvegzendoFeladat(byte inputUtasitas)
        {
            switch (inputUtasitas)
            {
                case 1:
                    Console.WriteLine("<- Háromszög kerületének számítása! ->\n");
                    Console.Write("Adja meg az a oldalt: ");
                    double aOldal = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Adja meg az b oldalt: ");
                    double bOldal = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Adja meg az c oldalt: ");
                    double cOldal = Convert.ToDouble(Console.ReadLine());
                    KeruletSzamitas(aOldal, bOldal, cOldal);
                    return true;
                case 2:
                    Console.WriteLine("<- Háromszög területének számítása! ->\n");
                    Console.Write("Adja meg a háromszög adott oldalához tartozó magasságot: ");
                    double magasssagOldal = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Adja meg a háromszög adott magasságához tartozó oldalt: ");
                    double magassag = Convert.ToDouble(Console.ReadLine());
                    TeruletSzamitas(magasssagOldal, magassag);
                    return true;
                case 3:
                    Console.WriteLine("<- Derékszögű háromszög hiányzó adatainak számítása! ->\n");
                    Console.Write("Adja meg az a oldalt: ");
                    string aOldalMegadott = Console.ReadLine();
                    Console.Write("Adja meg az b oldalt: ");
                    string bOldalMegadott = Console.ReadLine();
                    Console.Write("Adja meg az c oldalt: ");
                    string cOldalMegadott = Console.ReadLine();
                    Console.Write("Adja meg az αlfa szöget: ");
                    string alfaSzogMegadott = Console.ReadLine();
                    Console.Write("Adja meg a beta szöget: ");
                    string betaSzoglMegadott = Console.ReadLine();
                    Console.Write("Adja meg a gamma szöget: ");
                    string gammaSzogMegadott = Console.ReadLine();
                    HianyzoAdatokSzamitasa(aOldalMegadott, bOldalMegadott, cOldalMegadott, alfaSzogMegadott, betaSzoglMegadott, gammaSzogMegadott);
                    return true;
                case 4:
                    Console.WriteLine("<- Általános háromszög rajzolása! ->\n");
                    Console.Write("Adja meg az a oldalt: ");
                    double aOldalRajzolashoz = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Adja meg az b oldalt: ");
                    double bOldalRajzolashoz = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Adja meg az c oldalt: ");
                    double cOldalRajzolashoz = Convert.ToDouble(Console.ReadLine());
                    DrawTriangle(aOldalRajzolashoz, bOldalRajzolashoz, cOldalRajzolashoz);
                    return true;
                case 5:
                    Console.WriteLine("<- Szerkeszthető-e a háromszög? ->\n");
                    Console.Write("Adja meg az a oldalt: ");
                    double aOldalSzerkeszteshez = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Adja meg az b oldalt: ");
                    double bOldalSzerkeszteshez = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Adja meg az c oldalt: ");
                    double cOldalSzerkeszteshez = Convert.ToDouble(Console.ReadLine());
                    if (SzerkeszhetoeHaromszog(aOldalSzerkeszteshez, bOldalSzerkeszteshez, cOldalSzerkeszteshez))
                    {
                        Console.WriteLine("A háromszög szerkeszthető.");
                    }
                    else
                    {
                        Console.WriteLine("A háromszög nem szerkeszthető.");
                    }
                    return true;
                case 6:
                    Console.WriteLine("\n");
                    Console.WriteLine("Kilépés!");
                    return false;
                default:
                    Console.WriteLine("Érvénytelen menüpont!");
                    return true;
            }
        }
        private static void UdvozloKep()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 0);
            Console.WriteLine("Üdvözlöm a Háromszög Szuper alkalmazásban!");
            Console.SetCursorPosition(10, 1);
            Console.WriteLine("\nTudnivaló: a program az általános jelölését alkalmazza a háromszög oldalainak és szögeinek!");
            Console.WriteLine("\n Átfogó jelölése: c - Egyik befogó: a - Másik befogó: b");
            char alfaJel = 'α';
            char betaJel = 'β';
            char gammaJel = 'γ';
            Console.WriteLine($"\n c oldalhoz tartozó szög: {gammaJel} - a oldalhoz tartozó szög: {alfaJel} - b oldalhoz tartozó szög: {betaJel}");
        }

        // TODO (Dominik) : KeruletSzamitas
        private static void KeruletSzamitas(double aOldal, double bOldal, double cOldal)
        {

            Console.WriteLine($"A háromszög kerülete: {aOldal + bOldal + cOldal}");
        }

        // TODO (Dominik) : TeruletSzamitas
        private static void TeruletSzamitas(double magassagOldal, double magassag)
        {

            Console.WriteLine($"A háromszög területe: {magassagOldal * magassag / 2}");
        }

        // TODO (Dani) : DrawTriangle
        private static void DrawTriangle(double aOldalRajzolashoz, double bOldalRajzolashoz, double cOldalRajzolashoz)
        {
            if (aOldalRajzolashoz <= 0 || bOldalRajzolashoz <= 0 || cOldalRajzolashoz <= 0)
            {
                throw new ArgumentException("Az oldalak értéke nem lehet 0 vagy negatív.");
            }
            else if (!SzerkeszhetoeHaromszog(aOldalRajzolashoz, bOldalRajzolashoz, cOldalRajzolashoz))
            {
                throw new ArgumentException("A megadott oldalakból nem szerkeszthető háromszög!");
            }
            //char signDraw = '*';
            //int y = Console.CursorTop;

            //for (int i = 0; i < aOldalRajzolashoz; i++)
            //{
            //    Console.SetCursorPosition(30+i, y+i);
            //    Console.WriteLine(signDraw);
            //}
            //for (int i = 0; i < cOldalRajzolashoz; i++)
            //{
            //    Console.SetCursorPosition(30+i, y+i);
            //    Console.WriteLine(signDraw);
            //}
            //for (int i = 0; i < bOldalRajzolashoz; i++)
            //{
            //    Console.SetCursorPosition(30 + i, y + i);
            //    Console.WriteLine(signDraw);
            //}
            char sign = '*';

            int startX = (Console.WindowWidth - (int)aOldalRajzolashoz) / 2;
            int startY = Console.CursorTop + 1;

            int Ax = startX;
            int Ay = startY;

            int Bx = startX + (int)aOldalRajzolashoz;
            int By = startY;

            int height = (int)Math.Min(bOldalRajzolashoz, cOldalRajzolashoz);
            int Cx = startX + (int)(aOldalRajzolashoz / 2);
            int Cy = startY + height;

            for (int x = Ax; x <= Bx; x++)
            {
                Console.SetCursorPosition(x, Ay);
                Console.Write(sign);
            }
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(Ax + i, Ay + i);
                Console.Write(sign);
            }
            for (int i = 0; i <= height; i++)
            {
                Console.SetCursorPosition(Bx - i, By + i);
                Console.Write(sign);
            }
        }

        // TODO (Dominik) : HianyzoAdatokSzamitasa
        private static void HianyzoAdatokSzamitasa(string aOldalMegadott, string bOldalMegadott, string cOldalMegadott, string alfaSzogMegadott, string betaSzogMegadott, string gammaSzogMegadott)
        {
            bool vanMegadvaAOldal = double.TryParse(aOldalMegadott, out double a);
            bool vanMegadvaBOldal = double.TryParse(bOldalMegadott, out double b);
            bool vanMegadvaCOldal = double.TryParse(cOldalMegadott, out double c);

            bool vanMegadvaAlfaSzog = double.TryParse(alfaSzogMegadott, out double alfa);
            bool vanMegadvaBetaSzog = double.TryParse(betaSzogMegadott, out double beta);
            bool vanMegadvaGammaSzog = double.TryParse(gammaSzogMegadott, out double gamma);

            //if (alfaSzogMegadott != "90" || alfaSzogMegadott != "")
            //{
            //    throw new ArgumentException("Ez a számítás csak derékszögű háromszögre vonatkozik (γ/a/ß = 90°).");
            //}

            if (vanMegadvaAOldal && vanMegadvaBOldal && !vanMegadvaCOldal)
            {
                if (!vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                {
                    double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                    double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                    double cOldalKeresett = Math.Sqrt(atalakitottAOldalMegadott * atalakitottAOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                    double alfaSzogKeresett = 90;
                    double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / cOldalKeresett) * 180 / Math.PI;
                    double gammaSzogKeresett = Math.Asin(atalakitottBOldalMegadott / cOldalKeresett) * 180 / Math.PI;
                    char alfaJel = 'α';
                    char betaJel = 'β';
                    char gammaJel = 'γ';
                    Console.WriteLine("x-x Kiszámolt adatok! x-x");
                    Console.WriteLine($"c = {cOldalKeresett:F2}");
                    Console.WriteLine($"{alfaJel} = {alfaSzogKeresett}°");
                    Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                    Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                }
                else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                {
                    double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                    double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                    double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                    double cOldalKeresett = Math.Sqrt(atalakitottAOldalMegadott * atalakitottAOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                    double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / cOldalKeresett) * 180 / Math.PI;
                    double gammaSzogKeresett = Math.Asin(atalakitottBOldalMegadott / cOldalKeresett) * 180 / Math.PI;
                    char alfaJel = 'α';
                    char betaJel = 'β';
                    char gammaJel = 'γ';
                    Console.WriteLine("x-x Kiszámolt adatok! x-x");
                    Console.WriteLine($"c = {cOldalKeresett:F2}");
                    Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                    Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                    Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                }
                else if (!vanMegadvaAlfaSzog && vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                {
                    double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                    double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                    double alfaSzogKeresett = 90;
                    double cOldalKeresett = Math.Sqrt(atalakitottAOldalMegadott * atalakitottAOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                    double gammaSzogKeresett = Math.Asin(atalakitottBOldalMegadott / cOldalKeresett) * 180 / Math.PI;
                    char alfaJel = 'α';
                    char betaJel = 'β';
                    char gammaJel = 'γ';
                    Console.WriteLine("x-x Kiszámolt adatok! x-x");
                    Console.WriteLine($"c = {cOldalKeresett:F2}");
                    Console.WriteLine($"{alfaJel} = {alfaSzogKeresett}°");
                    Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                }
                else if (!vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                {
                    double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                    double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                    double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                    double cOldalKeresett = Math.Sqrt(atalakitottAOldalMegadott * atalakitottAOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                    double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / cOldalKeresett) * 180 / Math.PI;
                    char alfaJel = 'α';
                    char betaJel = 'β';
                    char gammaJel = 'γ';
                    Console.WriteLine("x-x Kiszámolt adatok! x-x");
                    Console.WriteLine($"c = {cOldalKeresett:F2}");
                    Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                    Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                }
                else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                {
                    double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                    double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                    double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                    double cOldalKeresett = Math.Sqrt(atalakitottAOldalMegadott * atalakitottAOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                    double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / cOldalKeresett) * 180 / Math.PI;
                    char alfaJel = 'α';
                    char betaJel = 'β';
                    char gammaJel = 'γ';
                    Console.WriteLine("x-x Kiszámolt adatok! x-x");
                    Console.WriteLine($"c = {cOldalKeresett:F2}");
                    Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                    Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                }
                else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                {
                    double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                    double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                    double cOldalKeresett = Math.Sqrt(atalakitottAOldalMegadott * atalakitottAOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                    double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / cOldalKeresett) * 180 / Math.PI;
                    char alfaJel = 'α';
                    char betaJel = 'β';
                    char gammaJel = 'γ';
                    Console.WriteLine("x-x Kiszámolt adatok! x-x");
                    Console.WriteLine($"c = {cOldalKeresett:F2}");
                    Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                }
                else if (!vanMegadvaAlfaSzog && vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                {
                    double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                    double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                    double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                    double cOldalKeresett = Math.Sqrt(atalakitottAOldalMegadott * atalakitottAOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                    char alfaJel = 'α';
                    char betaJel = 'β';
                    char gammaJel = 'γ';
                    Console.WriteLine("x-x Kiszámolt adatok! x-x");
                    Console.WriteLine($"c = {cOldalKeresett:F2}");
                    Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                }
                else if (vanMegadvaAlfaSzog && vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                {
                    double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                    double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                    double cOldalKeresett = Math.Sqrt(atalakitottAOldalMegadott * atalakitottAOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                    Console.WriteLine("x-x Kiszámolt adatok! x-x");
                    Console.WriteLine($"c = {cOldalKeresett:F2}");
                }

                else if (vanMegadvaAOldal && vanMegadvaCOldal && !vanMegadvaBOldal)
                {
                    if (!vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double bOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottAOldalMegadott * atalakitottAOldalMegadott);
                        double alfaSzogKeresett = 90;
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        double gammaSzogKeresett = Math.Asin(bOldalKeresett / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"b = {bOldalKeresett:F2}");
                        Console.WriteLine($"{alfaJel} = {alfaSzogKeresett}°");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                        Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                    }
                    else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                        double bOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottAOldalMegadott * atalakitottAOldalMegadott);
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        double gammaSzogKeresett = Math.Asin(bOldalKeresett / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"b = {bOldalKeresett:F2}");
                        Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                        Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                    }
                    else if (!vanMegadvaAlfaSzog && vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double alfaSzogKeresett = 90;
                        double bOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottAOldalMegadott * atalakitottAOldalMegadott);
                        double gammaSzogKeresett = Math.Asin(bOldalKeresett / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"b = {bOldalKeresett:F2}");
                        Console.WriteLine($"{alfaJel} = {alfaSzogKeresett}°");
                        Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                    }
                    else if (!vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                        double bOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottAOldalMegadott * atalakitottAOldalMegadott);
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"b = {bOldalKeresett:F2}");
                        Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                    }
                    else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                        double bOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottAOldalMegadott * atalakitottAOldalMegadott);
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"b = {bOldalKeresett:F2}");
                        Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                    }
                    else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double bOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottAOldalMegadott * atalakitottAOldalMegadott);
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"b = {bOldalKeresett:F2}");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                    }
                    else if (!vanMegadvaAlfaSzog && vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                        double bOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottAOldalMegadott * atalakitottAOldalMegadott);
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"c = {bOldalKeresett:F2}");
                        Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                    }
                    else if (vanMegadvaAlfaSzog && vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double bOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottAOldalMegadott * atalakitottAOldalMegadott);
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"b = {bOldalKeresett:F2}");
                    }
                }

                else if (vanMegadvaBOldal && vanMegadvaCOldal && vanMegadvaAOldal)
                {
                    if (!vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double alfaSzogKeresett = 90;
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        double gammaSzogKeresett = Math.Asin(atalakitottBOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"{alfaJel} = {alfaSzogKeresett}°");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                        Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                    }
                    else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        double gammaSzogKeresett = Math.Asin(atalakitottBOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                        Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                    }
                    else if (!vanMegadvaAlfaSzog && vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double alfaSzogKeresett = 90;
                        double gammaSzogKeresett = Math.Asin(atalakitottBOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"{alfaJel} = {alfaSzogKeresett}°");
                        Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                    }
                    else if (!vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                    }
                    else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                    }
                    else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double betaSzogKeresett = Math.Asin(atalakitottAOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                    }
                    else if (!vanMegadvaAlfaSzog && vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                    {
                        double atalakitottAOldalMegadott = Convert.ToDouble(aOldalMegadott);
                        double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                        double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                        double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                        char alfaJel = 'α';
                        char betaJel = 'β';
                        char gammaJel = 'γ';
                        Console.WriteLine("x-x Kiszámolt adatok! x-x");
                        Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                    }

                    else if (vanMegadvaBOldal && vanMegadvaCOldal && !vanMegadvaAOldal)
                    {
                        if (!vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                        {
                            double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                            double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                            double aOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                            double alfaSzogKeresett = 90;
                            double betaSzogKeresett = Math.Asin(aOldalKeresett / atalakitottCOldalMegadott) * 180 / Math.PI;
                            double gammaSzogKeresett = Math.Asin(atalakitottBOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                            char alfaJel = 'α';
                            char betaJel = 'β';
                            char gammaJel = 'γ';
                            Console.WriteLine("x-x Kiszámolt adatok! x-x");
                            Console.WriteLine($"a = {aOldalKeresett:F2}");
                            Console.WriteLine($"{alfaJel} = {alfaSzogKeresett}°");
                            Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                            Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                        }
                        else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                        {
                            double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                            double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                            double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                            double aOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                            double betaSzogKeresett = Math.Asin(aOldalKeresett / atalakitottCOldalMegadott) * 180 / Math.PI;
                            double gammaSzogKeresett = Math.Asin(atalakitottBOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                            char alfaJel = 'α';
                            char betaJel = 'β';
                            char gammaJel = 'γ';
                            Console.WriteLine("x-x Kiszámolt adatok! x-x");
                            Console.WriteLine($"a = {aOldalKeresett:F2}");
                            Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                            Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                            Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                        }
                        else if (!vanMegadvaAlfaSzog && vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                        {
                            double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                            double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                            double alfaSzogKeresett = 90;
                            double aOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                            double gammaSzogKeresett = Math.Asin(atalakitottBOldalMegadott / atalakitottCOldalMegadott) * 180 / Math.PI;
                            char alfaJel = 'α';
                            char betaJel = 'β';
                            char gammaJel = 'γ';
                            Console.WriteLine("x-x Kiszámolt adatok! x-x");
                            Console.WriteLine($"a = {aOldalKeresett:F2}");
                            Console.WriteLine($"{alfaJel} = {alfaSzogKeresett}°");
                            Console.WriteLine($"{gammaJel} = {gammaSzogKeresett:F2}°");
                        }
                        else if (!vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                        {
                            double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                            double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                            double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                            double aOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                            double betaSzogKeresett = Math.Asin(aOldalKeresett / atalakitottCOldalMegadott) * 180 / Math.PI;
                            char alfaJel = 'α';
                            char betaJel = 'β';
                            char gammaJel = 'γ';
                            Console.WriteLine("x-x Kiszámolt adatok! x-x");
                            Console.WriteLine($"a = {aOldalKeresett:F2}");
                            Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                            Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                        }
                        else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                        {
                            double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                            double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                            double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                            double aOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                            double betaSzogKeresett = Math.Asin(aOldalKeresett / atalakitottCOldalMegadott) * 180 / Math.PI;
                            char alfaJel = 'α';
                            char betaJel = 'β';
                            char gammaJel = 'γ';
                            Console.WriteLine("x-x Kiszámolt adatok! x-x");
                            Console.WriteLine($"a = {aOldalKeresett:F2}");
                            Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                            Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                        }
                        else if (vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                        {
                            double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                            double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                            double aOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                            double betaSzogKeresett = Math.Asin(aOldalKeresett / atalakitottCOldalMegadott) * 180 / Math.PI;
                            char alfaJel = 'α';
                            char betaJel = 'β';
                            char gammaJel = 'γ';
                            Console.WriteLine("x-x Kiszámolt adatok! x-x");
                            Console.WriteLine($"b = {aOldalKeresett:F2}");
                            Console.WriteLine($"{betaJel} = {betaSzogKeresett:F2}°");
                        }
                        else if (!vanMegadvaAlfaSzog && vanMegadvaBetaSzog && vanMegadvaGammaSzog)
                        {
                            double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                            double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                            double atalakitottAlfaSzogMegadott = Convert.ToDouble(alfaSzogMegadott);
                            double aOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                            char alfaJel = 'α';
                            char betaJel = 'β';
                            char gammaJel = 'γ';
                            Console.WriteLine("x-x Kiszámolt adatok! x-x");
                            Console.WriteLine($"c = {aOldalKeresett:F2}");
                            Console.WriteLine($"{alfaJel} = {atalakitottAlfaSzogMegadott}°");
                        }
                        else if (!vanMegadvaAlfaSzog && !vanMegadvaBetaSzog && !vanMegadvaGammaSzog)
                        {
                            double atalakitottBOldalMegadott = Convert.ToDouble(bOldalMegadott);
                            double atalakitottCOldalMegadott = Convert.ToDouble(cOldalMegadott);
                            double aOldalKeresett = Math.Sqrt(atalakitottCOldalMegadott * atalakitottCOldalMegadott + atalakitottBOldalMegadott * atalakitottBOldalMegadott);
                            Console.WriteLine("x-x Kiszámolt adatok! x-x");
                            Console.WriteLine($"b = {aOldalKeresett:F2}");
                        }
                    }
                }

                else
                {
                    throw new ArgumentException("Nincs elegendő adat a számításhoz.");
                }
            }
        }

        // TODO (Dani) : SzerkeszhetoeHaromszog
        private static bool SzerkeszhetoeHaromszog(double aOldalSzerkeszthetoseghez, double bOldalSzerkeszthetoseghez, double cOldalSzerkeszthetoseghez)
        {
            string szerkeszthetoe = "";
            if (aOldalSzerkeszthetoseghez < bOldalSzerkeszthetoseghez + cOldalSzerkeszthetoseghez & bOldalSzerkeszthetoseghez < aOldalSzerkeszthetoseghez + cOldalSzerkeszthetoseghez & cOldalSzerkeszthetoseghez < aOldalSzerkeszthetoseghez + bOldalSzerkeszthetoseghez)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
