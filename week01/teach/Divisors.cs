using System;
using System.Collections.Generic;

public static class Divisors
{
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // Expected: <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // Expected: <List>{1}
    }

    // 🚀 Implementation for Problem 1
    
    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) {
        List<int> results = new();
        
        // Use a for loop to check numbers from 1 up to (but not including) 'number'.
        for (int i = 1; i < number; i++)
        {
            // Use an if statement and the modulo operator (%) to test divisibility.
            // If the remainder of the division is 0, 'i' is a divisor.
            if (number % i == 0)
            {
                // Call Add() to append the divisor to the list.
                results.Add(i);
            }
        }
        
        return results;
    }
}