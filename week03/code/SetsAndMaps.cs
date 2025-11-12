using System.Text.Json;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        var wordSet = new HashSet<string>(words);
        var symmetricPairs = new List<string>();

        foreach (var word in words)
        {
            // Reverse the word
            var reversedWord = $"{word[1]}{word[0]}";

            // Check if the reversed word is in the set
            if (word != reversedWord && wordSet.Contains(reversedWord))
            {
                // To avoid adding the pair twice (e.g., "ab&ba" and later "ba&ab"), 
                // we only add the pair where the original word comes first alphabetically.
                // FIX: Changed format to use '&' and remove quotes, matching test expectations.
                if (string.Compare(word, reversedWord) < 0)
                {
                    symmetricPairs.Add($"{word}&{reversedWord}");
                }
            }
        }
        return symmetricPairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        // Using a try-catch to be robust against missing file, as requested for Problem 2.
        try
        {
            foreach (var line in File.ReadLines(filename))
            {
                var fields = line.Split(",");
                // TODO Problem 2 - ADD YOUR CODE HERE
                // The degree is in the 4th column (index 3)
                if (fields.Length > 3)
                {
                    var degree = fields[3].Trim();
                    if (degrees.ContainsKey(degree))
                    {
                        degrees[degree] += 1;
                    }
                    else
                    {
                        degrees[degree] = 1;
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File not found at {filename}. Cannot summarize degrees.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // Normalize: remove spaces and convert to lowercase
        var cleanWord1 = word1.Replace(" ", "").ToLower();
        var cleanWord2 = word2.Replace(" ", "").ToLower();

        if (cleanWord1.Length != cleanWord2.Length)
        {
            return false;
        }

        // Use a dictionary to count letter frequencies
        var charCounts = new Dictionary<char, int>();

        // Count characters in word1
        foreach (var c in cleanWord1)
        {
            charCounts[c] = charCounts.GetValueOrDefault(c) + 1;
        }

        // Decrement counts for characters in word2
        foreach (var c in cleanWord2)
        {
            charCounts[c] = charCounts.GetValueOrDefault(c) - 1;
        }

        // Check if all counts are zero
        return charCounts.Values.All(count => count == 0);
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        
        // This problem requires System.Net.Http, System.IO, and System.Text.Json
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // Deserializes using the custom classes defined below.
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        var summary = new List<string>();
        if (featureCollection?.features != null)
        {
            foreach (var feature in featureCollection.features)
            {
                // Format: "place - Mag magnitude"
                summary.Add($"{feature.properties.place} - Mag {feature.properties.mag}");
            }
        }
        return summary.ToArray();
    }

    // --- Supporting Classes for Problem 5 JSON Deserialization ---
    public class FeatureCollection
    {
        public List<Feature> features { get; set; }
    }

    public class Feature
    {
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public double mag { get; set; }
        public string place { get; set; }
    }
}