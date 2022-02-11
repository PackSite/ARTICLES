namespace Demo
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    public static partial class GuidExtensions
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
            Span<byte> bytes = stackalloc byte[16];
            guid.TryWriteBytes(bytes);

            return (byte)(
                bytes[0] ^
                bytes[1] ^
                bytes[2] ^
                bytes[3] ^
                bytes[4] ^
                bytes[5] ^
                bytes[6] ^
                bytes[7] ^
                bytes[8] ^
                bytes[9] ^
                bytes[10] ^
                bytes[11] ^
                bytes[12] ^
                bytes[13] ^
                bytes[14] ^
                bytes[15]);
        }


        // <summary>
        /// Converts <see cref="Guid"/> to <see cref="ushort"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static ushort ToUInt16(this Guid guid)
        {
            Span<byte> bytes = stackalloc byte[16];
            guid.TryWriteBytes(bytes);

            ushort chunk0 = (ushort)(bytes[0] | (bytes[1] << 8));
            ushort chunk1 = (ushort)(bytes[2] | (bytes[3] << 8));
            ushort chunk2 = (ushort)(bytes[4] | (bytes[5] << 8));
            ushort chunk3 = (ushort)(bytes[6] | (bytes[7] << 8));
            ushort chunk4 = (ushort)(bytes[8] | (bytes[9] << 8));
            ushort chunk5 = (ushort)(bytes[10] | (bytes[11] << 8));
            ushort chunk6 = (ushort)(bytes[12] | (bytes[13] << 8));
            ushort chunk7 = (ushort)(bytes[14] | (bytes[15] << 8));

            unchecked
            {
                return (ushort)(chunk0 ^ chunk1 ^ chunk2 ^ chunk3 ^ chunk4 ^ chunk5 ^ chunk6 ^ chunk7);
            }
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

            uint chunk0 = (uint)(bytes[0] | (bytes[1] << 8) | (bytes[2] << 16) | (bytes[3] << 24));
            uint chunk1 = (uint)(bytes[4] | (bytes[5] << 8) | (bytes[6] << 16) | (bytes[7] << 24));
            uint chunk2 = (uint)(bytes[8] | (bytes[9] << 8) | (bytes[10] << 16) | (bytes[11] << 24));
            uint chunk3 = (uint)(bytes[12] | (bytes[13] << 8) | (bytes[14] << 16) | (bytes[15] << 24));

            unchecked
            {
                return chunk0 ^ chunk1 ^ chunk2 ^ chunk3;
            }
        }

        /// <summary>
        /// Converts <see cref="Guid"/> to <see cref="ulong"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [SuppressMessage("Style", "IDE0057:Use range operator")]
        public static ulong ToUInt64(this Guid guid)
        {
            Span<byte> bytes = stackalloc byte[16];
            guid.TryWriteBytes(bytes);

            ulong chunk0 = MemoryMarshal.Read<ulong>(bytes.Slice(0, 8));
            ulong chunk1 = MemoryMarshal.Read<ulong>(bytes.Slice(8, 8));

            unchecked
            {
                return chunk0 ^ chunk1;
            }
        }

        /// <summary>
        /// Converts <see cref="Guid"/> to <see cref="ulong"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [SuppressMessage("Style", "IDE0057:Use range operator")]
        public static void ToUInt64(this Guid guid, out ulong lower, out ulong upper)
        {
            Span<byte> bytes = stackalloc byte[16];
            guid.TryWriteBytes(bytes);

            lower = MemoryMarshal.Read<ulong>(bytes.Slice(0, 8));
            upper = MemoryMarshal.Read<ulong>(bytes.Slice(8, 8));
        }
    }
}
