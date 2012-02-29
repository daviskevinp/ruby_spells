using System;
using Oak;
using NUnit.Framework;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;

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

    public class ExampleDynamic : DynamicObject
    {
        private static List<KeyValuePair<Type, Func<dynamic, dynamic>>> Includes = new List<KeyValuePair<Type, Func<dynamic, dynamic>>>();

        private List<Type> types = new List<Type>();

        public static void Extend<A, B>()
        {
            Includes.Add(new KeyValuePair<Type, Func<dynamic, dynamic>>(typeof(A), 
            (i) =>
            {
                var constructor = typeof(B).GetConstructor(new Type[] { typeof(object) });

                constructor.Invoke(new object[] { i });

                return null;
            }));
        }

        public static void Extend<T>(Action<dynamic> extension)
        {
            Includes.Add(new KeyValuePair<Type, Func<dynamic, dynamic>>(typeof(T), (i) => { extension(i); return null; }));
        }

        public ExampleDynamic()
        {
            var includes = Includes.Where(s => types.Contains(s.Key));

            foreach (var include in includes) include.Value(this);
        }
    }
}
