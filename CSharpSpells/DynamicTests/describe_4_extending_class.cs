using System;
using Oak;
using NUnit.Framework;

namespace DynamicTests.Extend
{
    class Hello
    {
        public Hello(dynamic entity)
        {
            entity.SayHello = new DynamicFunction(() => "hello");
        }
    }

    class Bye
    {
        public Bye(dynamic entity)
        {
            entity.SayBye = new DynamicFunction(() => "bye");
        }
    }

    class Foo : Gemini
    {
        dynamic SayFoo()
        {
            return "foo";
        }
    }

    [TestFixture]
    public class describe_4_extending_class
    {
        static describe_4_extending_class()
        {
            Gemini.Extend<Foo, Hello>();

            Gemini.Extend<Foo, Bye>();

            Gemini.Extend<Foo>(
            i =>
            {
                i.SayBar = new DynamicFunction(() => "bar");
            });
        }

        [Test]
        public void it_works()
        {
            dynamic foo = new Foo();

            Assert.AreEqual("foo", foo.SayFoo());

            Assert.AreEqual("hello", foo.SayHello());

            Assert.AreEqual("bye", foo.SayBye());

            Assert.AreEqual("bar", foo.SayBar());
        }
    }
}
