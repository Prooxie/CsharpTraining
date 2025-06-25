// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Model;

static string ReturnDay(int DayofTheWeek)
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

int[] value = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

int[] numbers = value;

string[] substrings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

string[] words = substrings;

// 1. Najdi všechna čísla menší než 5
Console.WriteLine($" {string.Join(", ", numbers.Where(n => n < 5))}");
// 2. Najdi všechna sudá čísla
Console.WriteLine($" {string.Join(", ", numbers.Where(n => n % 2 == 0))}");
// 3. Seřaď čísla vzestupně
Console.WriteLine($" {string.Join(", ", numbers.OrderBy(n => n))}");
// 4. Najdi slova kratší než 4 znaky
Console.WriteLine($" {string.Join(", ", words.Where(w => w.Length < 4))}");
// 5. Vezmi prvních 5 čísel
Console.WriteLine($" {string.Join(", ", numbers.Take(5))}");
// 6. Přeskoč první 3 čísla a vezmi zbytek
Console.WriteLine($" {string.Join(", ", numbers.Skip(3))}");
// 7. Součet znaků začínající na "f"
Console.WriteLine($" {string.Join(", ", words.Where(w => w.StartsWith("f")).Select(w => w.Length).Sum())}");
// 8. Existuje slovo delší nez 6 znaků
Console.WriteLine($" {string.Join(", ", words.Any(w => w.Length > 6))}");
// 9. Návratová hodnota Tuple - Kombinace uppercase a lowercase
var tupleTask = words.Select(w => (w.ToUpper(), Upper: w.ToLower()));

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
    Console.WriteLine($"Name: {string.Join(", ", city_people.Names)}");
    Console.WriteLine();

}
        ;

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


var newPeople = JsonDataset
    .LoadData(@"d:\Documents\data2024.json");

var db = new PeopleDbContext();

var personCount = db.Persons.Count();

if (personCount == 0)
{
    db.Persons.AddRange(newPeople);

    var changed = db.SaveChanges();


    Console.WriteLine($"Change in db: {changed}");
}
else
{
    Console.WriteLine($"Incorrect, all values saved already");
}


// 1. města a kolik v každěm městě osob a vypište do konzole
// řešení bez vazby
//var cities = db.Addresses.GroupBy(x => x.City);

// řešení s vazbou
//var cities = db.Persons
//    .Include(x => x.Address)
//    .Where(x => x.Address != null)
//    .GroupBy(x => x.Address.City);

// 2. upravte na pouze 20 nejčastěších měst
var cities = db.Persons
    .Include(x => x.Address)
    .Where(x => x.Address != null)
    .GroupBy(x => x.Address.City)
    .ToList()
    .OrderByDescending(g => g.Count())
    .Take(20)
    ;

foreach (var city in cities)
{
    Console.WriteLine($"město: {city.Key}, počet lidí: {city.Count()}");
}

//3. kolik je v systému smluv (Contracts)

int contractsCount = db.Contracts.Count();
Console.WriteLine($"Počet smluv: {contractsCount}");

Console.WriteLine($"Starting...");

Console.WriteLine($"Please enter an ID of a person.");
string line = Console.ReadLine();

int id = 0;

try
{
    id = int.Parse(line);
}
catch (Exception ex)
{
    Console.WriteLine("Failed to convert ID to a number.");
}

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7257");

var homeText = await client.GetStringAsync("/");

while (true)
{
    Console.Write("Input Person ID: ");
    var Input = Console.ReadLine(); // get input from user

    if ( (Input == "Q") || (Input == "q") )
        break;

    try
    {
        id = int.Parse(Input); // parse user input (string) to integer
    }
    catch (Exception)
    {

        Console.WriteLine("Wrong input!");
        continue;
    }

    var person = await client.GetFromJsonAsync<Person>($"/person/{id}");
    Console.WriteLine($"Person with ID {id}: {person.FirstName} {person.LastName}");
}