namespace prove_01;

public class Lists
{
    /// <summary>
    /// This function will produce a list of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //creates new array of doubles named 'result'
        double[] result = new double[length];
        //for creates a loop
        //we start at an index of 0, and the loop will continue as long as the length is more than the index (0), increasing by 1 ech loop
        for (var index = 0; index < length; ++index)
        {
            result[index] = number *  (index + 1);
        }    
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// <c>&lt;List&gt;{1, 2, 3, 4, 5, 6, 7, 8, 9}</c> and an amount is 3 then the list returned should be 
    /// <c>&lt;List&gt;{7, 8, 9, 1, 2, 3, 4, 5, 6}</c>.  The value of amount will be in the range of <c>1</c> and 
    /// <c>data.Count</c>.
    /// <br /><br />
    /// Because a list is dynamic, this function will modify the existing <c>data</c> list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        //to handle exceptions (null, empty, etc.)
        if (data == null || data.Count == 0 || amount <= 0)
        {
            return;
        }
        
        //calculates the amount to move to the front 
        int startIndex = data.Count - amount;
        
        //grabs part to go in the front
        List<int> frontPart = data.GetRange(startIndex, amount);
        
        //remove those elements from the og list 
        data.RemoveRange(startIndex, amount);
        
        //inserts the 'frontPart' into the beginning 
        data.InsertRange(0, frontPart);

    }
}
