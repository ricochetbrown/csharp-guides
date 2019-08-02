using System;
using System.Collections.Generic;

namespace OOP
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Let's take a look at the four main tenants of OOP (Object-oriented programming).");
			Console.WriteLine("These are encapsulation, abstraction, inheritance, and polymorphism.");
			Console.WriteLine();
			
			Console.WriteLine("Encapsulation allows us to protect data from unwanted access at every level.");
			
			Console.WriteLine("Consider that we want to keep properties ");
			User u = new User();
			u.Name = "Thor";
			u.Location = "Asgard";
			// u.CantSeeThis = ""; // This line will error out because it is privately held by the class
			Console.WriteLine("Name: " + u.Name);
			Console.WriteLine("Location: " + u.Location);
			
			Console.WriteLine("Encapsulation allows us to keep the inner workings of our program safe from corruption by outside objects.");
			
			Console.WriteLine();
			
			Console.WriteLine("Abstraction is next. Abstraction allows us to show only what is necessary to a piece of programming.");
			Console.WriteLine("Look at the example where we can create a Shape object from a class that it inherits the abstract class from, in this case Square.");
			
			Shape lookImAShape = new Square(2);
			// Shape cantMakeFromAShape = new Shape(); // Notice you cannot make a Shape object from the abstract class itself
			Console.WriteLine("The area is: " + lookImAShape.area());
			
			Console.WriteLine("Notice how we can create a Shape object and we ONLY have access to the area method (which we can override in the class itself).");
			Console.WriteLine("This is crucial because it protects any underlying logic in the Square class. The user ONLY cares about the area in this case, ");
			Console.WriteLine("so area is all they are able to see.");
			
			Console.WriteLine();
			
			Console.WriteLine("Guess what?! We just learned inheritance also! Let's look at another example.");
			Console.WriteLine("Say we want to have a boat and a car class. All of these can be classified as vehicles. Both vehicles take different fuel types");
			Console.WriteLine("We can create a Vehicle class that the Car and Boat can both inherit from. In this case, they will inherit the fuelType property.");
			Console.WriteLine("Now they can use the fuelType property, which is only declared in the Vehicle class.");

			var car = new Car();
			var boat = new Boat();
			
			Console.WriteLine("Car's fuel type is: " + car.fuelType);
			Console.WriteLine("Boat's fuel type is: " + boat.fuelType);
			
			Console.WriteLine("Pretty cool. We can even go a step further. Certain cars taken different fuel types. What about a Tesla?");
			
			var tesla = new Tesla();
			
			Console.WriteLine("Tesla's fuel type is: " + tesla.fuelType);
			
			Console.WriteLine("If we had a regular Ford, we would not need to change the fuelType since it is declared as gas in car, but inheritance allows us to use multiple ");
			Console.WriteLine("levels of inheritance. Notice though that we can only make Ford inherit ONE class. It could not inherit both Car and Shape. This prevents ");
			Console.WriteLine("any circular problems from occurring. Single inheritance is all that is allowed.");

			var ford = new Ford();
			
			Console.WriteLine("Ford's fuel type is: " + ford.fuelType);
			
			Console.WriteLine();
			
			Console.WriteLine("The last principle we need to talk about is polymorphism. We basically already showed this, but it allows an object to be many things.");
			
			var vehicles = new List<Vehicle>
			{
				new Boat(),
				new Car(),
				new Tesla()
			};

			foreach (var vehicle in vehicles)
			{
				Console.WriteLine("My object is: " + vehicle.ToString() + " and my fuel type is: " + vehicle.fuelType);
			}
			
			Console.WriteLine("Polymorphism allows us to use anything that inherits from Vehicle so that we can run it through a list like this.");
			Console.WriteLine("This is extremely helpful when we have a need to just look at one of the base types for things, while still allowing us to ");
			Console.WriteLine("get more detail in our new classes when needed.");
		}
	}
	
	class User
	{
		public string Name { get; set; }
		public string Location { get; set; }
		private string CantSeeThis { get; set; }
	}

	abstract class Shape
	{
		public abstract int area();
	}

	class Square : Shape
	{
		private int side;

		public Square(int x)
		{
			side = x;
		}

		public override int area()
		{
			return side * side;
		}
	}

	class Vehicle
	{
		public string fuelType { get; set; }
	}

	class Car : Vehicle
	{
		public Car()
		{
			fuelType = "Gas";
		}
	}

	class Boat : Vehicle
	{
		public Boat()
		{
			fuelType = "Diesel";
		}
	}

	class Tesla : Car
	{
		public Tesla()
		{
			fuelType = "Electric";
		}
	}

	class Ford : Car
	{
		public Ford()
		{
		}
	}
}
