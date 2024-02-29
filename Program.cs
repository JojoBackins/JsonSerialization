using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
class Program
{
    static void Main(string[] args)
    {
        var guys = new List<Guy>()
        {
            new Guy()
            {
                Name = "Bob",
                Clothes = new Outfit() { Top = "t-shirt", Bottom = "jeans" },
                Hair = new HairStyle() { Color = HairColor.Red, Lenght = 3.5f }
            },
            new Guy() {Name = "Joe", Clothes = new Outfit() {Top = "polo", Bottom = "slacks"},
                Hair = new HairStyle() {Color = HairColor.Gray, Lenght = 2.7f }
            },
        };
        //var jsonString = JsonSerializer.Serialize(guys);
        //Console.WriteLine(jsonString);

        var options = new JsonSerializerOptions() { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(guys, options);
        Console.WriteLine(jsonString);

        var copyOfGuys = JsonSerializer.Deserialize<List<Guy>>(jsonString);
        foreach (var guy in copyOfGuys)
            Console.WriteLine("I deserialized this guy: {0}", guy);

        var dudes = JsonSerializer.Deserialize<Stack<Dude>>(jsonString);
        while (dudes.Count > 0)
        {
            var dude = dudes.Pop();
            Console.WriteLine($"Next dude: {dude.Name} with {dude.Hair} hair");
        }

        Console.WriteLine(JsonSerializer.Serialize(3));
        Console.WriteLine(JsonSerializer.Serialize((long)-3));
        Console.WriteLine(JsonSerializer.Serialize((byte)0));
        Console.WriteLine(JsonSerializer.Serialize(float.MaxValue));
        Console.WriteLine(JsonSerializer.Serialize(float.MinValue));
        Console.WriteLine(JsonSerializer.Serialize(true));
        Console.WriteLine(JsonSerializer.Serialize("Elephant"));
        Console.WriteLine(JsonSerializer.Serialize("Elephant".ToCharArray()));
        Console.WriteLine(JsonSerializer.Serialize("🐘"));

    }
}
class Guy
{
    public string Name { get; set; }
    public HairStyle Hair { get; set; }
    public Outfit Clothes { get; set; }
    public override string ToString() => $"{Name} with {Hair} wearing {Clothes}";
}
enum HairColor
{
    Auburn, Black, Blonde, Blue, Brown, Gray, Platinum, Purple, Red, White
}
class HairStyle
{
    public HairColor Color { get; set; }
    public float Lenght { get; set; }
    public override string ToString() => $"{Lenght:0.0} inch {Color} hair";
}
class Outfit
{
    public string Top { get; set; }
    public string Bottom { get; set; }
    public override string ToString() => $"{Top} and {Bottom}";
}
class Dude
{
    public string Name { get; set; }
    public HairStyle Hair { get; set; }

}
