using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace OpenVIII
{
    public class Texture2DWrapper : ITextureBase
    {
        #region Fields

        private Texture2D _tex;

        #endregion Fields

        #region Constructors

        public Texture2DWrapper(Texture2D tex) => _tex = tex;

        #endregion Constructors

        #region Properties

        public byte GetBytesPerPixel => 4;

        public byte GetClutCount => 0;

        public byte GetClutSize => 0;

        public byte GetColorsCountPerPalette => 0;

        public int GetHeight => _tex?.Height ?? 0;

        public int GetOrigX => 0;

        public int GetOrigY => 0;

        public int GetWidth => _tex?.Width ?? 0;

        #endregion Properties

        #region Methods

        public static implicit operator Texture2D(Texture2DWrapper right) => right._tex;

        public static implicit operator Texture2DWrapper(Texture2D right) => new Texture2DWrapper(right);

        public void ForceSetClutColors(byte newNumOfColors)
        {
        }

        public void ForceSetClutCount(byte newClut)
        {
        }

        public Color[] GetClutColors(byte clut) => null;
        public Texture2D GetTexture(Dictionary<int, Color> colorOverride, sbyte clut = -1)
        {
            throw new System.NotImplementedException();
        }

        public Texture2D GetTexture() => _tex;

        public Texture2D GetTexture(Color[] colors) => _tex;

        public Texture2D GetTexture(byte clut) => _tex;

        public void Load(byte[] buffer, uint offset = 0) => throw new System.NotImplementedException("This class must use Load(Texture2D)");

        public void Load(Texture2D inputTex) => _tex = inputTex;

        public void Save(string path)
        {
            using (var fs = File.Create(path))
                _tex.SaveAsPng(fs, _tex.Width, _tex.Height);
        }

        public void SaveClut(string path)
        { // no clut data.
        }

        public void SavePNG(string path, short clut = -1)
        {
            throw new System.NotImplementedException();
        }

        #endregion Methods
    }
}