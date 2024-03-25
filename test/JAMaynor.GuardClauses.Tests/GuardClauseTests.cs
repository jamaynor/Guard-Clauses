using DevJoy.GuardClauses;

using System.Diagnostics;


public class GuardClauseTests
{
    [Fact]
    public void StackTrace_Not_Too_Slow()
    {
        object o = null;
        var sw = new Stopwatch();

        long stackMilliseconds = 0;
        long messageMilliseconds = 0;


        try
        {
            sw.Start();
            Guard.Against.Null(o);            
        }
        catch (ArgumentNullException ex)
        {
            sw.Stop();
            stackMilliseconds = sw.ElapsedMilliseconds;

            Assert.True(stackMilliseconds < 150);
        }

        try
        {
            sw.Restart();
            Guard.Against.Null(o, "Its much faster with the message.");
        }
        catch (ArgumentNullException ex)
        {
            sw.Stop();
            messageMilliseconds = sw.ElapsedMilliseconds;

            Assert.True(messageMilliseconds < 50);
        }

    }

    [Fact]
    public void Throw_automatically_captures_parameterName()
    {
        object someObjectName = null;

        try
        {
            Guard.Against.Null(someObjectName);
            Guard.Against.Null(someObjectName, "This is a special message I want included in the Argumentexception that is thrown.");
        }
        catch (Exception ex)
        {
            Assert.True(ex.Message.Contains("someObjectName"));
        }
    }
}