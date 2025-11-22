using System;
using System.Collections.Generic;

public class LQueue<T>
{
    /// storage for queue
    private List<T> _data;

    /// gives a starting capacity 
    private const int DefaultCapacity = 4;

    /// constructs queue and list
    public LQueue()
    {
        _data = new List<T>(DefaultCapacity);
    }

    /// Properties Requirement 

    /// will return the current number of things in the queue (aka size)
    public int Size
    {
        get { return _data.Count; }
    }

    /// will return how much space is left, how many more elements can be stored 
    public int Capacity
    {
        get { return _data.Capacity; }
    }


    /// Methods Requirement (enqueue, dequeue, peek, contains)

    /// enqueue will add the value it is given to the back of the queue
    public void Enqueue(T n)
    {
        _data.Add(n);
    }

    /// dequeue will determine the front element, remove it, and return it 
    public T Dequeue()
    {
        if (Size == 0)
        {
            throw new InvalidOperationException("Queue is empty: Cannot Dequeue.");
        }
        
        T frontElement = _data[0];
        
        _data.RemoveAt(0);

        return frontElement;
    }

    /// peek will return whatever value is at the front of the queue 
    public T Peek()
    {
        if (Size == 0)
        {
            throw new InvalidOperationException("Queue is empty: Cannot Peek.");
        }
        
        return _data[0];
    }

    /// contains will look for a specific value in the queue, and will return true if it is found
    public bool Contains(T n)
    {
        return _data.Contains(n);
    }
}