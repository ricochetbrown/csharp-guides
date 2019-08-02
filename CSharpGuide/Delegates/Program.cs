using System;
using System.Collections.Generic;

namespace Delegates
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Let's talk about delegates. These may seem a little confusing at first," +
			                  " but their main purpose is to pass methods as arguments to other methods.");
			Console.WriteLine("Take event handlers for example. They are really just methods that are " +
			                  "invoked using delegates.");
			Console.WriteLine();
			
			Console.WriteLine("So let's create a super simple delegate to see what it does."); 
			Console.WriteLine("We already created 'Del' which can handle any method that takes in a string.");
			Console.WriteLine("We can now make a method into an object by calling:");
			Console.WriteLine("Del handler = DelegateMethod");
			Console.WriteLine("This is super useful because we can now put this in classes and structs.");
			Console.WriteLine("Let's run this delegate and see what it does:");
			Console.WriteLine();
			
			// Instantiate the delegate.
			Del handler = DelegateMethod;

			// Call the delegate.
			handler("Look I am a working delegate!");
			
			Console.WriteLine();
			
			Console.WriteLine("Delegates help us because we can then pass them into other methods.");
			Console.WriteLine("Take the next example. We can pass in a string and the delegate, ");
			Console.WriteLine("which we can then use to call the delegate method with the parameter");
			Console.WriteLine("Take a look at what this method call does with Del as a param:");
			Console.WriteLine();
			
			MethodWithCallback("I'm called from a method, but use the delegate to write this message", handler);
			
			Console.WriteLine();
			
			Console.WriteLine("Let's look at a more practical example.");
		}
		
		private delegate void Del(string message);

		private static void DelegateMethod(string message)
		{
			Console.WriteLine(message);
		}
		
		private static void MethodWithCallback(string param, Del callback)
		{
			callback(param);
		}
		
		// Practical Example
		private delegate bool AbleToAdopt(Dog adoptable);
		
		private class Dog
		{
			public int ID { get; set; }
			public string Name { get; set; }
			public string Gender { get; set; }
			public int Experience { get; set; }
			public int Salary { get; set; }
		}
	}
}
