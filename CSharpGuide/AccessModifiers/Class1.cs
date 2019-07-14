using System.Runtime.CompilerServices;

namespace AccessModifiers
{
    class InheritedClass
    {
        public InheritedClass()
        {
            PublicNumber = 1;
            InternalNumber = 2;
            PrivateNumber = 3;
            ProtectedNumber = 4;
            ProtectedInternalNumber = 5;
            PrivateProtectedNumber = 6;
        }
        
        public int PublicNumber { get; set; }
        
        internal int InternalNumber { get; set; }    
        
        private int PrivateNumber { get; set; }
        
        protected int ProtectedNumber { get; set; }
        
        protected internal int ProtectedInternalNumber { get; set; }
        
        private protected int PrivateProtectedNumber { get; set; }

        public string ListAllProperties()
        {
            return
                $"PublicNumber = {PublicNumber}, InternalNumber = {InternalNumber}, PrivateNumber = {PrivateNumber}, ProtectedNumber = {ProtectedNumber}" +
                $"ProtectedInternalNumber = {ProtectedInternalNumber} + PrivateProtectedNumber = {PrivateProtectedNumber}";
        }
    }

    class DerivedClass : InheritedClass
    {
        public DerivedClass()
        {
            PublicNumber = 1;
            InternalNumber = 2;
            ProtectedNumber = 3;
            ProtectedInternalNumber = 4;
            PrivateProtectedNumber = 5;
        }
        
        public string ListAllProperties()
        {
            return
                $"PublicNumber = {PublicNumber}, InternalNumber = {InternalNumber}, ProtectedNumber = {ProtectedNumber} " +
                $"ProtectedInternalNumber = {ProtectedInternalNumber} + PrivateProtectedNumber = {PrivateProtectedNumber}";
        }
    } 
}