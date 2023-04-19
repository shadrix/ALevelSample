using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

SemaphoreSlim semaphore = new (3);
int amount = 0;

async Task AccessAsync(int id)
{
    WriteLine($"Task {id} is waiting to access the amount.");
    await semaphore.WaitAsync();

    try
    {
        WriteLine($"Task {id} is now accessing the amount.");

        // simulate some work
        await Task.Delay(TimeSpan.FromSeconds(1));

        // increase the counter
        Interlocked.Increment(ref amount);

        // completed the work
        WriteLine($"Task {id} has completed accessing the amount {amount}");
    }
    finally
    {
        semaphore.Release();
    }
}

// start 10 tasks to access the amount concurrently
var tasks = new List<Task>();

for (int i = 1; i <= 10; i++)
{
    tasks.Add(AccessAsync(i));
}

// wait for all task to complete
await Task.WhenAll(tasks);

WriteLine("All tasks completed.");
ReadLine();