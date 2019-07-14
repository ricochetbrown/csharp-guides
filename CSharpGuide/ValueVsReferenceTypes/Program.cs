using System;

namespace ValueVsReferenceTypes
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to some fun with value types and reference types. These are important to " +
			                  "understand because they affect performance and memory.");
			Console.WriteLine();
			
			Console.WriteLine("Let's start out with value types.");
			Console.WriteLine("Value types can be either Structs or Enums. That's it!");
			Console.WriteLine("Take the bool for example. That really just uses the System.Boolean Struct.");
			Console.WriteLine();
			
			Console.WriteLine("Let's take a look at Float, Double, and Decimal. They might all seem very similar, but how they process is what separates them.");
			var myStruct = new AllValueTypes
			{
				Float1 = 1F / 3,
				Double1 = 1D / 3,
				Decimal1 = 1M / 3
			};
			Console.WriteLine("Notice the differences in each of these below with 1 divided by 3:");
			Console.WriteLine("float: {0} double: {1} decimal: {2}", myStruct.Float1, myStruct.Double1, myStruct.Decimal1);
			Console.WriteLine("Floats are the quickest to work with because they are 32 bit, meaning they only take 7 digits.");
			Console.Write("Doubles are 64 bit and take 15-16 digits");
			Console.Write("Finally, decimals are 128 bit and can take 28-29 significant digits. Decimals are meant to use when it is critical to get " +
			              "the correct number, like in finances, but know that they will be almost 20x slower than using floats.");
			
			Console.WriteLine();
			Console.WriteLine("Press any key to close the console");
			Console.ReadLine();
		}

		struct AllValueTypes
		{
			public int Int1; // used to store a whole number (no decimals allowed). This is also just Int32
			public bool Bool1; // used to store true or false
			public DateTime DateTime1; // used to store a value that contains a date and a time
			public decimal Decimal1; // used to represent numbers like financial values that are precise (128 bit meaning they take 28-29 significant digits)
			public float Float1; // faster to work with than decimals since they don't require precision (32 bit meaning they take 7 digits)
			public double Double1; // faster to work with than decimals but slower than float (64 bit meaning they take 15-16 digits)
			public Single Single1; // 7 decimal digits of precision
			public byte Byte1; // Bytes can be in the range of 0 to 255
			public long Long1; // this is an Int64
			public sbyte Sbyte1; // Sbyte is a signed 8-bit integet value which represents values from -128 to 127
			public short Short1; // this is just an Int16
			public uint Uint1; // this is UInt32
			public ulong Ulong1; // this is UInt64
			public ushort Ushort1; // this is UInt16
			public char Char1; // chars are used to create unicode strings
			
			public enum Enum1 {};
		}

		// Reference types are all the ones below:
	
		class Class1
		{
			public int PublicNumber;
		}

		interface IInterface1
		{
			
		}

		private static int[] Array1;

		private static string String1;

		private static object Object1;

		private delegate void Delegate1(int value);
	}
}
