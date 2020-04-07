using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenVIII
{
    public class ClutsRGBA : IDictionary<byte, Color[]>, ICluts
    {
        #region Fields

        private readonly Dictionary<byte, Color[]> _clut;

        #endregion Fields

        #region Constructors

        public ClutsRGBA(Dictionary<byte, Color[]> clut, bool clone = true) => _clut = clone ?
                clut.ToDictionary(id => id.Key, colors => (Color[])colors.Value.Clone()) :
                clut;

        public ClutsRGBA(ClutsRGBA clutRgba) : this(clutRgba._clut)
        { }

        public ClutsRGBA() => _clut = new Dictionary<byte, Color[]>();

        #endregion Constructors

        #region Properties

        public IReadOnlyList<byte> ClutIDs => _clut.Keys.OrderBy(x => x).ToList().AsReadOnly();
        public int Count => (_clut as IDictionary<byte, Color[]>).Count;
        public bool IsReadOnly => ((IDictionary<byte, Color[]>)_clut).IsReadOnly;
        public ICollection<byte> Keys => ((IDictionary<byte, Color[]>)_clut).Keys;
        public int MaxColors => _clut.Values.Max(x => x.Length);
        public ICollection<Color[]> Values => ((IDictionary<byte, Color[]>)_clut).Values;

        public byte MaxClut => Keys.Max(x => x);

        #endregion Properties

        #region Indexers

        public Color[] this[byte key]
        {
            get => (_clut as IDictionary<byte, Color[]>)[key];
            set => (_clut as IDictionary<byte, Color[]>)[key] = value;
        }

        #endregion Indexers

        #region Methods

        public void Add(byte key, Color[] value) => (_clut as IDictionary<byte, Color[]>).Add(key, value);

        public void Add(KeyValuePair<byte, Color[]> item) => ((IDictionary<byte, Color[]>)_clut).Add(item);

        public void Add(byte b, IReadOnlyList<ColorABGR1555> colors) => Add(b, colors.Select(x => (Color)x).ToArray());

        public void Clear() => (_clut as IDictionary<byte, Color[]>).Clear();

        public bool Contains(KeyValuePair<byte, Color[]> item) => ((IDictionary<byte, Color[]>)_clut).Contains(item);

        public bool ContainsKey(byte key) => (_clut as IDictionary<byte, Color[]>).ContainsKey(key);

        public void CopyTo(KeyValuePair<byte, Color[]>[] array, int arrayIndex) => ((IDictionary<byte, Color[]>)_clut).CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<byte, Color[]>> GetEnumerator() => ((IDictionary<byte, Color[]>)_clut).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IDictionary<byte, Color[]>)_clut).GetEnumerator();

        public bool Remove(byte key) => (_clut as IDictionary<byte, Color[]>).Remove(key);

        public bool Remove(KeyValuePair<byte, Color[]> item) => ((IDictionary<byte, Color[]>)_clut).Remove(item);

        public void Save(string path)
        {
            using (var clutTexture = new Texture2D(Memory.Graphics.GraphicsDevice, MaxColors, MaxClut + 1))
            {
                foreach (var yColors in _clut.OrderBy(x => x.Key))
                {
                    var colors = yColors.Value;
                    var y = yColors.Key;
                    clutTexture.SetData(0, new Rectangle(0, y, colors.Length, 1), colors, 0, colors.Length);
                }
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                    clutTexture.SaveAsPng(fs, clutTexture.Width, clutTexture.Height);
            }
        }

        public bool TryGetValue(byte key, out Color[] value) =>
            (_clut as IDictionary<byte, Color[]>).TryGetValue(key, out value);

        #endregion Methods
    }
}