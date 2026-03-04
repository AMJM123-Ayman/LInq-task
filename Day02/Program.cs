using System;
using System.Linq;
using System.IO;

namespace Day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var products = ListGenerators.ProductsList;
            var customers = ListGenerators.CustomersList;
            var dictionary_english = File.Exists("dictionary_english.txt") ? File.ReadAllLines("dictionary_english.txt") : new string[0];

            /*LINQ – Restriction Operators*/
            #region Find all products that are out of stock
            var outOfStockProducts = products.Where(p => p.UnitsInStock == 0);
            #endregion

            #region  Find all products that are in stock and cost more than 3.00 per unit
            var expensiveInStockProducts = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);
            #endregion

            #region  Returns digits whose name is shorter than their value
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortNamedDigits = digits.Where((d, i) => d.Length < i);
            #endregion

            /*LINQ – Element Operators*/
            #region  Get first product out of stock
            var firstOutOfStock = products.First(p => p.UnitsInStock == 0);
            #endregion

            #region  Return the first product whose Price > 1000, or null if not found
            var expensiveProduct = products.FirstOrDefault(p => p.UnitPrice > 1000);
            #endregion

            #region  Retrieve the second number greater than 5
            int[] arr1 = { 1, 5, 3, 8, 6, 7, 2, 10 };
            var secondNumberGreaterThan5 = arr1.Where(n => n > 5).Skip(1).First();
            #endregion

            /* LINQ – Aggregate Operators*/
            #region  Count the number of odd numbers in the array
            int[] arr2 = { 1, 4, 3, 9, 8, 6, 7, 2, 0 };
            var oddCount = arr2.Count(n => n % 2 != 0);
            #endregion

            #region  Return a list of customers and how many orders each has
            var customersOrdersCount = customers.Select(c => new
            {
                c.CustomerName,
                OrdersCount = c.Orders.Count()
            });
            #endregion

            #region  Return a list of categories and how many products each has
            var categoriesProductsCount = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                ProductsCount = g.Count()
            });
            #endregion

            #region  Get the total of the numbers in an array
            var total = arr2.Sum();
            #endregion

            #region Get the total number of characters of all words in dictionary_english.txt
            var totalCharacters = dictionary_english.Sum(w => w.Length);
            #endregion

            #region Get the total units in stock for each product category
            var unitsPerCategory = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                TotalUnits = g.Sum(p => p.UnitsInStock)
            });
            #endregion

            #region  Get the length of the shortest word in dictionary_english.txt
            var shortestWordLength = dictionary_english.Min(w => w.Length);
            #endregion

            #region Get the cheapest price among each category's products
            var cheapestPricePerCategory = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                CheapestPrice = g.Min(p => p.UnitPrice)
            });
            #endregion

            #region Get the products with the cheapest price in each category
            var cheapestProducts = products.GroupBy(p => p.Category).SelectMany(g =>
            {
                var minPrice = g.Min(p => p.UnitPrice);
                return g.Where(p => p.UnitPrice == minPrice);
            });
            #endregion

            #region  Get the length of the longest word in dictionary_english.txt
            var longestWordLength = dictionary_english.Max(w => w.Length);
            #endregion

            #region  Get the most expensive price among each category's products
            var mostExpensivePricePerCategory = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                MaxPrice = g.Max(p => p.UnitPrice)
            });
            #endregion

            #region Get the products with the most expensive price in each category
            var mostExpensiveProducts = products.GroupBy(p => p.Category).SelectMany(g =>
            {
                var maxPrice = g.Max(p => p.UnitPrice);
                return g.Where(p => p.UnitPrice == maxPrice);
            });
            #endregion

            #region  Get the average length of the words in dictionary_english.txt
            var averageWordLength = dictionary_english.Average(w => w.Length);
            #endregion

            #region  Get the average price of each category's products
            var averagePricePerCategory = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                AveragePrice = g.Average(p => p.UnitPrice)
            });
            #endregion

            /* LINQ – Ordering Operators*/
            #region  Sort a list of products by name
            var productsByName = products.OrderBy(p => p.ProductName);
            #endregion

            #region  Case-insensitive sort of words in an array
            string[] wordsArr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords = wordsArr.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            #endregion

            #region Sort a list of products by units in stock (highest → lowest)
            var productsByStockDesc = products.OrderByDescending(p => p.UnitsInStock);
            #endregion

            #region Sort digits by length then alphabetically
            var sortedDigits = digits.OrderBy(d => d.Length).ThenBy(d => d);
            #endregion

            #region Sort first by word length then case-insensitive
            var sortedWords2 = wordsArr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            #endregion

            #region  Sort products by category, then by price (highest → lowest)
            var productsByCategoryAndPrice = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            #endregion

            #region  Sort words by length then case-insensitive descending
            var sortedWordsDesc = wordsArr.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            #endregion

            #region Create list of digits whose second letter is ‘i’ (reversed order)
            var digitsWithIReversed = digits.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
            #endregion

            /*LINQ – Transformation Operators*/
            #region Return a sequence of just the names of products
            var productNames = products.Select(p => p.ProductName);
            #endregion

            #region  Uppercase & lowercase versions of each word (Anonymous Type)
            var wordCases = wordsArr.Select(w => new
            {
                Upper = w.ToUpper(),
                Lower = w.ToLower()
            });
            #endregion

            #region  Product projection (rename UnitPrice → Price)
            var productProjection = products.Select(p => new
            {
                p.ProductID,
                p.ProductName,
                Price = p.UnitPrice,
                p.Category
            });
            #endregion

            #region  Determine if each int matches its position
            int[] nums = { 1, 5, 3, 8, 6, 7, 2, 10 };
            var positionMatch = nums.Select((num, index) => new
            {
                Number = num,
                InPlace = (num == index)
            });
            #endregion

            #region Return all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB
            int[] numbersA = { 1, 2, 3, 4, 5, 6 };
            int[] numbersB = { 7, 8, 9, 10, 11, 12 };

            var validPairs = from a in numbersA
                             from b in numbersB
                             where a < b
                             select new { A = a, B = b };
            #endregion

            #region Select all orders where the order total is less than $50.00
            var cheapOrders = customers.SelectMany(c => c.Orders).Where(o => o.Total < 50.00m);
            #endregion

            #region Select all orders where the order was made in 1998 or later
            var recentOrders = customers.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
            #endregion

            /*LINQ – Partitioning Operators*/
            #region Get the first 3 orders from customers in Washington
            var first3WAOrders = customers.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Take(3);
            #endregion

            #region Get all but the first 2 orders from customers in Washington
            var skip2WAOrders = customers.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Skip(2);
            #endregion

            #region Return elements starting from the beginning while a number is less than its position
            int[] partitionNumbers = { 5, 4, 1, 3, 8, 6, 7, 2, 0 };
            var takeWhileResult = partitionNumbers.TakeWhile((n, index) => n >= index);
            #endregion

            #region Get the elements of the array starting from the first element divisible by 3
            var skipWhileDiv3 = partitionNumbers.SkipWhile(n => n % 3 != 0);
            #endregion

            #region Get the elements of the array starting from the first element less than its position
            var skipWhileResult = partitionNumbers.SkipWhile((n, index) => n >= index);
            #endregion

            /*LINQ – Quantifiers*/
            #region Determine if any word in dictionary_english.txt contains substring "ei"
            bool containsEI = dictionary_english.Any(word => word.Contains("ei"));
            #endregion

            #region Return a grouped list of products by categories that have at least one product out of stock
            var categoryWithAnyOutOfStock = products.GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0))
                .Select(g => new
                {
                    Category = g.Key,
                    Products = g.ToList()
                });
            #endregion

            #region Return a grouped list of products only for categories that have all of their products in stock
            var categoryWithAllInStock = products.GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0))
                .Select(g => new
                {
                    Category = g.Key,
                    Products = g.ToList()
                });
            #endregion
        }
    }
}