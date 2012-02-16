#explanation: ruby allows you to define method missing for a class
#if a method on a class doesn't exist it calls method_missing for that class

class Foo
  def method_missing(name, *args)
    what_to_say = name.to_s.gsub("say_", "")

    return what_to_say
  end
end

#because of ghost methods, both say bye and say hello work
describe "ghost methods" do
  it "calls method method via method messing" do
    foo = Foo.new

    foo.say_bye.should == "bye"

    foo.say_hello.should == "hello"
  end
end

=begin
strongly typed C# can't do this, but dynamic C# can.

class Foo : Gemini
{
  dynamic MethodMissing(dynamic args)
  {
    var whatToSay = args.Name.Replace("Say", "");

    return whatToSay;
  }
}
=end
