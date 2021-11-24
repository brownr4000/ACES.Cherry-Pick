using Bunit;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Test Context used by bUnit
    /// </summary>
    public abstract class BunitTestContext : TestContextWrapper
    {
        /// <summary>
        /// The Setup method sets the context for BUnit tests
        /// </summary>
        [SetUp]
        public void Setup() => TestContext = new Bunit.TestContext();

        /// <summary>
        /// The TearDown method frees up system resources by disposing of test context when BUnit tests are completed
        /// </summary>
        [TearDown]
        public void TearDown() => TestContext.Dispose();
    }
}