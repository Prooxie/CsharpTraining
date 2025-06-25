Každý rok nová verze, používat nejnovější.

CTRL + Q - Code Search
C + W + Dvakrát tab = System.WriteLine

Switche jsou propádavající

Switch expression in modern C#

string dayName = DateTime.Now.DayOfWeek switch
	DayOfWeek.Monday => "Start of work week",
	DayOfWeek.Friday => "End of work week",
	DayOfWeek.Saturday or DayOfWeek.Sunday => "Weekend!",
	_ => 'Regular work day'

_ = Default.


Switch int N when N > 0

Object data = "Hi"

string[] fruits = { "Apple", "Pear", "Banana" };


forEach (var fruit in fruits)


Nullabe data types

int?
double?
bool?

!xxx.hasValue

int actualValue = nullabeInt ?? 112 // pokud je to null, vráti druhou hodnotu jako default

int a = 10;
int x += 50;

nullableInt ??= 10; // pouze pokud je null


var length = nullablename?.Lenth // Null-conditional operator ? - není třeba se ptát všech tříd, jestli jsou null.
if length = null;

Switch podporuje string.


Internal = v rámci našeho projektu

Statická metoda potřebu mít prefix Static

Return je poslední volání metody

Enum DenVTydnu
{ 
	[Description("Pondělí")]
}

Tuple Například: (Double, Int) -- Jako struktura ale jen dočasná
Structure - Records
Record = immutable - datové objekty


static DenVTydnu GetDayOfWeekInfo(int dayNumber)
{
	var den = GetDayOfWeek_SwitchExpression(dayNumber);
	var jeViken = dayNumber == 6 ||
}

public override string ToString()
	=> $"Car {ID} RegNum: {RegistrationNumber} Brand:{Brand}";

public string Brand { get; } = "Skoda" // Vyhnout se NULLu

Public bool ChangeRegNumber(string newRegNumber)
{
	RegistrationNumber = newRegNumber;
}


Class má kromě property i třídy

private int id;

Csharp je samozřejmě case-sensitive

Property, Metody, Třidy =CamelCase
fieldy, instance, proměnné = malý písmena, _ před readonly


custom setter

public string RegistrationNumber
{

	get
		{
 			return _regNumber;
		}

	set 
		{
			if (value.Length > 9) 
			{
				Console.WriteLine("Error - Registration too long");
			}

			_regNumber = value.SubString(0,9);
		}
}





IMPORTANT - LINQ - Language integrated query


var result = numbers.Where(cislo => cislo > 5);

foreach var item i nresult

var sortedNames = names.OrberBy (n => n);
Console.WriteLine($"OrderBy: {string.Join(", ", sortedNames)}");

var descNumbers = names.OrberBy (n => n);
Console.WriteLine($"OrderByDescending: {string.Join(", ", descNumbers)}");

Console.WriteLine($"Average: {numbers.Average()}");

Console.WriteLine($"Min: {{numbers.Min()}, Max: {numbers.Max()}");

Union - sjednocení - String.Join(", ", set1.Union(set2))}:);

Intersekt - Průnik - String.Join(", ", set1.Intesect(set2))}:);

Except - Rozdíl - String.Join(", ", set1.Except(set2))}:);

var rs = numbers.Take(3); - Vezme první tři


numbers.Skip(3).Take(3); - Přeskočí první tři, Vezme další tři

numbers.TakeWhile(n => n < 5) - Vezme dokud podmínka

numbers.SkipWhile(n => n < 5) - Přeskočí dokud podmínka

var quotation = numbers.Select(n => n * n); -- projede, ztransformuje a ve vysledech bude ve výsledné kolekci

Select - Výběr - String.Join(", ", quotation)}:);

Any, All, 
names.Contains("JMÉNO") - vrací boolean

.ToLower() 
.ToUpper()


names.Select(x => x.ToLower()).Contains("anna");

names.Order(x => x).First();

DAY 2

Dědičná třída dědí pouze z jedné třídy ale Tlist může z několika najednou. 

iEnumerable

iEnumerator

Vyhledávat si třídy (interface) protože jejich stránka narozdíl od Delphi nemá popis jedním řádkem.

Interface Dictionary, GUI, stack

public ICollection<T>

Dictionary<Tkey, TValue> - Také se jí říká hashmap. Může to být definovaný jakymkoliv typem, ale ten typ musí existovat v době volání.
Předpokládá se, že se k ním nebude volat pararelné (skrz více než 1 thread)

CurrentQE

var a = int.Parse("15");


var d1 = new Datetime(2025, 05, 01);

var d2 = new Datetime(2025, 03, 11);

TimeSpan ts xx =  d1 - d2;

var t = TimeSpan.FromMinutes(1200);


File.ReadAllLines("file.ext");
File.WriteAllLines


var combinedPath = Path.Combine("home", "user", "subdir", "soubor.txt"); -- DŮLEŽÍTÉ! Pro cestu mezi OS

File.ReadAllLines("file.ext");

Zkopírovat JSON - Visual studio, Upravit, Vložit jinak, Vložit JSON z klipbordu -- DŮLEŽÍTÉ, AUTOMATICKÝ ROZEZNÁ TŘÍDY A ČLENY.

CTRL + Tečka nebo refactoring

Refactor umí několik věcí, například přejmenovat soubor, pokud se přejmenuje třída.

Je možné přidat reference v dependencies mezi projekty atd.

Třida Json může dělat např. serializaci

Entity framework (EF)

O/RM - Object-relational mapper.

Code first / Database first (dva postupy)

Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate - Při code first vytvoří databázi podle kódu
Update-Database

Immediate window uprostřed breakpointingu pro změnu za běhu
