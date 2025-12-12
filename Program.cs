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
            menupontok.Add("Kilépés");
            ListazMenu(menupontok);
            bool futas = true;
            do
            {
                Console.SetCursorPosition(30, 0);
                Console.WriteLine("Mit szeretne csinálni?");
                byte inputUtasitas = Convert.ToByte(Console.ReadLine());
                ElvegzendoFeladat(inputUtasitas);
            } 
            while (futas);

            Console.WriteLine("Vége!");
        }

        private static void ListazMenu(List<string> menupontok)
        {
            //
            
            Console.Write("| " + menupontok[0] + " [1] | " + menupontok[1] + " [2] | " + menupontok[2] + " [3] | " + menupontok[3] + " [4] | " + menupontok[4] + " [5] |");

            throw new NotImplementedException("Még nincs kész, ezért ne használd!");
            Console.WriteLine("ide már jut el!");
        }

        private static void ElvegzendoFeladat(byte inputUtasitas)
        {
            switch (inputUtasitas)
            {
                case 1:
                    Console.WriteLine("Adja meg az A oldalt: ");
                    double aOldal = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Adja meg az B oldalt: ");
                    double bOldal = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Adja meg az C oldalt: ");
                    double cOldal = Convert.ToDouble(Console.ReadLine());
                    KeruletSzamitas(aOldal, bOldal, cOldal);
                    break;
                case 2:
                    Console.WriteLine("Adja meg háromszög magasságához tartozó oldalt: ");
                    double magasssagOldal = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Adja meg háromszög magasságához tartozó oldalt: ");
                    double magassag = Convert.ToDouble(Console.ReadLine());
                    TeruletSzamitas(magasssagOldal, magassag);
                    break;
                case 3:
                    Console.WriteLine("Adja meg az A oldalt: ");
                    string aOldalMegadott = Console.ReadLine();
                    Console.WriteLine("Adja meg az B oldalt: ");
                    string bOldalMegadott = Console.ReadLine();
                    Console.WriteLine("Adja meg az C oldalt: ");
                    string cOldalMegadott = Console.ReadLine();
                    Console.WriteLine("Adja meg az αlfa szöget: ");
                    string alfaSzogMegadott = Console.ReadLine();
                    Console.WriteLine("Adja meg a beta szöget: ");
                    string betaSzoglMegadott = Console.ReadLine();
                    Console.WriteLine("Adja meg a gamma szöget: ");
                    string gammaSzogMegadott = Console.ReadLine();

                    HianyzoAdatokSzamitas(aOldalMegadott, bOldalMegadott, cOldalMegadott, betaSzoglMegadott, gammaSzogMegadott);
                    break;
                case 4:

                    break;
                case 5:
                    bool futas = false;
                    break;
                default:
                    break;
            }
        }
        private static void UdvozloKep()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 0);
            Console.WriteLine("Üdvözlöm a háromszög szuper alkalmazásban!");


        }
    }
}
