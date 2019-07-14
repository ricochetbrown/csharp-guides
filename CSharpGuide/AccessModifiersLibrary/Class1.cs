using System;

namespace AccessModifiersLibrary
{
    class DefaultIsInternalUsableOutsideOfThisLibrary
    {
        public int Number { get; set; }
    }
    
    public class PublicUsableOutsideOfThisLibrary
    {
        public PublicUsableOutsideOfThisLibrary()
        {
            PublicNumber = 1;
            InternalNumber = 2;
        }
        
        public int PublicNumber { get; set; }
        
        internal int InternalNumber { get; set; }    
        
        private int PrivateNumber { get; set; }
        
        protected int ProtectedNumber { get; set; }
        
        protected internal int ProtectedInternalNumber { get; set; }
        
        private protected int PrivateProtectedNumber { get; set; }
    }

    internal class InternalNotUsableOutsideOfThisLibrary
    {
        public int Number { get; set; }

        void UsePublicUsableOutsideOfThisLibrary()
        {
            // Notice 
            var publicClass = new PublicUsableOutsideOfThisLibrary
            {
                PublicNumber = 40,
                InternalNumber = 50,
                ProtectedInternalNumber = 20
            };
        }
    }

    public class DerivedPublicUsableOutsideOfThisLibrary : PublicUsableOutsideOfThisLibrary
    {
        public DerivedPublicUsableOutsideOfThisLibrary()
        {
            PublicNumber = 1;
            InternalNumber = 2;
            ProtectedNumber = 3;
            ProtectedInternalNumber = 4;
            PrivateProtectedNumber = 5;
        }
    }
}