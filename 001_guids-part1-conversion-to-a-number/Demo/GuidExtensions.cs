namespace Demo
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// <see cref="Guid"/> extensions.
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Converts <see cref="Guid"/> to uniform bucket identifier (a number in range 0-1023).
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static short ToBucket(this Guid guid)
        {
            // key % 1024; <=> key & ((1 << 10) - 1);

            return (short)(guid.ToUInt32() % 1024);
        }

        /// <summary>
        /// Converts <see cref="Guid"/> to <see cref="sbyte"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static sbyte ToSByte(this Guid guid)
        {
            return unchecked((sbyte)guid.ToByte());
        }

        /// <summary>
        /// Converts <see cref="Guid"/> to <see cref="short"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static short ToInt16(this Guid guid)
        {
            return unchecked((short)guid.ToUInt16());
        }

        /// <summary>
        /// Converts <see cref="Guid"/> to <see cref="int"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static int ToInt32(this Guid guid)
        {
            return unchecked((int)guid.ToUInt32());
        }

        /// <summary>
        /// Converts <see cref="Guid"/> to <see cref="long"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static long ToInt64(this Guid guid)
        {
            return unchecked((long)guid.ToUInt64());
        }

        /// <summary>
        /// Converts <see cref="Guid"/> to <see cref="byte"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static byte ToByte(this Guid guid)
        {
            return (byte)(guid.ToUInt32() % 0xff);
        }

        // <summary>
        /// Converts <see cref="Guid"/> to <see cref="ushort"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static ushort ToUInt16(this Guid guid)
        {
            return (ushort)(guid.ToUInt32() % 0xffff);
        }

        /// <summary>
        /// Converts <see cref="Guid"/> to <see cref="ulong"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static uint ToUInt32(this Guid guid)
        {
            Span<byte> bytes = stackalloc byte[16];
            guid.TryWriteBytes(bytes);

            uint chunk0 = MemoryMarshal.Read<uint>(bytes.Slice(0, 4));
            uint chunk1 = MemoryMarshal.Read<uint>(bytes.Slice(4, 4));
            uint chunk2 = MemoryMarshal.Read<uint>(bytes.Slice(8, 4));
            uint chunk3 = MemoryMarshal.Read<uint>(bytes.Slice(12, 4));

            unchecked
            {
                return chunk0 + chunk1 + chunk2 + chunk3;
            }
        }

        /// <summary>
        /// Converts <see cref="Guid"/> to <see cref="ulong"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static ulong ToUInt64(this Guid guid)
        {
            Span<byte> bytes = stackalloc byte[16];
            guid.TryWriteBytes(bytes);

            ulong chunk0 = MemoryMarshal.Read<ulong>(bytes.Slice(0, 8));
            ulong chunk1 = MemoryMarshal.Read<ulong>(bytes.Slice(8, 8));

            unchecked
            {
                return chunk0 + chunk1;
            }
        }
    }
}
