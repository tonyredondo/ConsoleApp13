namespace ConsoleApp13.Test;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        var scope = Datadog.Trace.Tracer.Instance.ActiveScope;
        await Task.Delay(1_000);
        scope?.Span.SetTag("my-tag", "my-value");
        for (var i = 0; i < 10; i++)
        {
            scope?.Span.SetTag($"my-tag-{i}", $"my-value-{i}");
            try
            {
                var x = 124;
                var y = 234;
                var p = 1 - 1;
                var z = x + y;
                var result = z / p;
            }
            catch (Exception ex)
            {
                scope?.Span.SetException(ex);
            }
        }

        await Task.Delay(1_000);
    }

    [Fact]
    public void FailTest()
    {
        var x = 124;
        var y = 234;
        var p = 1 - 1;
        var z = x + y;
        var result = z / p;
        _ = result;
    }
}