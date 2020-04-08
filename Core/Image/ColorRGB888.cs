using System;
using Microsoft.Xna.Framework;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenVIII
{
    /// <summary>
    /// Read 32 bit color 888 RGB
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0)]
    [Serializable]
    public readonly struct ColorRGB888 : IColorData
    {
        #region Constructors

        public ColorRGB888(BinaryReader br) : this()
        {
            if (br.BaseStream.Position + 3 < br.BaseStream.Length)
            {
                (R, B, G) = (br.ReadByte(), br.ReadByte(), br.ReadByte());
            }
        }

        public ColorRGB888(byte r, byte g, byte b) => (R, B, G) = (r, b, g);

        #endregion Constructors

        #region Properties

        public byte A => 0xFF;

        [field: FieldOffset(2)]
        public byte B { get; }

        [field: FieldOffset(1)]
        public byte G { get; }

        [field: FieldOffset(0)]
        public byte R { get; }

        public bool STP => false;

        #endregion Properties

        #region Methods

        public static implicit operator Color(ColorRGB888 v) => new Color(v.R, v.G, v.B, v.A);

        public static implicit operator ColorRGB888(Color v) => new ColorRGB888(v.R, v.G, v.B);

        public static implicit operator ColorRGB888(ColorBGRA8888 v) => new ColorRGB888(v.R, v.G, v.B);

        public static implicit operator ColorRGB888(ColorABGR1555 v) => new ColorRGB888(v.R, v.G, v.B);

        public static implicit operator ColorRGB888(ColorBGR888 v) => new ColorRGB888(v.R, v.G, v.B);

        public static IColorData operator -(ColorRGB888 value, IColorData other) => value.Subtract(other);

        public static IColorData operator *(ColorRGB888 value, float scale) => value.Multiply(scale);

        public static IColorData operator +(ColorRGB888 value, IColorData other) => value.Add(other);

        public IColorData Add(IColorData other) => new ColorRGB888(
            Clamp(R + other.R),
            Clamp(G + other.G),
            Clamp(B + other.B)
        );

        public bool Equals(Color other) => (R, B, G, A) == (other.R, other.B, other.G, other.A);

        public bool Equals(IColorData other) => other != null && (R, B, G, A) == (other.R, other.B, other.G, other.A);

        public IColorData Multiply(float scale) => new ColorRGB888(
            Clamp(R * scale),
            Clamp(G * scale),
            Clamp(B * scale)
        );

        public IColorData Subtract(IColorData other) => new ColorRGB888(
                                    Clamp(R - other.R),
            Clamp(G - other.G),
            Clamp(B - other.B)
        );

        private static byte Clamp(float b)
            => (byte)MathHelper.Clamp(b, byte.MinValue, byte.MaxValue);

        #endregion Methods
    }
}