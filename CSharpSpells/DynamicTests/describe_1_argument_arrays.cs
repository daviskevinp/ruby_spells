using System;
using System.Collections.Generic;
using System.Linq;
using Oak;
using NSpec;
using NUnit.Framework;

namespace DynamicTests.ArgumentArrays
{
    class Foo
    {
        public IEnumerable<Type> ClassNames(params object[] args)
        {
            return args.Select(arg => arg.GetType());
        }
    }

    class describe_1_argument_arrays : nspec
    {
        void it_class_is_returned_for_each_arg()
        {
            var foo = new Foo();

            var names = foo.ClassNames("abc", 1, 6.4099983).ToList();

            Assert.AreEqual(names[0], typeof(string));

            Assert.AreEqual(names[1], typeof(int));

            Assert.AreEqual(names[2], typeof(double));
        }
    }

    class DynamicFoo : Gemini
    {
        IEnumerable<dynamic> Find(dynamic args)
        {
            return args.Members();
        }
    }

    class describe_1_dynamic_argument_arrays : nspec
    {
        void specify_dynamic_named_params()
        {
            dynamic foo = new DynamicFoo();

            var members = foo.Find(FirstName: "Amir", LastName: "Rajan") as IEnumerable<string>;

            CollectionAssert.Contains(members, "FirstName");

            CollectionAssert.Contains(members, "LastName");
        }        
    }
}
