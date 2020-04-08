using Microsoft.Xna.Framework;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenVIII
{
    /// <summary>
    /// Read 32 bit color 8888 BGRA
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 4)]
    public readonly struct ColorBGRA8888 : IColorData
    {
        #region Constructors

        public ColorBGRA8888(BinaryReader br) : this()
        {
            if (br.BaseStream.Position + 4 < br.BaseStream.Length)
            {
                (Value) = (br.ReadUInt32());
            }
        }

        public ColorBGRA8888(uint value, bool ignoreAlpha = false) : this()
        {
            (Value) = (value);
            if (!ignoreAlpha) return;
            A = byte.MaxValue;
        }

        public ColorBGRA8888(byte r, byte g, byte b, byte a) : this() => (R, G, B, A) = (r, g, b, a);

        #endregion Constructors

        #region Properties

        [field: FieldOffset(3)]
        public byte A { get; }

        [field: FieldOffset(0)]
        public byte B { get; }

        [field: FieldOffset(1)]
        public byte G { get; }

        [field: FieldOffset(2)]
        public byte R { get; }

        public bool STP => A > 0;

        [field: FieldOffset(0)]
        public uint Value { get; }

        #endregion Properties

        #region Methods

        public static implicit operator Color(ColorBGRA8888 v) => new Color(v.R, v.G, v.B, v.A);

        public static implicit operator ColorBGRA8888(Color v) => new ColorBGRA8888(v.R, v.G, v.B, v.A);

        public static implicit operator ColorBGRA8888(uint v) => new ColorBGRA8888(v);

        public static implicit operator ColorBGRA8888(ColorABGR1555 v) => new ColorBGRA8888(v.R, v.G, v.B, v.A);

        public static implicit operator ColorBGRA8888(ColorRGBA8888 v) => new ColorBGRA8888(v.R, v.G, v.B, v.A);

        public static implicit operator ColorBGRA8888(ColorBGR888 v) => new ColorBGRA8888(v.R, v.G, v.B, v.A);

        public static implicit operator ColorBGRA8888(ColorRGB888 v) => new ColorBGRA8888(v.R, v.G, v.B, v.A);

        public static implicit operator uint(ColorBGRA8888 v) => v.Value;

        public static IColorData operator -(ColorBGRA8888 value, IColorData other) => value.Subtract(other);

        public static IColorData operator *(ColorBGRA8888 value, float scale) => value.Multiply(scale);

        public static IColorData operator +(ColorBGRA8888 value, IColorData other) => value.Add(other);

        public IColorData Add(IColorData other) => new ColorBGRA8888(
                Clamp(R + other.R),
                Clamp(G + other.G),
                Clamp(B + other.B),
                Clamp(A + other.A));

        public bool Equals(Color other) => other.PackedValue == Value;

        public bool Equals(IColorData other) => other != null && (R, G, B, A) == (other.R, other.G, other.B, other.A);

        public IColorData Multiply(float scale) => new ColorBGRA8888(
                Clamp(R * scale),
                Clamp(G * scale),
                Clamp(B * scale),
                Clamp(A * scale));

        public IColorData Subtract(IColorData other) => new ColorBGRA8888(
                                    Clamp(R - other.R),
            Clamp(G - other.G),
            Clamp(B - other.B),
            Clamp(A - other.A));

        private static byte Clamp(float b)
            => (byte)MathHelper.Clamp(b, byte.MinValue, byte.MaxValue);

        #endregion Methods
    }
}