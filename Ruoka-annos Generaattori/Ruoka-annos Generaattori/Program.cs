public class RuokaAnnos
{
    public static void Main()
    {
        (pää a, lisuke b, kastike c) vastaus;

        pää pääRaakaAine = pää.nautaa;
        lisuke lisu = lisuke.perunaa;
        kastike kasti = kastike.curry;

        Console.Write($"Pääraaka-aine (" + pää.nautaa + ", " + pää.kanaa + ", " + pää.kasviksia + "): ");

        Console.ForegroundColor = ConsoleColor.Cyan;
        string pääruoka = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

        if (pääruoka == "nautaa")   pääRaakaAine = pää.nautaa;
        if (pääruoka == "kanaa") pääRaakaAine = pää.kanaa;
        if (pääruoka == "kasviksia") pääRaakaAine = pää.kasviksia;

        Console.Write("Lisukkeet (" + lisuke.perunaa + ", " + lisuke.riisiä + ", " + lisuke.pastaa + "): ");

        Console.ForegroundColor = ConsoleColor.Cyan;
        string lisukeet = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

        if (lisukeet == "perunaa") lisu = lisuke.perunaa;
        if (lisukeet == "riisiä") lisu = lisuke.riisiä;
        if (lisukeet == "pastaa") lisu = lisuke.pastaa;

        Console.Write("Kastike (" + kastike.curry + ", " + kastike.hapanimelä + ", " + kastike.pippuri + ", " + kastike.curry + "): ");

        Console.ForegroundColor = ConsoleColor.Cyan;
        string kastikkeet = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

        if (kastikkeet == "curry") kasti = kastike.curry;
        if (kastikkeet == "hapanimelä") kasti = kastike.hapanimelä;
        if (kastikkeet == "pippuri") kasti = kastike.pippuri;
        if (kastikkeet == "chili") kasti = kastike.chili;

        vastaus = (pääRaakaAine, lisu, kasti);

        Console.WriteLine(vastaus.a + " ja " + vastaus.b +" "+ vastaus.c + "-kastikkella");
    }        
    enum pää { nautaa, kanaa, kasviksia }
    enum lisuke { perunaa, riisiä, pastaa }
    enum kastike { curry, hapanimelä, pippuri, chili }
}