using System.IO;
using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;

namespace OpenVIII
{
    /// <summary>
    /// Read 16 bit color. 1555 ABGR
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/windows/win32/directshow/working-with-16-bit-rgb"/>
    /// <seealso cref="https://mrclick.zophar.net/TilEd/download/timgfx.txt"/>
    /// <seealso cref="http://hitmen.c02.at/files/docs/psx/gpu.txt"/>
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 2)]
    public readonly struct ColorABGR1555 : IColorData
    {
        #region Fields

        /// <summary>
        /// blue bits
        /// </summary>
        private const ushort BlueMask = 0x7C00;

        private const byte BlueShift = 10;

        /// <summary>
        /// green bits
        /// </summary>
        private const ushort GreenMask = 0x3E0;

        private const byte GreenShift = 5;

        //private const double Coefficient = 255d / 31d;
        //private const double RevCoefficient = 31d / 255d;
        private const byte Mask5Bit = 0x1F;

        /// <summary>
        /// all bits except the STP bit.
        /// </summary>
        private const ushort NotSTPMask = 0x7FFF;

        /// <summary>
        /// red bits
        /// </summary>
        private const ushort RedMask = 0x1F;

        private const byte Shift5Bit = 3;

        /// <summary>
        /// STP bit.
        /// </summary>
        private const ushort STPMask = 0x8000;

        #endregion Fields

        #region Constructors

        public ColorABGR1555(BinaryReader br) : this()
        {
            if (br.BaseStream.Position + 4 < br.BaseStream.Length)
            {
                (Value) = (br.ReadUInt16());
            }
        }

        public ColorABGR1555(ushort value, bool ignoreAlpha = false)
        {
            Value = value;
            if (!ignoreAlpha) return;
            Value = value == 0
                ? STPMask
                : (ushort)(value & NotSTPMask);
        }

        public ColorABGR1555(byte r, byte g, byte b, byte a)
        {
            //could be wrong
            var stp = a > 0 && r + g + b == 0 || a == 0 && r + g + b > 0
                ? STPMask
                : (ushort)0;

            Value = (ushort)((To(b) << BlueShift) | (To(g) << GreenShift) | To(r) | stp);
        }

        #endregion Constructors

        #region Properties

        public byte A => Value > 0 ? byte.MaxValue : byte.MinValue;

        public byte B => From((byte)((Value & BlueMask) >> BlueShift));

        public byte G => From((byte)((Value & GreenMask) >> GreenShift));

        public byte R => From((byte)(Value & RedMask));

        public bool STP => (Value & NotSTPMask) != 0 && (Value & STPMask) != 0;

        [field: FieldOffset(0)]
        public ushort Value { get; }

        #endregion Properties

        #region Methods

        public static implicit operator Color(ColorABGR1555 v) => new Color(v.R, v.G, v.B, v.A);

        public static implicit operator ColorABGR1555(Color v) => new ColorABGR1555(v.R, v.G, v.B, v.A);

        public static implicit operator ColorABGR1555(ushort v) => new ColorABGR1555(v);

        public static implicit operator ColorABGR1555(ColorBGRA8888 v) => new ColorABGR1555(v.R, v.G, v.B, v.A);

        public static implicit operator ColorABGR1555(ColorRGBA8888 v) => new ColorABGR1555(v.R, v.G, v.B, v.A);

        public static implicit operator ushort(ColorABGR1555 v) => v.Value;

        public static IColorData operator -(ColorABGR1555 value, IColorData other) => value.Subtract(other);

        public static IColorData operator *(ColorABGR1555 value, float scale) => value.Multiply(scale);

        public static IColorData operator +(ColorABGR1555 value, IColorData other) => value.Add(other);

        public IColorData Add(IColorData other) => new ColorABGR1555(
                Clamp(R + other.R),
                Clamp(G + other.G),
                Clamp(B + other.B),
                Clamp(A + other.A));

        public bool Equals(Color other) => other.A == A && other.B == B && other.G == G && other.R == R;

        public bool Equals(IColorData other) => other != null && (R, G, B, A) == (other.R, other.G, other.B, other.A);

        public IColorData Multiply(float scale) => new ColorABGR1555(
                Clamp(R * scale),
                Clamp(G * scale),
                Clamp(B * scale),
                Clamp(A * scale));

        public IColorData Subtract(IColorData other) => new ColorABGR1555(
                                    Clamp(R - other.R),
            Clamp(G - other.G),
            Clamp(B - other.B),
            Clamp(A - other.A));

        private static byte Clamp(float b)
            => (byte)MathHelper.Clamp(b, byte.MinValue, byte.MaxValue);

        private static byte From(byte c)
        {
            var val5Bit = (c & Mask5Bit); // masks off the lower 5 bits.
            return (byte)((val5Bit << Shift5Bit) + (val5Bit >> 2));// stretch to bring max value to 255;
        }

        private static byte To(byte c) => (byte)((c >> Shift5Bit) & Mask5Bit);

        #endregion Methods

        //(byte)((byte)Math.Round(c * RevCoefficient) & Mask5Bit);
    }
}