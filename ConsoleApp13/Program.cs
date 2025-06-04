namespace ConsoleApp13;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Creating a span that lasts 5 seconds and has a tag...");
        using var scope = Datadog.Trace.Tracer.Instance.StartActive("my-span");
        await Task.Delay(1_000);
        scope.Span.SetTag("my-tag", "my-value");
        try
        {
            var x = 124;
            var y = 234;
            var p = 1 - 1;
            var z = x + y;
            var result = z / p;
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            scope.Span.SetException(ex);
        }

        await Task.Delay(1_000);
        Console.WriteLine("Span created and tag set. Press any key to exit.");
    }
}