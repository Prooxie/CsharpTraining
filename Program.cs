// See https://aka.ms/new-console-template for more information
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
Console.WriteLine($" {String.Join(", ", numbers.Where(c => c < 5))}");
// 2. Najdi všechna sudá čísla
Console.WriteLine($" {String.Join(", ", numbers.Where(c => c % 2 == 0))}");
// 3. Seřaď čísla vzestupně
Console.WriteLine($" {String.Join(", ", numbers.OrderBy(c => c))}");
// 4. Najdi slova kratší než 4 znaky
Console.WriteLine($" {String.Join(", ", words.Where(s => s.Length < 4))}");
// 5. Vezmi prvních 5 čísel
Console.WriteLine($" {String.Join(", ", numbers.Take(5))}");
// 6. Přeskoč první 3 čísla a vezmi zbytek
Console.WriteLine($" {String.Join(", ", numbers.Skip(3))}");
