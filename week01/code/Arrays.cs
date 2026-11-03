public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // 1. Create an array of doubles with size as 'length'. These are the results.
        // 2. A for loop with an index 'i' to iterate from 0 upto but not including 'length'.
        // 3. With each pass, the multiple at 'i' is equal to 'number' multiplied by (i + 1). This is because the first multiple is 1 * number, the second is 2 * number etc.
        // 4. Store the value in the array at index 'i'
        // 5. Return the array of doubles to close the function

        var result = new double[length]; // Step 1
        for (var i = 0; i < length; i++) // Step 2
        {
            result[i] = number * (i + 1);  //Step 3 & 4
        }
        return result; // Step 5
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // 1. Need to move the last 'amount' elements of the list and place them at the front of the list. This can be done by using the GetRange method to get the last 'amount' elements and then using InsertRange to insert them at the front of the list.
        // 2. Find the index where those items started in the original list. This is equal to data.Count - amount.
        // 3. Use Getrange to copy these last items into a separate list 
        // 4. Use RemoveRange to delete those elements from the end of the original list.
        // 5. Use InsertRange to insert he copied elements at the front of the original list.

        var splitIndex = data.Count - amount; //Step 2
        var lastItems = data.GetRange(splitIndex, amount); //Step 3
        data.RemoveRange(splitIndex, amount); //Step 4
        data.InsertRange(0, lastItems); //Step 5
    }
}
