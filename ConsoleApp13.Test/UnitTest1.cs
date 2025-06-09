namespace ConsoleApp13.Test;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
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
    }
}