using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenVIII
{
    public class Cluts : IDictionary<byte, IColorData[]>
    {
        #region Fields

        private readonly Dictionary<byte, IColorData[]> _clut;

        #endregion Fields

        #region Constructors

        public Cluts(Dictionary<byte, IColorData[]> clut, bool clone = true) => _clut = clone ?
                clut.ToDictionary(id => id.Key, data => (IColorData[])data.Value.Clone()) :
                clut;

        public Cluts(Cluts clut) : this(clut._clut)
        { }

        public Cluts() => _clut = new Dictionary<byte, IColorData[]>();

        #endregion Constructors

        #region Properties

        public IReadOnlyList<byte> ClutIDs => _clut.Keys.OrderBy(x => x).ToList().AsReadOnly();
        public int Count => (_clut as IDictionary<byte, IColorData[]>).Count;
        public bool IsReadOnly => ((IDictionary<byte, IColorData[]>)_clut).IsReadOnly;
        public ICollection<byte> Keys => ((IDictionary<byte, IColorData[]>)_clut).Keys;
        public int MaxColors => _clut.Values.Max(x => x.Length);
        public ICollection<IColorData[]> Values => ((IDictionary<byte, IColorData[]>)_clut).Values;

        public byte MaxClut => Keys.Max(x => x);

        #endregion Properties

        #region Indexers

        public IColorData[] this[byte key]
        {
            get => (_clut as IDictionary<byte, IColorData[]>)[key];
            set => (_clut as IDictionary<byte, IColorData[]>)[key] = value;
        }

        #endregion Indexers

        #region Methods

        public void Add(byte key, IColorData[] value) => (_clut as IDictionary<byte, IColorData[]>).Add(key, value);

        public void Add(KeyValuePair<byte, IColorData[]> item) => ((IDictionary<byte, IColorData[]>)_clut).Add(item);
        
        public void Clear() => (_clut as IDictionary<byte, IColorData[]>).Clear();

        public bool Contains(KeyValuePair<byte, IColorData[]> item) => ((IDictionary<byte, IColorData[]>)_clut).Contains(item);

        public bool ContainsKey(byte key) => (_clut as IDictionary<byte, IColorData[]>).ContainsKey(key);

        public void CopyTo(KeyValuePair<byte, IColorData[]>[] array, int arrayIndex) => ((IDictionary<byte, IColorData[]>)_clut).CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<byte, IColorData[]>> GetEnumerator() => ((IDictionary<byte, IColorData[]>)_clut).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IDictionary<byte, IColorData[]>)_clut).GetEnumerator();

        public bool Remove(byte key) => (_clut as IDictionary<byte, IColorData[]>).Remove(key);

        public bool Remove(KeyValuePair<byte, IColorData[]> item) => ((IDictionary<byte, IColorData[]>)_clut).Remove(item);

        public void Save(string path)
        {
            using (var clutTexture = new Texture2D(Memory.Graphics.GraphicsDevice, MaxColors, MaxClut + 1))
            {
                foreach (var yColors in _clut.OrderBy(x => x.Key))
                {
                    var colors = yColors.Value.GetColors();
                    var y = yColors.Key;
                    clutTexture.SetData(0, new Rectangle(0, y, colors.Length, 1), colors, 0, colors.Length);
                }
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                    clutTexture.SaveAsPng(fs, clutTexture.Width, clutTexture.Height);
            }
        }

        public bool TryGetValue(byte key, out IColorData[] value) =>
            (_clut as IDictionary<byte, IColorData[]>).TryGetValue(key, out value);

        #endregion Methods
    }
}