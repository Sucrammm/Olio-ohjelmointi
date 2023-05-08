using System;

abstract class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }

    public Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }
    public abstract string Nimi { get; }
}

class Nuoli : Tavara
{
    public Nuoli() : base(0.1, 0.05) { }

    public override string Nimi => "Nuoli";
}

class Jousi : Tavara
{
    public Jousi() : base(1, 4) { }

    public override string Nimi => "Jousi";

}

class Köysi : Tavara
{
    public Köysi() : base(1, 1.5) { }

    public override string Nimi => "Köysi";
}

class Vesi : Tavara
{
    public Vesi() : base(2, 2) { }

    public override string Nimi => "Vesi";
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1, 0.5) { }

    public override string Nimi => "Ruokaa";
}

class Miekka : Tavara
{
    public Miekka() : base(5, 3) { }

    public override string Nimi => "Miekka";
}

class Reppu
{
    public Tavara[] Tavarat { get; }
    public int MaksimiTavaroidenMaara { get; }
    public double MaksimiKantoPaino { get; }
    public double MaksimiTilavuus { get; }
    public int TavaroidenMaara { get; private set; }
    public double TavaroidenPaino { get; private set; }
    public double TavaroidenTilavuus { get; private set; }


    public Reppu(int maksimiTavaroidenMaara, double maksimiKantoPaino, double maksimiTilavuus)
    {
        MaksimiTavaroidenMaara = maksimiTavaroidenMaara;
        MaksimiKantoPaino = maksimiKantoPaino;
        MaksimiTilavuus = maksimiTilavuus;

        Tavarat = new Tavara[maksimiTavaroidenMaara];
    }

    public bool Lisää(Tavara tavara)
    {

        if (TavaroidenMaara >= MaksimiTavaroidenMaara ||
            TavaroidenPaino + tavara.Paino > MaksimiKantoPaino ||
            TavaroidenTilavuus + tavara.Tilavuus > MaksimiTilavuus)
        {
            return false;
        }

        Tavarat[TavaroidenMaara] = tavara;
        TavaroidenMaara++;
        TavaroidenPaino += tavara.Paino;
        TavaroidenTilavuus += tavara.Tilavuus;

        return true;
    }

    public override string ToString()
    {
        string sisalto = "Reppussa on seuraavat tavarat: ";
        for (int i = 0; i < TavaroidenMaara; i++)
        {
            sisalto += Tavarat[i].ToString();
            if (i < TavaroidenMaara - 1)
            {
                sisalto += ", ";
            }
        }
        return sisalto;
    }

    public static void Main()
    {
        Reppu reppu = new Reppu(10, 30, 20);

        Console.WriteLine("Tervetuloa reppupeliin! Lisää tavaroita reppuun valitsemalla numero:");
        Console.WriteLine("");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(reppu.ToString());

            Console.WriteLine($"Repussa on tällä hetkllä {reppu.TavaroidenMaara}/10 tavaraa, {reppu.TavaroidenPaino}/30 painoa ja {reppu.TavaroidenTilavuus}/20 tilavuus.");
            Console.WriteLine("");

            Console.WriteLine("Mitä haluat lisätä?");
            Console.WriteLine("1 - Nuoli");
            Console.WriteLine("2 - Jousi");
            Console.WriteLine("3 - Köysi");
            Console.WriteLine("4 - Vettä");
            Console.WriteLine("5 - Ruokaa");
            Console.WriteLine("6 - Miekka");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    reppu.Lisää(new Nuoli());
                    Console.WriteLine("Nuoli lisätty reppuun.");
                    Console.WriteLine("");
                    break;
                case "2":
                    reppu.Lisää(new Jousi());
                    Console.WriteLine("Jousi lisätty reppuun.");
                    Console.WriteLine("");
                    break;
                case "3":
                    reppu.Lisää(new Köysi());
                    Console.WriteLine("Köysi lisätty reppuun.");
                    Console.WriteLine("");
                    break;
                case "4":
                    reppu.Lisää(new Vesi());
                    Console.WriteLine("Vesi lisätty reppuun.");
                    Console.WriteLine("");
                    break;
                case "5":
                    reppu.Lisää(new RuokaAnnos());
                    Console.WriteLine("Ruokaa lisätty reppuun.");
                    Console.WriteLine("");
                    break;
                case "6":
                    reppu.Lisää(new Miekka());
                    Console.WriteLine("Miekka lisätty reppuun.");
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Virheellinen valinta!");
                    Console.WriteLine("");
                    break;
            }
        }

    }
}