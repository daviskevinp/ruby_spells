using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;
using Oak;

namespace DynamicTests
{
    class describe_5_changes : nspec
    {
        void it_works()
        {
            dynamic person = new Gemini(new { FirstName = "Jane" });

            (person.FirstName as string).should_be("Jane");

            new Changes(person);

            ((bool)person.HasChanged()).should_be_false();

            person.FirstName = "Jane2";

            ((bool)person.HasChanged()).should_be_true();

            (person.Changes("FirstName").Original as string).should_be("Jane");

            (person.Changes("FirstName").New as string).should_be("Jane2");
        }
    }
}
