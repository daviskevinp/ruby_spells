#explanation: ruby allows you to define an alias for a method that exists
#using the key word alias, a new method can be defined

class Foo
  def say_hello
    "hello"
  end
end

#here is something interesting, in ruby, I can open the class and define an alias
#unfortunately with C# the closest you can get to this is inheritence or extension methods
class Foo
  alias :hello :say_hello
end

describe "aliases" do
  it "alias and original methods have the same output" do
    foo = Foo.new

    foo.say_hello.should == foo.hello
  end
end
