namespace ConsoleApp13.Test;

public class UnitTest1
{
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