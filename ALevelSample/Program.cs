using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

var streamWriter = new StreamWriter("text");
var semaphoreSlim = new SemaphoreSlim(1);

Task.Run(() =>
{
    for (var i = 0; i < 1000; i++)
    {
        var k = i;
        Task.Run(async () => { await WriteAsync(k.ToString()); });
    }
});

Task.Run(() =>
{
    for (var i = 2000; i < 3000; i++)
    {
        var k = i;
        Task.Run(async () => { await WriteAsync(k.ToString()); });
    }
});

Console.ReadKey();

async Task WriteAsync(string text)
{
    await semaphoreSlim.WaitAsync();

    await streamWriter.WriteLineAsync(text);
    await streamWriter
        .FlushAsync(); // https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.flushasync?view=net-5.0

    semaphoreSlim.Release();
}
