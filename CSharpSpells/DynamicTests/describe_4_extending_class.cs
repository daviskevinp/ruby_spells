using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using Oak;

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

    class describe_4_extending_class : nspec
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

        void it_works()
        {
            dynamic foo = new Foo();

            (foo.SayFoo() as string).should_be("foo");

            (foo.SayHello() as string).should_be("hello");

            (foo.SayBye() as string).should_be("bye");

            (foo.SayBar() as string).should_be("bar");
        }
    }
}
