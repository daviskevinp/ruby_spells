using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using Oak;

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

    class describe_3_ghost_methods : nspec
    {
        void it_calls_method_via_method_missing()
        {
            dynamic foo = new Foo();

            (foo.SayBye() as string).should_be("Bye");

            (foo.SayHello() as string).should_be("Hello");
        }
    }
}
