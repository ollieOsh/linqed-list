using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            var LFruits =
                        from fruit in fruits 
                        where fruit[0] ==  'L'
                        select fruit;
            Console.WriteLine("/nLFruits");
            foreach(var lFroot in LFruits)
            {
                    Console.WriteLine(lFroot);
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var fourSixMultiples = numbers.Where(num => num % 4 == 0 || num % 6 == 0);
            Console.WriteLine("\nfourSixMultiples");
            foreach(int digit in fourSixMultiples) {
                Console.WriteLine(digit);
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            var descend = names.OrderByDescending(c => c);
            Console.WriteLine("\nnames descending");
            foreach(var name in descend){
                Console.WriteLine(name);
            }

            // Build a collection of these numbers sorted in ascending order
            List<int> numbs = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var numAsc = numbs.OrderBy(a => a);
            Console.WriteLine("\nnumAsc");
            foreach(var num in numAsc){
                Console.WriteLine(num);
            }

            // Output how many numbers are in this list
            List<int> numCount = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            Console.WriteLine($"\nnumCount{numCount.Count}");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            Console.WriteLine($"\npurchase total {purchases.Sum()}");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            Console.WriteLine($"\nmax price {prices.Max()}");
        
            /*
            Store each number in the following List until a perfect square
            is detected.

            Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            var numSqr = wheresSquaredo.TakeWhile(n => n%Math.Sqrt(n) != 0);
            Console.WriteLine("\nstop at the square");
            foreach(var num in numSqr){
                Console.WriteLine(num);
            }

            // Build a collection of customers who are millionaires
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };
            
            var millionaires = customers.Where(cust => cust.Balance > 999999);
            Console.WriteLine("\nmillionaires");
            foreach(var milli in millionaires){
                Console.WriteLine($"{milli.Name} {milli.Bank}");
            }

            /* 
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */
            var bank = millionaires.GroupBy(mill => mill.Bank);
            Console.WriteLine("\nmillionares per bank");
            foreach(var milli in bank){
                Console.WriteLine($"{milli.Key} {milli.Count()}");
            }

            /*
                TASK:
                As in the previous exercise, you're going to output the millionaires,
                but you will also display the full name of the bank. You also need
                to sort the millionaires' names, ascending by their LAST name.

                Example output:
                    Tina Fey at Citibank
                    Joe Landy at Wells Fargo
                    Sarah Ng at First Tennessee
                    Les Paul at Wells Fargo
                    Peg Vale at Bank of America
            */

            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            var millionaireReport = 
                                    from bnk in banks
                                    join mll in millionaires on bnk.Symbol equals mll.Bank
                                    orderby mll.Name[mll.Name.IndexOf(" ") + 1]
                                    select new { mll.Name, Bank = bnk.Name };
            Console.WriteLine("\nmillionaire at bank");
            foreach (var customer in millionaireReport)
            {
                Console.WriteLine($"{customer.Name} at {customer.Bank}");
            }

        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }


}
