#explanation: ruby allows you to create modules
#these modules can be mixed in to a class by opening the class up

#module hello that has say_hello method
module Hello
  def say_hello
    return "hello"
  end
end

#module bye that has say_bye method
module Bye
  def say_bye
    return "bye"
  end
end

#class Foo is defined
class Foo 
  def say_foo
    return "foo"
  end
end

#class foo is opened up and modules are added
class Foo
  include Hello
  include Bye

  def say_bar
    return "bar"
  end
end

describe "mixins" do
  it "works" do
    foo = Foo.new

    foo.say_foo.should == "foo"

    foo.say_hello.should == "hello"

    foo.say_bye.should == "bye"

    foo.say_bar.should == "bar"
  end
end

=begin
strongly typed C# can't do this, but dynamic C# can....kinda

class Hello
{
  public Hello(dynamic entity)
  {
    entity.SayHello = new DynamicFunction(() => "hello");
  }
}

class Bye
{
  public Hello(dynamic entity)
  {
    entity.SayBye = new DynamicFunction(() => "bye");
  }
}

class Foo : Gemini
{
  dynamic SayFoo()
  {
    return "Foo";
  }
}

static class BootStrap
{
  static void Init()
  {
    Gemini.Extend<Foo, Hello>();
    Gemini.Extend<Foo, Bye>();
    Gemini.Extend<Foo>((i) =>
    {
      i.SayBar = new DynamicFunction(() => "bar");
    });
  }
}

//once at some entry point of the application
BootStrap.Init()

dynamic foo = new Foo();

foo.SayHello(); //returns Hello

foo.SayBye(); //returns Bye

OR

class Foo : Gemini
{
  static Foo()
  {
    Gemini.Extend<Foo, Hello>();
    Gemini.Extend<Foo, Bye>();
  }

  dynamic SayFoo()
  {
    return "Foo";
  }

  dynamic SayBar()
  {
    return "Bar";
  }
}
=end
