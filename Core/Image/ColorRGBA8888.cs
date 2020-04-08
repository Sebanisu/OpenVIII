using Microsoft.Xna.Framework;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenVIII
{
    /// <summary>
    /// Read 32 bit color 8888 RGBA
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 4)]
    public readonly struct ColorRGBA8888 : IColorData
    {
        #region Constructors

        public ColorRGBA8888(byte r, byte g, byte b, byte a) => (Value, R, G, B, A) = (0, r, g, b, a);

        public ColorRGBA8888(BinaryReader br) : this()
        {
            if (br.BaseStream.Position + 4 < br.BaseStream.Length)
            {
                (Value) = (br.ReadUInt32());
            }
        }

        private ColorRGBA8888(uint value, bool ignoreAlpha = false)
        {
            (R, G, B, A, Value) = (0, 0, 0, 0, value);
            if (!ignoreAlpha) return;
            A = byte.MaxValue;
        }

        #endregion Constructors

        #region Properties

        [field: FieldOffset(3)]
        public byte A { get; }

        [field: FieldOffset(2)]
        public byte B { get; }

        [field: FieldOffset(1)]
        public byte G { get; }

        [field: FieldOffset(0)]
        public byte R { get; }

        public bool STP => A > 0;

        [field: FieldOffset(0)]
        public uint Value { get; }

        #endregion Properties

        #region Methods

        public static implicit operator Color(ColorRGBA8888 v) => new Color(v.R, v.G, v.B, v.A);

        public static implicit operator ColorRGBA8888(Color v) => new ColorRGBA8888(v.R, v.G, v.B, v.A);

        public static implicit operator ColorRGBA8888(uint v) => new ColorRGBA8888(v);

        public static implicit operator ColorRGBA8888(ColorABGR1555 v) => new ColorRGBA8888(v.R, v.G, v.B, v.A);

        public static implicit operator ColorRGBA8888(ColorBGRA8888 v) => new ColorRGBA8888(v.R, v.G, v.B, v.A);

        public static implicit operator ColorRGBA8888(ColorBGR888 v) => new ColorRGBA8888(v.R, v.G, v.B, v.A);

        public static implicit operator ColorRGBA8888(ColorRGB888 v) => new ColorRGBA8888(v.R, v.G, v.B, v.A);

        public static implicit operator uint(ColorRGBA8888 v) => v.Value;

        public static IColorData operator -(ColorRGBA8888 value, IColorData other) => value.Subtract(other);

        public static IColorData operator *(ColorRGBA8888 value, float scale) => value.Multiply(scale);

        public static IColorData operator +(ColorRGBA8888 value, IColorData other) => value.Add(other);

        public IColorData Add(IColorData other) => new ColorRGBA8888(Clamp(R + other.R),
            Clamp(G + other.G),
            Clamp(B + other.B),
            Clamp(A + other.A));

        public bool Equals(Color other) => other.PackedValue == Value;

        public bool Equals(IColorData other) => other != null && (R, G, B, A) == (other.R, other.G, other.B, other.A);

        public IColorData Multiply(float scale) => new ColorRGBA8888(Clamp(R * scale),
            Clamp(G * scale),
            Clamp(B * scale),
            Clamp(A * scale));

        public IColorData Subtract(IColorData other) => new ColorRGBA8888(Clamp(R - other.R),
            Clamp(G - other.G),
            Clamp(B - other.B),
            Clamp(A - other.A));

        private static byte Clamp(float b)
            => (byte)MathHelper.Clamp(b, byte.MinValue, byte.MaxValue);

        #endregion Methods
    }
}