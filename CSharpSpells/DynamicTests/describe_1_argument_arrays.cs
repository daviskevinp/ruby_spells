using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using Oak;

namespace DynamicTests.ArgumentArrays
{
    class Foo
    {
        public IEnumerable<Type> ClassNames(params object[] args)
        {
            return args.Select(arg => arg.GetType());
        }
    }

    class DynamicFoo : Gemini
    {
        IEnumerable<dynamic> Find(dynamic args)
        {
            return args.Members();

            //args.FirstName, args.LastName are accessible here
        }
    }

    class describe_1_argument_arrays : nspec
    {
        void it_class_is_returned_for_each_arg()
        {
            var foo = new Foo();

            var names = foo.ClassNames("abc", 1, 6.4099983).ToList();

            names[0].should_be(typeof(string));

            names[1].should_be(typeof(int));

            names[2].should_be(typeof(double));
        }

        void specify_dynamic_named_params()
        {
            dynamic foo = new DynamicFoo();

            var members = foo.Find(FirstName: "Amir", LastName: "Rajan") as IEnumerable<string>;

            members.should_contain("FirstName");

            members.should_contain("LastName");
        }
    }
}