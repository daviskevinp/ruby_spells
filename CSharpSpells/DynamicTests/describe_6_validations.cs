using System;
using System.Collections.Generic;
using Oak;
using NUnit.Framework;
using NSpec;

namespace DynamicTests
{
    class describe_6_validations : nspec
    {
        void it_works()
        {
            dynamic person = new Gemini();

            person.Validates = new DynamicFunction(() =>
            {
                var validations = new List<dynamic>();

                validations.Add(new Presence("FirstName"));

                validations.Add(new Presence("Email"));

                validations.Add(new Confirmation("Email"));

                return validations;
            });

            new Validations(person);

            Assert.IsFalse(person.IsValid());

            Assert.AreEqual("FirstName is required.", person.Errors()[0].Value);

            Assert.AreEqual("Email is required.", person.Errors()[1].Value);

            person.FirstName = "Jane";

            person.Email = "user@example.com";

            person.EmailConfirmation = "user@example.com";

            Assert.IsTrue(person.IsValid());
        }
    }
}
