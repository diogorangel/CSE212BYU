using System;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // Expected: <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    /// <summary>
    /// Combines two arrays into a new array based on the selector array.
    /// A 1 in select means select the next item from list1; a 2 means select from list2.
    /// </summary>
    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // 1. Initialize the result array with the length of the selector array.
        int[] resultArray = new int[select.Length];

        // 2. Initialize index pointers for the source arrays.
        int list1Index = 0;
        int list2Index = 0;

        // 3. Loop through the selector array.
        for (int i = 0; i < select.Length; i++)
        {
            int selection = select[i];

            if (selection == 1)
            {
                // Select from list1, put it in the result, and advance the list1 pointer.
                resultArray[i] = list1[list1Index];
                list1Index++;
            }
            else if (selection == 2)
            {
                // Select from list2, put it in the result, and advance the list2 pointer.
                resultArray[i] = list2[list2Index];
                list2Index++;
            }
            // (Assumes selector only contains 1s and 2s as per the problem description)
        }

        return resultArray;
    }
}