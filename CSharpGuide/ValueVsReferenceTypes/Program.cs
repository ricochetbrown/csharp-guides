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
			Console.WriteLine("Press any key to close the console");
			Console.ReadLine();
		}

		struct AllValueTypes
		{
			public int Int1;
			public bool Bool1;
			public DateTime DateTime1;
			public decimal Decimal1;
			public float Float1;
			public byte Byte1;
			public char Char1;
			public long Long1;
			public sbyte Sbyte1;
			public short Short1;
			public uint Uint1;
			public ulong Ulong1;
			public ushort Ushort1;
			
			public enum Enum1 {};
		}

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
