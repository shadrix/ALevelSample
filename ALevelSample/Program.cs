// Queue a work item to be executed on a separate thread from the thread pool.

using System;
using System.Threading;

ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), "WorkItem");

// Simulate other work in the main thread.
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Main thread: {0}", i);
    Thread.Sleep(1000);
}

// Wait for the user to hit <Enter> to exit the program.
Console.ReadLine();

// The method to be executed by the queued work item.
static void DoWork(object state)
{
    string workItemName = state as string;

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("{0} is running on a separate thread: {1}", workItemName, i);
        Thread.Sleep(500);
    }
}