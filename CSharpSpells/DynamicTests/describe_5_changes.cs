using System;
using Oak;
using NUnit.Framework;
using NSpec;

namespace DynamicTests
{
    class describe_5_changes : nspec
    {
        public void it_works()
        {
            dynamic person = new Gemini(new { FirstName = "Jane" });

            Assert.AreEqual("Jane", person.FirstName);

            new Changes(person);

            Assert.IsFalse(person.HasChanged());

            person.FirstName = "Jane2";

            Assert.IsTrue(person.HasChanged());

            Assert.AreEqual("Jane", person.Changes("FirstName").Original);

            Assert.AreEqual("Jane2", person.Changes("FirstName").New);
        }
    }
}
