using System.Collections.Generic;
using System.Linq;
using static System.Console;

var numbers = new List<int> { 1, 5, 2, 8, 9 };

var oddNumbers = numbers
    .Where(number => number % 2 != 0)
    .Select(number => number)
    .ToList();

numbers.Add(11);

foreach (var number in oddNumbers)
{
    WriteLine(number);
}