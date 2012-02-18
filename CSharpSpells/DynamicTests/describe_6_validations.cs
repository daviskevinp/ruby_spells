using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using Oak;

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

            ((bool)person.IsValid()).should_be_false();

            (person.Errors()[0].Value as string).should_be("FirstName is required.");

            (person.Errors()[1].Value as string).should_be("Email is required.");

            person.FirstName = "Jane";

            person.Email = "user@example.com";

            person.EmailConfirmation = "user@example.com";

            ((bool)person.IsValid()).should_be_true();
        }
    }
}
