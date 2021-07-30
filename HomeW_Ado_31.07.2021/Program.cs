using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace HomeW_Ado_31._07._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new City[]
            {                
                new City{ Name = "Rivne", Country="Ukraine", Population = 250000, IsCapital = false },
                new City{ Name = "Warsaw", Country="Poland", Population = 1800000, IsCapital = true },
                new City{ Name = "Lviv", Country="Ukraine", Population = 720000, IsCapital = false },
                new City{ Name = "Krakow", Country="Poland", Population = 780000, IsCapital = false },
                new City{ Name = "Odessa", Country="Ukraine", Population = 1020000, IsCapital = false },
                new City{ Name = "London", Country="Great Britain", Population = 8900000, IsCapital = true },
                new City{ Name = "Paris", Country="France", Population = 2180000, IsCapital = true },
                new City{ Name = "Berlin", Country="Germany", Population = 3600000, IsCapital = true },
                new City{ Name = "Wroclaw", Country="Poland", Population = 640000, IsCapital = false },
                new City{ Name = "Kyiv", Country="Ukraine", Population = 3000000, IsCapital = true },
                new City{ Name = "Munich", Country="Germany", Population = 1480000, IsCapital = false },
                new City{ Name = "Dnipro", Country="Ukraine", Population = 980000, IsCapital = false },
                new City{ Name = "Cologne", Country="Germany", Population = 1000000, IsCapital = false }
            };
            var numbers = new[] { 2, 9, 47, 69, 20, -1, 13, -26, 37, -40, 18, 70, -31, 7, -47, -7, 1 };

            //Information about capitals
            Console.WriteLine("Information about capitals");
            var Capitals = cities.Where(x => x.IsCapital).Select(x => $"Name : {x.Name}  ,  country : {x.Country}  ,  population : {x.Population}");
            foreach (var item in Capitals)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nCities with 'i' in name");
            //Cities with "i" in name
            var CitiesWithI = cities.Where(x => x.Name.Contains('i')).Select(x=> $"Name : {x.Name}  ,  country : {x.Country}  ,  population : {x.Population} ");
            foreach (var item in CitiesWithI)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nNames of capitals with population in descending order");
            //Names of capitals with population in in descending order
            var SortedCapitals = cities.Where(x => x.IsCapital).OrderByDescending(x => x.Population ).Select(x => $"Name : {x.Name}  ,  country : {x.Country}  ,  population : {x.Population} ");
            foreach (var item in SortedCapitals)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nNames of countries what involves cities with last letter 'w' in name");
            //Names of countries what involves cities with last letter "w" in name
            var CountriesWithThisCities = cities.Where(x => x.Name.EndsWith("w")).Select(x => "Country : "+x.Country).Distinct();
            foreach (var item in CountriesWithThisCities)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nNames of cities where country's name and with 'e' and cities name start with 'a'\nПрограма нічого не виведе , бо у масиві , який даний у ДЗ не має міст які починаються на 'a'");
            //Names of cities where country's name rnd with "e" and cities name start with "a"
            //Програма нiчого не виведе , бо у масиві , який даний у ДЗ не має міст які починаються на "a"
            var CitiesStartWithA = cities.Where(x => x.Name.StartsWith("A") && x.Country.EndsWith("e")).Select(x => $"Name : {x.Name}  ,  country : {x.Country}  ,  population : {x.Population} ");
            foreach (var item in CitiesStartWithA)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nOdd numbers");
            //Odd numbers
            var OddNumbers = numbers.Where(x => x%2!=0);
            foreach (var item in OddNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nPositive numbers in sort order");
            //Positive numbers
            var PositiveNumbersInSortOrder = numbers.Where(x => x > 0).OrderBy(x => x);
            foreach (var item in PositiveNumbersInSortOrder)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nNegative numbers in descending order");
            //Negative numbers
            var NegativeNumbersInDescendingOrder = numbers.Where(x => x < 0).OrderByDescending(x => x);
            foreach (var item in NegativeNumbersInDescendingOrder)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nNumber of capitals");
            //Number of capitals
            int NumberOfcapitals = cities.Where(x => x.IsCapital).Count();
            Console.WriteLine("---- >" + NumberOfcapitals);
            Console.WriteLine("\n\nCountries names :\n");
            //Countries names
            var CountriesNames = cities.Select(x => x.Country).Distinct();
            foreach (var item in CountriesNames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nNumber of cities with population over than 1 000 000 ");
            //Number of cities with population over than 1 000 000
            int NumberOfCitiesWithPopulationOverAMillion = cities.Where(x => x.Population >= 1000000).Count();
            Console.WriteLine(NumberOfCitiesWithPopulationOverAMillion);
            Console.WriteLine("\n\nNames of countries which cities end with letter 'w' ");
            //Names of countries which cities end with letter 'w'
            var CountriesWhichCitiesEndWithW = cities.Where(x => x.Name.EndsWith("w")).Select(x => "Country : " + x.Country).Distinct();
            foreach (var item in CountriesWhichCitiesEndWithW)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\nPopulation of the least populated capital \n");
            //Population of the least populated capital 
            var PopulationOfTheLeasPopulatedCapital = cities.Where(x => x.IsCapital).Min(x => x.Population);
            Console.WriteLine(PopulationOfTheLeasPopulatedCapital);
            Console.WriteLine("\n\nNames of cities without first 4's and last 4's \n");
            //Names of cities without first 4's and last 4's 
            var NamesOfCitiesWithoutFirstAndLastFour = cities.Skip(4).Reverse().Skip(4).Reverse().Select(x => x.Name);
            foreach (var item in NamesOfCitiesWithoutFirstAndLastFour)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n\n\nMinimal , maximal and average values\n\n");
            //Minimal , maximal and average values
            var MinMaxAve = $"Min : {numbers.Min()}\t\tMax : {numbers.Max()}\t\tAverage : {numbers.Average()}";
            Console.WriteLine(MinMaxAve);
            Console.WriteLine("\n\nDoes mas contains value '-31' ");
            //Minimal , maximal and average values
            bool DoesItContains = numbers.Contains(-31);
            Console.WriteLine(DoesItContains);
            Console.WriteLine("\n\nThe last even value ");
            //The last even value
            int LastEvenValue = numbers.Where(x => x % 2 == 0).Last();
            Console.WriteLine(LastEvenValue);
        }
    }
}
