using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Create a new double array called 'result' with the size specified by the input 'length'.
        // 2. Use a 'for' loop to iterate from index 0 up to (but not including) 'length'.
        // 3. Inside the loop, calculate the multiple. The multiple for the current index 'i' is 'number' multiplied by (i + 1).
        //    (Since the first multiple, 'number' itself, corresponds to i=0, we use i+1).
        // 4. Assign the calculated multiple to the 'result' array at the current index 'i'.
        // 5. After the loop completes, return the 'result' array.

        // IMPLEMENTATION:
        double[] result = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            // O múltiplo é o 'number' * (i + 1)
            result[i] = number * (i + 1);
        }

        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN (Using List Slicing methods: GetRange, RemoveRange, InsertRange):
        // 1. Determine the number of elements to move from the end to the beginning. This is equal to 'amount'.
        // 2. Calculate the starting index of the elements to be moved.
        //    'startIndex' = data.Count - amount.
        // 3. Use GetRange() to extract the elements that need to be moved to the front (the last 'amount' elements). Store this in a temporary list called 'elementsToMove'.
        //    'elementsToMove' = data.GetRange(startIndex, amount).
        // 4. Use RemoveRange() to remove these 'amount' elements from their original position at the end of the 'data' list.
        //    data.RemoveRange(startIndex, amount).
        // 5. Use InsertRange() to add the 'elementsToMove' list back into the 'data' list, starting at index 0 (the front).
        //    data.InsertRange(0, elementsToMove).

        // IMPLEMENTATION:
        int count = data.Count;
        
        // 1. Rotation by 'amount' is equivalent to moving the last 'amount' elements to the front.
        int startIndex = count - amount;

        // 2. Extract the elements to be moved (the last 'amount' elements).
        List<int> elementsToMove = data.GetRange(startIndex, amount);

        // 3. Remove the extracted elements from the original list.
        data.RemoveRange(startIndex, amount);

        // 4. Insert the moved elements at the beginning of the list.
        data.InsertRange(0, elementsToMove);
    }
}