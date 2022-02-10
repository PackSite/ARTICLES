namespace Demo
{
    using System;
    using BenchmarkDotNet.Attributes;

    [SimpleJob]
    [RankColumn]
    public class Benchmarks
    {
        [Benchmark]
        public void NewGuid()
        {
            Guid.NewGuid();
        }

        [Benchmark]
        public void ToBucket()
        {
            Guid.NewGuid().ToBucket();
        }

        [Benchmark]
        public void ToByte()
        {
            Guid.NewGuid().ToByte();
        }

        [Benchmark]
        public void ToSByte()
        {
            Guid.NewGuid().ToSByte();
        }

        [Benchmark]
        public void ToInt16()
        {
            Guid.NewGuid().ToInt16();
        }

        [Benchmark]
        public void ToUInt16()
        {
            Guid.NewGuid().ToUInt16();
        }

        [Benchmark]
        public void ToInt32()
        {
            Guid.NewGuid().ToInt32();
        }

        [Benchmark]
        public void ToUInt32()
        {
            Guid.NewGuid().ToUInt32();
        }

        [Benchmark]
        public void ToInt64()
        {
            Guid.NewGuid().ToInt64();
        }

        [Benchmark]
        public void ToUInt64()
        {
            Guid.NewGuid().ToUInt64();
        }
    }
}
