using System;

namespace AccessibilityDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            // Access is unlimited.
            Class1.PublicNumber = 1;

            // Accessible only in current assembly.
            Class1.InternalNumber = 2;

            // Error CS0122: inaccessible outside Class1.
            // Class1.PrivateNumber = 3;  

            // Access is unlimited.
            Class1.PublicSubClass.PublicNumber = 1;

            // Accessible only in current assembly.
            Class1.PublicSubClass.InternalNumber = 2;

            // Error CS0122: inaccessible outside PublicSubClass.
            // Class1.PublicSubClass.PrivateNumber = 3; 

            // Error CS0122: inaccessible outside Class1 because of the private sub class.
            // Class1.PrivateSubClass.PublicNumber = 1;

            // Error CS0122: inaccessible outside Class1 because of the private sub class.
            // Class1.PrivateSubClass.InternalNumber = 2;

            // Error CS0122: inaccessible outside PrivateSubClass.
            // Class1.PrivateSubClass.PrivateNumber = 3;
        }
    }

    public class Class1
    {
        public static int PublicNumber = 1;
        internal static int InternalNumber = 2;
        private static int PrivateNumber = 3;

        static Class1()
        {
            PublicSubClass.PublicNumber = 1;
            PublicSubClass.InternalNumber = 2;

            PrivateSubClass.PublicNumber = 3;
            PrivateSubClass.InternalNumber = 4;
			
            // Cannot access either private static members of the sub classes
            // PublicSubClass.PrivateNumber = 1;
            // PrivateSubClass.PrivateNumber = 1;
        }
		
        public class PublicSubClass
        {
            public static int PublicNumber;
            internal static int InternalNumber;
            private static int PrivateNumber;
        }

        private class PrivateSubClass
        {
            public static int PublicNumber;
            internal static int InternalNumber;
            private static int PrivateNumber;
        }
    }
}