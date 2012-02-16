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
