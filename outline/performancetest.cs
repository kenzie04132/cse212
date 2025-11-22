using System;
using System.Diagnostics;

public class Analysis
{
    public static void RunAllAnalysis()
    {
        // calls test 
        RunPerformanceAnalysis();
    }

    // --- Performance Measurement (Not Unit Tests) ---

    /// measures execution time for running the different functions 
    public static void RunPerformanceAnalysis()
    {
        Console.WriteLine("\n## ⏱️ Performance Analysis (Stopwatch)");

        // tests different sizes (1000, 10000, 100000)
        int[] trialSizes = { 1000, 10000, 100000 };
        int trialsPerOp = 50; // repeats 50 times to get a better average

        foreach (int size in trialSizes)
        {
            Console.WriteLine($"\n--- Trials for N = {size} ---");

            // measures time for enqueue
            LQueue<int> queueEnqueue = SetupQueue(size);
            MeasureOperation("Enqueue", trialsPerOp, () => { queueEnqueue.Enqueue(size + 1); }, size);

            // measures time for dequeue
            LQueue<int> queueDequeue = SetupQueue(size);
            MeasureOperation("Dequeue", trialsPerOp, () =>
            {
                int val = queueDequeue.Dequeue();
                queueDequeue.Enqueue(val);
            }, size);

            // measures time for peek
            LQueue<int> queuePeek = SetupQueue(size);
            MeasureOperation("Peek", trialsPerOp, () => { queuePeek.Peek(); }, size);

            // measures time for contains 
            LQueue<int> queueContains = SetupQueue(size);
            int target = size - 1;
            MeasureOperation($"Contains (Target: {target})", trialsPerOp, () => { queueContains.Contains(target); },
                size);
        }

        // DOCUMENTATION OF FINDINGS: BIG-O COMPLEXITY
        // Enqueue: The average time is small and the growth of the value doesn't change it basically at all.
        // Dequeue: The average time is small, but increases linearly as the value increases 
        // Peek: The average time is small and is constant no matter how big value it is looking at is.
        // Contains: Like dequeue, the average time is small, and increases linearly as the value increases 
    }

    // function for setting up queues
    private static LQueue<int> SetupQueue(int size)
    {
        LQueue<int> queue = new LQueue<int>();
        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(i);
        }

        return queue;
    }

    // function for measuring the length of the functions 
    private static void MeasureOperation(string operationName, int trials, Action operation, int N)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < trials; i++)
        {
            operation.Invoke();
        }

        stopwatch.Stop();

        // calculates the average time per operation
        long averageTimeTicks = stopwatch.ElapsedTicks / trials;
        double averageTimeMs = stopwatch.Elapsed.TotalMilliseconds / trials;

        Console.WriteLine($"- {operationName} (N={N}): Avg Time = {averageTimeTicks} Ticks ({averageTimeMs:F6} ms)");
    }
}