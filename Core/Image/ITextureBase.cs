using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenVIII
{
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public interface ITextureBase
    {
        #region Properties

        byte GetBytesPerPixel { get; }
        byte GetClutCount { get; }
        uint GetClutSize { get; }
        byte GetColorsCountPerPalette { get; }
        int GetHeight { get; }
        int GetOrigX { get; }
        int GetOrigY { get; }
        int GetWidth { get; }

        #endregion Properties

        #region Methods

        void ForceSetClutColors(byte newNumOfColors);

        void ForceSetClutCount(byte newClut);

        IColorData[] GetClutColors(byte clut);

        Texture2D GetTexture(Dictionary<int, IColorData> colorOverride, sbyte clut = -1);

        Texture2D GetTexture(IColorData[] colors);

        Texture2D GetTexture(byte clut);

        Texture2D GetTexture();

        void Load(byte[] buffer, uint offset = 0);

        void Save(string path);

        void SaveClut(string path);

        void SavePNG(string path, short clut = -1);

        #endregion Methods
    }
}