// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

static String ReturnDay(int DayofTheWeek)
{
    switch (DayofTheWeek)
    {
        case 1: return "Monday";
        case 2: return "Tuesday";
        case 3: return "Wednesday";
        case 4: return "Thursday";
        case 5: return "Friday";
        case 6: return "Saturday";
        case 7: return "Sunday";
        default: return "Unknown";
    }
}

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// 1. Najdi všechna čísla menší než 5
Console.WriteLine($" {String.Join(", ", numbers.Where(n => n < 5))}");
// 2. Najdi všechna sudá čísla
Console.WriteLine($" {String.Join(", ", numbers.Where(n => n % 2 == 0))}");
// 3. Seřaď čísla vzestupně
Console.WriteLine($" {String.Join(", ", numbers.OrderBy(n => n))}");
// 4. Najdi slova kratší než 4 znaky
Console.WriteLine($" {String.Join(", ", words.Where(w => w.Length < 4))}");
// 5. Vezmi prvních 5 čísel
Console.WriteLine($" {String.Join(", ", numbers.Take(5))}");
// 6. Přeskoč první 3 čísla a vezmi zbytek
Console.WriteLine($" {String.Join(", ", numbers.Skip(3))}");
// 7. Součet znaků začínající na "f"
Console.WriteLine($" {String.Join(", ", words.Where(w => w.StartsWith("f")).Select(w => w.Length).Sum())}");
// 8. Existuje slovo delší nez 6 znaků
Console.WriteLine($" {String.Join(", ", words.Any(w => w.Length > 6))}");
// 9. Návratová hodnota Tuple - Kombinace uppercase a lowercase
var tupleTask = words.Select( w => ( w.ToUpper(), Upper: w.ToLower()));

foreach (var tuple in tupleTask)
Console.WriteLine($"Lowercase: {tuple.Item1}, Uppercase: {tuple.Upper} ");

var people = new[]
{
    new { Name = "Jan", City = "Praha", Age = 25},
    new { Name = "Jana", City = "Brno", Age = 21},
    new { Name = "Eva", City = "Olomouc", Age = 35},
    new { Name = "Tomáš", City = "Spořice", Age = 51},
    new { Name = "Marek", City = "Jirkov", Age = 52},
    new { Name = "Daniel", City = "Louny", Age = 20}
};

// 10. Věková kategorie (pod 30, 30 a více), kolik je ve skupině, jak se jmenují

var result = people.GroupBy(x => x.Age < 30 ? "Pod 30 let" : "30 a více")
      .Select(g => new
      {
          City = g.Key,
          Count = g.Count(),
          Names = g.Select(p => p.Name).ToList()
      });

foreach (var city_people in result)
{
    Console.WriteLine($"City: {city_people.City}");
    Console.WriteLine($"Count: {city_people.Count}");
    Console.WriteLine($"Name: { string.Join(", ", city_people.Names)}");
    Console.WriteLine();

};

var cars = new[]
{
    new { Brand = "Škoda", Model = "Octavia", Year = 2020, PricePerDay = 800, Available = true },
    new { Brand = "Škoda", Model = "Fabia", Year = 2021, PricePerDay = 600, Available = true },
    new { Brand = "VW", Model = "Golf", Year = 2019, PricePerDay = 900, Available = false },
    new { Brand = "VW", Model = "Passat", Year = 2020, PricePerDay = 1200, Available = true },
    new { Brand = "BMW", Model = "3 Series", Year = 2021, PricePerDay = 1500, Available = true },
    new { Brand = "BMW", Model = "X3", Year = 2020, PricePerDay = 2000, Available = false }
};

// 1. Počet aut podle značky

var carBrand = cars
      .GroupBy(x => x.Brand)
      .Select(g => new
      {
          Brand = g.Key,
          Count = g.Count(),
      });

foreach (var item in carBrand)
{
    Console.WriteLine($"Brand: {item.Brand}: {item.Count} ");
}
// 2. Dostupná auta seřazená podle ceny

var carAvailability = cars
    .Where(x => x.Available)
    .OrderBy(x => x.PricePerDay);

Console.WriteLine("\nDostupná auta podle ceny:");
foreach (var car in carAvailability)
{
    Console.WriteLine($"{car.Brand} {car.Model} - {car.PricePerDay} Kč");
}


// 3. Průměrná cena podle značky

var averagePrice = cars
    .GroupBy(x => x.Brand)
    .Select(g => new
    {
        Brand = g.Key,
        Price = g.Average(x => x.PricePerDay)
    });

Console.WriteLine("\nPrůměrná cena podle značky:");
foreach (var item in averagePrice)
{
    Console.WriteLine($"{item.Brand}: {item.Price} Kč");
}



