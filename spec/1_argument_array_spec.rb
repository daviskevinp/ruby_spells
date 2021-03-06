#explanation: ruby allows you to pass in parameters with an asterisk infront of it
#this means that any number of parameters can be given to this method

class Foo
  def class_names(*args)
    return args.map { |arg| arg.class }
  end

  def find(args)
    puts args
  end
end

describe "argument array" do
  it "class is returned for each arg" do
    foo = Foo.new

    names = foo.class_names "abc", 1, 6.409983 

    names[0].should == String

    names[1].should == Fixnum

    names[2].should == Float
  end
end
