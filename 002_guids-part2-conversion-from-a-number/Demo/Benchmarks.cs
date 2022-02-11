namespace Demo
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using BenchmarkDotNet.Attributes;

    [SimpleJob, RankColumn]
    [SuppressMessage("Performance", "CA1822:Mark members as static")]
    public class Benchmarks
    {
        [Benchmark]
        public void NewGuid()
        {
            Guid.NewGuid();
        }

        [Benchmark]
        public void GuidToBucket()
        {
            Guid.NewGuid().ToBucket();
        }

        [Benchmark]
        public void GuidToByte()
        {
            Guid.NewGuid().ToByte();
        }

        [Benchmark]
        public void GuidToSByte()
        {
            Guid.NewGuid().ToSByte();
        }

        [Benchmark]
        public void GuidToInt16()
        {
            Guid.NewGuid().ToInt16();
        }

        [Benchmark]
        public void GuidToUInt16()
        {
            Guid.NewGuid().ToUInt16();
        }

        [Benchmark]
        public void GuidToInt32()
        {
            Guid.NewGuid().ToInt32();
        }

        [Benchmark]
        public void GuidToUInt32()
        {
            Guid.NewGuid().ToUInt32();
        }

        [Benchmark]
        public void GuidToInt64()
        {
            Guid.NewGuid().ToInt64();
        }

        [Benchmark]
        public void GuidToUInt64()
        {
            Guid.NewGuid().ToUInt64();
        }

        [Benchmark]
        public void ByteToGuid()
        {
            byte.MaxValue.ToGuid();
        }

        [Benchmark]
        public void SByteToGuid()
        {
            sbyte.MaxValue.ToGuid();
        }

        [Benchmark]
        public void Int16ToGuid()
        {
            short.MaxValue.ToGuid();
        }

        [Benchmark]
        public void UInt16ToGuid()
        {
            ushort.MaxValue.ToGuid();
        }

        [Benchmark]
        public void Int32ToGuid()
        {
            int.MaxValue.ToGuid();
        }

        [Benchmark]
        public void UInt32ToGuid()
        {
            uint.MaxValue.ToGuid();
        }

        [Benchmark]
        public void Int64ToGuid()
        {
            long.MaxValue.ToGuid();
        }

        [Benchmark]
        public void UInt64ToGuid()
        {
            ulong.MaxValue.ToGuid();
        }
    }
}
