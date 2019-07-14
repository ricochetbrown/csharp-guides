using System;
// This using statement brings in our external library project
using AccessModifiersLibrary;

namespace AccessModifiers
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("A class directly under a namespace can only have internal or public, as shown in the AccessModifierLibrary project.");
            Console.WriteLine();

            Console.WriteLine("Class default is 'internal', so you will not be able to use the default class (class DefaultIsInternalUsableOutsideOfThisLibrary in " +
                              "AccessModifierLibrary) when importing the reference");
            Console.WriteLine("Trying to use -- var defaultClass = new DefaultIsInternalUsableOutsideOfThisLibrary(); -- will produce a 'Cannot access internal class' error");
            // Comment out the line below to see that it produces an error "Cannot access internal class"
            // var defaultClass = new DefaultIsInternalUsableOutsideOfThisLibrary();
            Console.WriteLine();
            
            Console.WriteLine("Notice that adding internal produces the same result (internal class InternalNotUsableOutsideOfThisLibrary in AccessModifierLibrary)");
            // Comment out the line below to see that it produces an error "Cannot access internal class"
            // var internalClass = new InternalNotUsableOutsideOfThisLibrary();
            Console.WriteLine();
            
            Console.WriteLine("Defining a class as public in the external library (public class PublicUsableOutsideOfThisLibrary in AccessModifierLibrary) " +
                              "gives us the ability to use that class in projects that reference it.");
            Console.WriteLine("We then have access to any of its public properties.");
            var publicClass = new PublicUsableOutsideOfThisLibrary
            {
                PublicNumber = 34
            };
            Console.WriteLine($"We just changed the public class Number property to {publicClass.PublicNumber}");
            Console.WriteLine();
            
            Console.WriteLine("There are four access modifiers in C#:");
            Console.WriteLine("internal");
            Console.WriteLine("public");
            Console.WriteLine("private");
            Console.WriteLine("protected");
            Console.WriteLine();
            
            Console.WriteLine("Let's walk through each of these.");
            Console.WriteLine();
            
            Console.WriteLine("internal once again cannot be used outside of its project");
            Console.WriteLine("notice in the following object initializer, we only have the option of setting the PublicNumber. " +
                              "The InternalNumber is not accessible inside this project.");
            Console.WriteLine("Notice how ONLY the PublicNumber is actually available for us to use outside of the class definition.");
            var publicClassInternal = new PublicUsableOutsideOfThisLibrary
            {
                PublicNumber = 22
            };
            Console.WriteLine();
            Console.WriteLine(publicClassInternal.ToString());
            Console.WriteLine("List of available properties:");
            foreach(var prop in publicClassInternal.GetType().GetProperties()) {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(publicClassInternal, null));
            }
            Console.WriteLine();

            Console.WriteLine("Let's look at how the protected and private classes work. We can demonstrate what is shown on the outside when creating a reference object" +
                              " and what happens inside the class itself.");
            
            Console.WriteLine("The inheritedClass object that we create ONLY has the public property");
            var inheritedClass = new InheritedClass();
            Console.WriteLine(inheritedClass.ToString());
            foreach(var prop in inheritedClass.GetType().GetProperties()) {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(inheritedClass, null));
            }
            Console.WriteLine();
            Console.WriteLine("But the class itself has many different properties on it. Here is everything it has:");
            Console.WriteLine(inheritedClass.ListAllProperties());
            
            Console.WriteLine("The derivedClass object also ONLY has the public property");
            var derivedClass = new DerivedClass();
            Console.WriteLine(derivedClass.ToString());
            foreach(var prop in derivedClass.GetType().GetProperties()) {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(derivedClass, null));
            }
            Console.WriteLine();
            Console.WriteLine("The class itself has every property the InheritedClass does except for the PrivateNumber. Here is everything it has:");
            Console.WriteLine(derivedClass.ListAllProperties());
            Console.WriteLine();

            Console.WriteLine("While it may seem like Protected and ProtectedInternal look the same, you'll notice that they act a little differently.");
            Console.WriteLine("When you derive a class from an outside library, you can bring in Public, Protected, and Protected Internal properties.");
            Console.WriteLine();
            Console.WriteLine("This can be shown in the ThisProgramDerivedClass:");
            var thisProgramDerivedClass = new ThisProgramDerivedClass();
            Console.WriteLine(thisProgramDerivedClass.ToString());
            foreach(var prop in thisProgramDerivedClass.GetType().GetProperties()) {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(thisProgramDerivedClass, null));
            }
            Console.WriteLine();
            
            Console.WriteLine("But if you are trying to just use the external class within this program's class, you will ONLY have access to the public property.");
            Console.WriteLine("This can be shown in ThisProgramClassUsesInheritedClass:");
            var thisProgramClassUsesInheritedClass = new ThisProgramClassUsesInheritedClass();
            Console.WriteLine(thisProgramClassUsesInheritedClass.ToString());
            foreach(var prop in thisProgramClassUsesInheritedClass.GetType().GetProperties()) {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(thisProgramClassUsesInheritedClass, null));
            }
            Console.WriteLine();
            
            Console.WriteLine("If you look at InternalNotUsableOutsideOfThisLibrary in AccessModifierLibrary, though, you'll see it has access to three properties:");
            Console.WriteLine("Public, Internal, and ProtectedInternal.");
            Console.WriteLine("This is because ProtectedInternal can be used within the own assembly OR within a derived class (whether in the same assembly or not)");
            Console.WriteLine();
            
            Console.WriteLine("I hope this has been helpful in understanding the four access modifiers and the two extra combos. Look at the next guide for more on " +
                              "Accessibility Levels of members and the Accessibility Domain");
            Console.WriteLine();
            Console.WriteLine("Press any button to end this console");
            Console.ReadLine();
        }

        class ThisProgramDerivedClass : PublicUsableOutsideOfThisLibrary
        {
            public ThisProgramDerivedClass()
            {
                PublicNumber = 1;
                ProtectedNumber = 3;
                ProtectedInternalNumber = 4;
            }

            public string ListAllProperties()
            {
                return
                    $"PublicNumber = {PublicNumber}, ProtectedNumber = {ProtectedNumber}, ProtectedInternalNumber = {ProtectedInternalNumber}";
            }
        }

        class ThisProgramClassUsesInheritedClass
        {
            public string ImUsingInheritedClass()
            {
                var inheritedClass = new PublicUsableOutsideOfThisLibrary
                {
                    PublicNumber = 1
                };
                
                return
                    $"PublicNumber = {inheritedClass.PublicNumber}";
            }
        }
    }
}