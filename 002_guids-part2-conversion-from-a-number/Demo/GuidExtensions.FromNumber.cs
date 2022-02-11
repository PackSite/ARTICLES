namespace Demo
{
    using System;

    public static partial class GuidExtensions
    {
        /// <summary>
        /// Converts <see cref="sbyte"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this sbyte value)
        {
            unchecked
            {
                return ((byte)value).ToGuid();
            }
        }

        /// <summary>
        /// Converts <see cref="byte"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this byte value)
        {
            Span<byte> bytes = stackalloc byte[16];
            bytes[0] = value;

            return new Guid(bytes);
        }

        /// <summary>
        /// Converts <see cref="short"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this short value)
        {
            unchecked
            {
                return ((ushort)value).ToGuid();
            }
        }

        /// <summary>
        /// Converts <see cref="ushort"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this ushort value)
        {
            byte[] v = BitConverter.GetBytes(value);

            Span<byte> bytes = stackalloc byte[16];
            bytes[0] = v[0];
            bytes[1] = v[1];
            // 0 for bytes 2-15

            return new Guid(bytes);
        }

        /// <summary>
        /// Converts <see cref="int"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this int value)
        {
            unchecked
            {
                return ((uint)value).ToGuid();
            }
        }

        /// <summary>
        /// Converts <see cref="uint"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this uint value)
        {
            byte[] v = BitConverter.GetBytes(value);

            Span<byte> bytes = stackalloc byte[16];
            bytes[0] = v[0];
            bytes[1] = v[1];
            bytes[2] = v[2];
            bytes[3] = v[3];
            // 0 for bytes 4-15

            return new Guid(bytes);
        }

        /// <summary>
        /// Converts <see cref="long"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this long value)
        {
            unchecked
            {
                return ((ulong)value).ToGuid();
            }
        }

        /// <summary>
        /// Converts <see cref="ulong"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this ulong value)
        {
            byte[] v = BitConverter.GetBytes(value);

            Span<byte> bytes = stackalloc byte[16];
            bytes[0] = v[0];
            bytes[1] = v[1];
            bytes[2] = v[2];
            bytes[3] = v[3];
            bytes[4] = v[4];
            bytes[5] = v[5];
            bytes[6] = v[6];
            bytes[7] = v[7];
            // 0 for bytes 8-15

            return new Guid(bytes);
        }
    }
}
