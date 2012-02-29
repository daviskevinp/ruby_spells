using System;
using Oak;
using NUnit.Framework;
using System.Dynamic;

namespace DynamicTests.GhostMethods
{
    class Foo : Gemini
    {
        dynamic MethodMissing(dynamic args)
        {
            //args.Name
            //args.Parameters
            //args.ParameterNames

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

    public class ExampleDynamic : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = null;

            return true;
        }
    }
}
