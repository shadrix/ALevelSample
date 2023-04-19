using System;
using System.Threading;
using static System.Console;

var lock1 = new object();
var lock2 = new object();

void AcquireLocks1()
{
    var threadId = Thread.CurrentThread.ManagedThreadId;

    while (true)
    {
        if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(1)))
        {
            try
            {
                WriteLine($"Thread {threadId} acquired lock 1.");
                Thread.Sleep(1000);
                WriteLine($"Thread {threadId} attempted to acquire lock 2.");

                if (Monitor.TryEnter(lock2, TimeSpan.FromSeconds(1)))
                {
                    try
                    {
                        WriteLine($"Thread {threadId} acquired lock 2.");
                        break; // exit the loop if both locks are acquired
                    }
                    finally
                    {
                        Monitor.Exit(lock2);
                    }
                }
            }
            finally
            {
                Monitor.Exit(lock1);
            }
        }
    }

    WriteLine($"Thread {threadId} is done.");
}

void AcquireLocks2()
{
    var threadId = Thread.CurrentThread.ManagedThreadId;

    while (true)
    {
        if (Monitor.TryEnter(lock2, TimeSpan.FromSeconds(1)))
        {
            try
            {
                WriteLine($"Thread {threadId} acquired lock 2.");
                Thread.Sleep(1000);
                WriteLine($"Thread {threadId} attempted to acquire lock 1.");

                if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(1)))
                {
                    try
                    {
                        WriteLine($"Thread {threadId} acquired lock 1.");
                        break; // exit the loop if both locks are acquired
                    }
                    finally
                    {
                        Monitor.Exit(lock1);
                    }
                }
            }
            finally
            {
                Monitor.Exit(lock2);
            }
        }
    }

    WriteLine($"Thread {threadId} is done.");
}

// Create two new threads that compete for the locks
var thread1 = new Thread(AcquireLocks1);
var thread2 = new Thread(AcquireLocks2);

// Start the threads
thread1.Start();
thread2.Start();

// Wait for the threads to complete
thread1.Join();
thread2.Join();

WriteLine("Finished.");
ReadLine();