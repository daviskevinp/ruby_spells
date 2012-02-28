using System;
using Oak;
using NUnit.Framework;

namespace DynamicTests.GhostMethods
{
    class Foo : Gemini
    {
        dynamic MethodMissing(dynamic args)
        {
            var whatToSay = args.Name.Replace("Say", "");

            return whatToSay;
        }
    }

    [TestFixture]
    public class describe_3_ghost_methods
    {
        [Test]
        public void it_calls_method_via_method_missing()
        {
            dynamic foo = new Foo();

            Assert.AreEqual("Bye", foo.SayBye());

            Assert.AreEqual("Hello", foo.SayHello());
        }
    }
}
