using System;
using Oak;
using NUnit.Framework;
using System.Dynamic;
using System.Collections.Generic;
using NSpec;

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

    class describe_2_alias : nspec
    {
        void it_aliases_and_original_methods_have_same_output()
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

    class describe_2_dynamic_alias : nspec
    {
        void it_dynamic_version_works_too()
        {
            dynamic foo = new FooDynamic();

            Assert.AreEqual(foo.Hello(), foo.SayHello());
        }
    }

    public class ExampleDynamic : DynamicObject
    {
        private Dictionary<string, dynamic> members = new Dictionary<string, dynamic>();

        public dynamic _
        {
            get { return this as dynamic; }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            members[binder.Name] = value;

            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = members[binder.Name];

            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = members[binder.Name]();

            return true;
        }
    }
}
