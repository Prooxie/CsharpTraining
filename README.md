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





