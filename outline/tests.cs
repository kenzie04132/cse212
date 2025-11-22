using NUnit.Framework;
using System;
using System.Collections.Generic;

public class LQueueTests
{
    public void Enqueue_AddsElement_SizeIncrementsAndElementIsAtBack()
    {
        // arranges the queue
        LQueue<int> queue = new LQueue<int>();
        
        // enqueue is what we're testing, adds two elements (10 will be first, 20 behind it if working properly)
        queue.Enqueue(10);
        queue.Enqueue(20);

        // checks the size, should be 2, and checks that peek works and sees 10 at the front 
        Assert.AreEqual(2, queue.Size, "Size should be 2.");
        Assert.AreEqual(10, queue.Peek(), "10 should be at the front as it was the first enqueued element.");
    }
    
    public void Dequeue_RemovesElement_ReturnsFrontAndSizeDecrements()
    {
        // arranges the queue and adds a then b 
        LQueue<string> queue = new LQueue<string>();
        queue.Enqueue("A");
        queue.Enqueue("B");

        // dequeue is what wer're testing, dequeues the front value (which should be a)
        string actualValue = queue.Dequeue();

        // checks if dequeue returns front value (a), checks if correct size (1), checks if peek sees b at the front
        Assert.AreEqual("A", actualValue, "Dequeue should return A.");
        Assert.AreEqual(1, queue.Size, "Size should be 1.");
        Assert.AreEqual("B", queue.Peek(), "Front item should be B");
    }
    
    public void Peek_ReturnsFrontElement_DoesNotRemove()
    {
        // arranges the queue, adds 5 then 15, gets size of the queue 
        LQueue<int> queue = new LQueue<int>();
        queue.Enqueue(5);
        queue.Enqueue(15);
        int initialSize = queue.Size;

        // peek is what we're testing, peeks at front value and returns what it sees 
        int actualValue = queue.Peek();

        // checks if the front value of 5 is returned and makes sure peek doesn't change the size 
        Assert.AreEqual(5, actualValue, "Peek should return 5");
        Assert.AreEqual(initialSize, queue.Size, "Size should remain unchanged after Peek.");
    }
    
    public void Contains_ElementIsPresent_ReturnsTrue()
    {
        // arranges queue, adds x then y
        LQueue<char> queue = new LQueue<char>();
        queue.Enqueue('X');
        queue.Enqueue('Y');

        // contains is what we're testing, checks if contains can identify the y element
        Assert.IsTrue(queue.Contains('Y'), "Contains should return true because queue has Y.");
    }
    
    public void Contains_ElementIsNotPresent_ReturnsFalse()
    {
        // arranges queue, adds x
        LQueue<char> queue = new LQueue<char>();
        queue.Enqueue('X');

        // contains is what we're testing, checks if contains knows that z is not in the queue
        Assert.IsFalse(queue.Contains('Z'), "Contains should return false because there is no Z.");
    }
    
    public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
    {
        // arranges the queue 
        LQueue<int> queue = new LQueue<int>();
        
        // the exception catching is what we're testing, specifically in dequeue
        // checks that if dequeue tries to remove something from an empty queue, it'll catch it and return the right response
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue(), "Using dequeue on an empty queue returns the InvalidOperationException.");
    }
    
    public void Peek_EmptyQueue_ThrowsInvalidOperationException()
    {
        // arranges the queue 
        LQueue<int> queue = new LQueue<int>();
        
        // the exception catching is what we're testing, specifically in peek
        // checks that if peek tries to look at an empty queue, it'll catch it and return the right response
        Assert.Throws<InvalidOperationException>(() => queue.Peek(), "Using peek on an empty queue returns the InvalidOperationException.");
    }
}

