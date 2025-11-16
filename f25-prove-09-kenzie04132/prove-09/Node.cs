namespace prove_09;

public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        Data = data;
    }

    public void Insert(int value)
    {
        // stops duplicates bc if a value being added matches an of the current Data, it stops the insertion there
        if (value == Data)
        {
            return;
        }  
        
        if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value) 
    {
        // same as insert, stops duplicates
        if (value == Data)
        {
            return true;
        } 
        
        // search to left 
        else if (value < Data)
        {
            // if there is a value on the left, returns the value
            if (Left is not null)
            {
                return Left.Contains(value);
            }
            // returns false if there is no value on the left
            return false;
        }
        
        // search to right 
        else
        {
            // if there is a value on the right, returns the value
            if (Right is not null)
            {
                return Right.Contains(value);
            }
            // returns false if there is no value on the right
            return false;
        }
    }

    public int GetHeight() 
    {
        // if the left height is null, returns 0, else it recursively calls the function (calls itself)
        var leftHeight = Left?.GetHeight() ?? 0;
        
        // if the right height is null, returns 0, else it recursively calls the function (calls itself)
        var rightHeight = Right?.GetHeight() ?? 0;

        // calculates the height
        // height = 1 + the maximum of the left and right heights 
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}