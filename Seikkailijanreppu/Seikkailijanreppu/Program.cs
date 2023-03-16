using System;

class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }

    public Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }
}

class Nuoli : Tavara
{
    public Nuoli() : base(0.1, 0.05) { }
}

class Jousi : Tavara
{
    public Jousi() : base(1, 4) { }
}

class Köysi : Tavara
{
    public Köysi() : base(1, 1.5) { }
}

class Vesi : Tavara
{
    public Vesi() : base(2, 2) { }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1, 0.5) { }
}

class Miekka : Tavara
{
    public Miekka() : base(5, 3) { }
}

class Reppu
{
    public Tavara[] tavarat;
    private int maksimiTavaroidenMaara;
    private double maksimiKantoPaino;
    private double maksimiTilavuus;
    public int tavaroidenMaara;
    private double tavaroidenPaino;
    private double tavaroidenTilavuus;

    public Reppu(int maksimiTavaroidenMaara, double maksimiKantoPaino, double maksimiTilavuus)
    {
        this.maksimiTavaroidenMaara = maksimiTavaroidenMaara;
        this.maksimiKantoPaino = maksimiKantoPaino;
        this.maksimiTilavuus = maksimiTilavuus;

        tavarat = new Tavara[maksimiTavaroidenMaara];
    }

    public bool Lisää(Tavara tavara)
    {

        if (tavaroidenMaara >= maksimiTavaroidenMaara ||
            tavaroidenPaino + tavara.Paino > maksimiKantoPaino ||
            tavaroidenTilavuus + tavara.Tilavuus > maksimiTilavuus)
        {
            return false;
        }

        tavarat[tavaroidenMaara] = tavara;
        tavaroidenMaara++;
        tavaroidenPaino += tavara.Paino;
        tavaroidenTilavuus += tavara.Tilavuus;

        return true;
    }

    public static void Main()
    {   
        Reppu reppu = new Reppu(10, 30, 20);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Repussa on tällä hetkllä {reppu.tavaroidenMaara}/10 tavaraa, {reppu.tavaroidenPaino}/30 painoa ja {reppu.tavaroidenTilavuus}/20 tilavuus.");

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
                    break;
                case "2":
                    reppu.Lisää(new Jousi());
                    break;
                case "3":
                    reppu.Lisää(new Köysi());
                    break;
                case "4":
                    reppu.Lisää(new Vesi());
                    break;
                case "5":
                    reppu.Lisää(new RuokaAnnos());
                    break;
                case "6":
                    reppu.Lisää(new Miekka());
                    break;
                default:
                    Console.WriteLine("Virheellinen valinta!");
                    break;
            }
        }

    }
}