using System;

namespace AccessibilityLevels
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Take a look at the class, enum, interface, and struct created to see which " +
                              "accessibility levels each provide.");
        }

        class Class1
        {
            // All four access modifiers can be used here plus both combos
            public int PublicNumber;
            internal int InternalNumber;
            private int PrivateNumber;
            protected int ProtectedNumber;
            protected internal int ProtectedInternalNumber;
            private protected int PrivateProtectedNumber;
        }

        enum Enum1
        {
            // No access modifiers can be used in here
            Monday = 1,
            Tuesday = 2
        }

        interface IInterface1
        {
            // No access modifiers can be used in here
            void CantUseAccessModifier();
        }

        struct Struct1
        {
            // Only three access modifiers can be used in structs
            // Structs cannot be inherited, so there is no need for any of the protected access modifiers
            public int PublicNumber;
            internal int InternalNumber;
            private int PrivateNumber;
        }
    }
}