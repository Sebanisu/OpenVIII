using System;
using System.Collections.Generic;
using System.Linq;
using FFmpeg.AutoGen;
using Microsoft.Xna.Framework;

namespace OpenVIII
{
    public interface IColorData : IEquatable<Color>, IEquatable<IColorData>
    {
        #region Properties

        byte A { get; }
        byte B { get; }
        byte G { get; }
        byte R { get; }
        bool STP { get; }

        #endregion Properties

        IColorData Multiply(float scale);

        IColorData Add(IColorData other);

        IColorData Subtract(IColorData other);
    }
    public static class ColorDataExt
    {
        public static IColorData Multiply(this IColorData value, float scale)
        {
            return value.Multiply(scale);
        }
        public static IColorData Add(this IColorData value, IColorData other)
        {
            return value.Add(other);
        }

        public static IColorData Subtract(this IColorData value, IColorData other)
        {
            return value.Subtract(other);
        }

        public static Color GetColor(this IColorData other)
        {
            return (other == null) ?Color.TransparentBlack :new Color(other.R,other.G,other.B,other.A);
        }

        public static Color[] GetColors(this IEnumerable<IColorData> other)
        {
            return other.Select(x => x.GetColor()).ToArray();
        }
    }
}