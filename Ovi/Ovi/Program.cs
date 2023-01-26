public class Ovi
{
    public static void Main()
    {
        ovi a = ovi.auki;

        while (true)
        {
            Console.Write("Ovi on " + a + ". ");
            Console.Write("Mitä haluat tehdä? ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            string vastaus = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (a == ovi.auki)
            {
                if (vastaus == "sulje")
                {
                    a = (ovi)1;
                }
                else if (vastaus == "lukitse")
                {
                    Console.WriteLine("Ovi on vielä auki");
                }
                else if (vastaus == "avaa")
                {
                    Console.WriteLine("Ovi on jo auki");
                }
                else if (vastaus == "avaa lukko")
                {
                    Console.WriteLine("Ovi on vielä auki");
                }
            }

            else if (a == ovi.kiinni)
            {
                if (vastaus == "sulje")
                {
                    Console.WriteLine("Ovi on jo kiinni");
                }
                else if (vastaus == "lukitse")
                {
                    a = (ovi)2;
                }
                else if (vastaus == "avaa")
                {
                    a = (ovi)0;
                }
                else if (vastaus == "avaa lukko")
                {
                    Console.WriteLine("Ovi ei ole lukossa");
                }
            }

            else if (a == ovi.lukossa)
            {
                if (vastaus == "sulje")
                {
                    Console.WriteLine("Ovi on lukossa");
                }
                else if (vastaus == "lukitse")
                {
                    Console.WriteLine("Ovi on jo lukossa");
                }
                else if (vastaus == "avaa")
                {
                    Console.WriteLine("Ovi on vielä lukossa");
                }
                else if (vastaus == "avaa lukko")
                {
                    a = (ovi)1;
                }
            }
        }
    }
    enum ovi { auki, kiinni, lukossa }
}