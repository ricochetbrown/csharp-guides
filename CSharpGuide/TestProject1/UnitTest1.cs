using System;
using JetBrains.dotMemoryUnit;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1
{
    [DotMemoryUnit(Directory = "c:\\Temp\\dotMemoryUnit")]
    public class UnitTest1
    {
        public UnitTest1(ITestOutputHelper outputHelper)
        {
            DotMemoryUnitTestOutput.SetOutputMethod(message => outputHelper.WriteLine(message));
        }
        
        [Fact]
        public void Test1()
        {
            var refClass = new RefClass
            {
                Float1 = 1F / 3,
                Double1 = 1D / 3,
                Decimal1 = 1M / 3
            };

            dotMemory.Check(memory =>
            {
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<RefClass>()).ObjectsCount);                
            });

            var refClass2 = refClass;
            refClass2.Float1 = 1F / 4;
            
            dotMemory.Check(memory =>
            {
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<RefClass>()).ObjectsCount);      
            });

            var refClass3 = new RefClass
            {
                Decimal1 = 1M / 5
            };
            
            dotMemory.Check(memory =>
            {
                Assert.Equal(2, memory.GetObjects(where => where.Type.Is<RefClass>()).ObjectsCount);      
            });
        }
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

    class RefClass
    {
        public float Float1;
        public double Double1;
        public decimal Decimal1;
    }
}