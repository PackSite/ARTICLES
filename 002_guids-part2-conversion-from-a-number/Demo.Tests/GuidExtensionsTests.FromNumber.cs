namespace Demo.Tests
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class GuidExtensionsTests
    {
        [Theory]
        [InlineData(sbyte.MinValue)]
        [InlineData(sbyte.MaxValue)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-123)]
        [InlineData(123)]
        public void SByteToGuid(sbyte value)
        {
            Guid guid = value.ToGuid();

            guid.ToSByte().Should().Be(value);
        }

        [Theory]
        [InlineData(byte.MinValue)]
        [InlineData(byte.MaxValue)]
        [InlineData(1)]
        [InlineData(123)]
        public void ByteToGuid(byte value)
        {
            Guid guid = value.ToGuid();

            guid.ToByte().Should().Be(value);
        }

        [Theory]
        [InlineData(short.MinValue)]
        [InlineData(short.MaxValue)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-12345)]
        [InlineData(12345)]
        public void Int16ToGuid(short value)
        {
            Guid guid = value.ToGuid();

            guid.ToInt16().Should().Be(value);
        }

        [Theory]
        [InlineData(ushort.MinValue)]
        [InlineData(ushort.MaxValue)]
        [InlineData(1)]
        [InlineData(12345)]
        public void UInt16ToGuid(ushort value)
        {
            Guid guid = value.ToGuid();

            guid.ToUInt16().Should().Be(value);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1234567)]
        [InlineData(1234567)]
        public void Int32ToGuid(int value)
        {
            Guid guid = value.ToGuid();

            guid.ToInt32().Should().Be(value);
        }

        [Theory]
        [InlineData(uint.MinValue)]
        [InlineData(uint.MaxValue)]
        [InlineData(1)]
        public void UInt32ToGuid(uint value)
        {
            Guid guid = value.ToGuid();

            guid.ToUInt32().Should().Be(value);
        }

        [Theory]
        [InlineData(long.MinValue)]
        [InlineData(long.MaxValue)]
        [InlineData(-1)]
        [InlineData(0ul)]
        [InlineData(1ul)]
        public void Int64ToGuid(long value)
        {
            Guid guid = value.ToGuid();

            guid.ToInt64().Should().Be(value);
        }

        [Theory]
        [InlineData(ulong.MinValue)]
        [InlineData(ulong.MaxValue)]
        [InlineData(1ul)]
        public void UInt64ToGuid(ulong value)
        {
            Guid guid = value.ToGuid();

            guid.ToUInt64().Should().Be(value);

            guid.ToUInt64(out ulong lower, out ulong upper);
            lower.Should().Be(value);
            upper.Should().Be(0);
        }
    }
}