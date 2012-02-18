#explanation: ruby allows you to intercept the inclusion of modules

module Dup 
  def self.included(base)
    base.public_instance_methods.each do |m|
      base.class_eval { alias_method m.to_s + "_dup", m } 
    end
  end
end

class SomeClass
  def say_hello 
    return "hello" 
  end
end

class SomeClass
  include Dup 
end

describe "hooks" do
  it "method is duplicated" do
    SomeClass.new.respond_to?(:say_hello_dup).should be_true
  end
end
