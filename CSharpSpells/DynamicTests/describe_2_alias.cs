using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using Oak;

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

    class describe_2_alias : nspec
    {
        void it_aliases_and_original_methods_have_same_output()
        {
            var foo = new Foo();

            foo.SayHello().should_be(foo.Hello());
        }

        void it_dynamic_version_works_too()
        {
            dynamic foo = new FooDynamic();

            (foo.SayHello() as string).should_be(foo.Hello() as string);
        }
    }
}
