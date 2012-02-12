#explanation: ruby allows you to define an alias for a method that exists
#using the key word alias, a new method can be defined

class Foo
  def say_hello
    "hello"
  end

end

#here is something interesting, in ruby, I can open the class and define an alias
class Foo
  alias :hello :say_hello
end

describe "aliases" do
  it "alias and original methods have the same output" do
    foo = Foo.new

    foo.say_hello.should == foo.hello
  end
end

=begin
C# doesn't have aliases but we can just define a new method that calls the old one

class Foo
{
  public string SayHello() { return "hello"; }

  public string Hello() { return SayHello(); }
}

or we can define an extension methods if you dont have access to the 
original class

static class FooExtensions
{
  public string Hello(this Foo foo)
  {
    return foo.SayHello();
  }
}

or you can opt into the dynamic construct and do it via Gemini

class Foo : Gemini
{
  public Foo()
  {
    This().Hello = This().SayHello;
  }

  dynamic SayHello()
  {
    return "hello";
  }
}
=end
