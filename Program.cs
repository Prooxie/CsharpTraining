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
//var tupleTask = words.
//Select(static w => w.(Upper: w.ToUpper, Lower: w.ToLower()));

//foreach (var tuple in tupleTask)
//Console.WriteLine($"Lowercase: {tupleTask.Lower}, Uppercase: {tupleTask.Upper} ");

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
    Console.WriteLine($"Name: { city_people.Names}");
    Console.WriteLine();

};




