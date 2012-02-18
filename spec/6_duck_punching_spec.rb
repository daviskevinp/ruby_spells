#explanation: ruby allows you to redefine methods too

class Duck
  def say_hello
    "hello " + get_name
  end

  def get_name
    raise Exception.new("not implemented")
  end
end

#redefine method
class Duck 
  def get_name
    return "Jane"
  end
end

describe "duck punching" do
  it "works" do
    duck = Duck.new

    duck.say_hello.should == "hello Jane"
  end
end
