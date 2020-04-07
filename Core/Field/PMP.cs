using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Linq;

namespace OpenVIII.Fields
{
    /// <summary>
    /// Particle Texture
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/FileFormat_PMP"/>
    public sealed class PMP : ITextureBase
    {
        #region Fields

        private byte[] _buffer;
        private Cluts1555ABGR _clut;

        #endregion Fields

        #region Constructors

        public PMP(byte[] pmpB) => Load(pmpB);

        #endregion Constructors

        #region Properties

        public byte GetBytesPerPixel => 4;

        public byte GetClutCount => 16;

        public byte GetClutSize => 16;

        public byte GetColorsCountPerPalette => 16;

        public int GetHeight { get; private set; }

        public int GetOrigX => 0;

        public int GetOrigY => 0;

        public int GetWidth { get; private set; }

        public byte[] Unknown { get; set; }

        #endregion Properties

        #region Methods

        public void ForceSetClutColors(byte newNumOfColors) => throw new System.NotImplementedException();

        public void ForceSetClutCount(byte newClut) => throw new System.NotImplementedException();

        public Color[] GetClutColors(byte clut) => _clut[clut].Select(x => (Color)x).ToArray();
 
        public Texture2D GetTexture(Dictionary<int, Color> colorOverride, sbyte clut = -1)
        {
            throw new System.NotImplementedException();
        }

        public Texture2D GetTexture() => GetTexture(0);

        public Texture2D GetTexture(Color[] colors)
        {
            var tex = new Texture2D(Memory.Graphics.GraphicsDevice, GetWidth, GetHeight);
            var textureBuffer = new TextureBuffer(GetWidth, GetHeight, false);
            var i = 0;
            foreach (var b in _buffer)
                textureBuffer[i++] = colors[b];
            textureBuffer.SetData(tex);
            return tex;
        }

        public Texture2D GetTexture(byte clut) => GetTexture(GetClutColors(clut));
        public void Load(byte[] buffer, uint offset = 0)
        {
            if (buffer.Length - offset <= 4) return;
            _clut = new Cluts1555ABGR();
            MemoryStream ms;
            using (var br = new BinaryReader(ms = new MemoryStream(buffer)))
            {
                ms.Seek(offset, SeekOrigin.Begin);//unknown
                Unknown = br.ReadBytes(4);
                foreach (var i in Enumerable.Range(0, 16))
                {
                    var colors = Enumerable.Range(0, 16).Select(_ => new ColorABGR1555(br.ReadUInt16()))
                        .ToArray();
                    _clut.Add((byte)i, colors);
                }

                var size = ms.Length - ms.Position;
                GetHeight = checked((int)(size / 128));
                GetWidth = checked((int)(size / GetHeight));
                _buffer = br.ReadBytes(checked((int)size));
            }
        }

        public void Save(string path) => throw new System.NotImplementedException();

        public void SaveClut(string path) => _clut.Save(path);
        public void SavePNG(string path, short clut = -1)
        {
            foreach (var texOut in _clut.Select(i => new {i.Key, Value = GetClutColors(i.Key)})
                .Select(x => new {x.Key, Value = GetTexture(x.Value)}))
            {
                using (texOut.Value)
                {
                    var loPath = $"{path}_{texOut.Key}.png";
                    using (var fs = new FileStream(loPath,FileMode.Create,FileAccess.Write,FileShare.ReadWrite))
                    {
                        texOut.Value.SaveAsPng(fs,texOut.Value.Width,texOut.Value.Height);
                    }
                }
            }
        }

        #endregion Methods
    }
}