public class Pokemon
{
    public String Nombre;
    public String Tipo;
}

public class Program
{
    public static void Main(string[] args)
    {
        var poke = new Pokemon();
        Pokemon pok2 = poke;
        pok2.Nombre = "Blaziken";
        pok2.Tipo = "Fuego";
        Console.WriteLine("Nombre: " + pok2.Nombre);
        Console.WriteLine("Tipo Pokemon: " + pok2.Tipo);
    }
}
