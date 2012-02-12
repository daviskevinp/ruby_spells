#explanation: ruby allows you to pass in parameters with an asterisk infront of it
#this means that any number of parameters can be given to this method

class Foo
  def class_names(*args)
    return args.map { |arg| arg.class }
  end
end

describe "argument array" do
  it "class is returned for each arg" do
    foo = Foo.new

    names = foo.class_names("abc", 1, 6.409983)

    names[0].should == String

    names[1].should == Fixnum

    names[2].should == Float
  end
end


=begin
Here is the same thing in C#

class Foo
{
  public IEnumerable<string> ClassNames(params object[] args)
  {
    return args.Select(arg => arg.GetType().Name);
  }
}

ruby uses argument arrays in conjunction with hashes to define a jagged parameter list, for example:

Person.find(:first, :order => "created_on DESC", :offset => 5)
Person.find(:last, :conditions => [ "user_name = ?", "admin"])

C# can do something similar

Person.Find(new { option = "First", order = "created_on DESC", offset = 5 });
Person.Find(new { option = "Last", conditions = new [] { "user_name = ?", "admin" });

or you can opt into the dynamic construct and do it via Gemini

class Foo : Gemini
{
  dynamic Find(dynamic args)
  {
    //args.option, order, and offset will be available given the line below
  }
}

foo.Find(option: "First", order: "created_on DESC", offset: 5);
foo.Find(option: "Last", conditions: new [] { "user_name = ?", "admin" });

=end
