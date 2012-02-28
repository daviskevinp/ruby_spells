using System;
using Oak;
using NUnit.Framework;

namespace DynamicTests.Aliases
{
    class Foo
    {
        public string SayHello() { return "hello"; }
    }

    static class FooExtensions
    {
        public static string Hello(this Foo foo)
        {
            return foo.SayHello();
        }
    }

    [TestFixture]
    public class describe_2_alias
    {
        [Test]
        public void it_aliases_and_original_methods_have_same_output()
        {
            var foo = new Foo();

            Assert.AreEqual(foo.Hello(), foo.SayHello());
        }
    }

    class FooDynamic : Gemini
    {
        public FooDynamic()
        {
            _.Hello = _.SayHello;
        }

        dynamic SayHello()
        {
            return "hello";
        }
    }

    [TestFixture]
    public class describe_2_dynamic_alias
    {
        [Test]
        public void it_dynamic_version_works_too()
        {
            dynamic foo = new FooDynamic();

            Assert.AreEqual(foo.Hello(), foo.SayHello());
        }
    }
}
