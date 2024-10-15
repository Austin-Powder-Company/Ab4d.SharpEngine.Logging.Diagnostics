using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ab4d.SharpEngine.Logging.Diagnostics.Test;

[TestClass]
public sealed class TraceWriterTests
{
    sealed class TestListener : TraceListener
    {
        public readonly List<string?> Messages = new();

        public override void Write(string? message) =>
            Messages.Add(message);

        public override void WriteLine(string? message) =>
            Messages.Add(message);
    }

    [TestMethod]
    public void Main()
    {
        // Setup

        var testListener = new TestListener();

        Trace.Listeners.Add(testListener);

        TraceWriter.WriteTo();

        // Test

        Ab4d.SharpEngine.Utilities.Log.WriteLog(Ab4d.SharpEngine.Common.LogLevels.Debug, null, 0, "Debug!");
        Ab4d.SharpEngine.Utilities.Log.WriteLog(Ab4d.SharpEngine.Common.LogLevels.Info, null, 0, "Info!");

        Assert.AreEqual(4, testListener.Messages.Count);
        Assert.IsTrue(testListener.Messages[1].EndsWith("|Debug!||"));
        Assert.IsTrue(testListener.Messages[3].EndsWith("|Info!||"));
    }
}