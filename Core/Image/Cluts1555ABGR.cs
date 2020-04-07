using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenVIII
{
    public class Cluts1555ABGR : IDictionary<byte, ColorABGR1555[]>, ICluts
    {
        #region Fields

        private readonly Dictionary<byte, ColorABGR1555[]> _clut;

        #endregion Fields

        #region Constructors

        public Cluts1555ABGR() => _clut = new Dictionary<byte, ColorABGR1555[]>();
        public Cluts1555ABGR(Dictionary<byte, ColorABGR1555[]> clut) => _clut = clut;

        #endregion Constructors

        #region Properties

        public int Count => _clut.Count;

        public bool IsReadOnly => ((IDictionary<byte, ColorABGR1555[]>)_clut).IsReadOnly;

        public ICollection<byte> Keys => ((IDictionary<byte, ColorABGR1555[]>)_clut).Keys;

        public ICollection<ColorABGR1555[]> Values => ((IDictionary<byte, ColorABGR1555[]>)_clut).Values;

        #endregion Properties

        #region Indexers

        public ColorABGR1555[] this[byte key]
        {
            get => _clut[key];
            set => _clut[key] = value;
        }

        #endregion Indexers

        #region Methods

        public void Add(KeyValuePair<byte, ColorABGR1555[]> item) => _clut.Add(item.Key, item.Value);

        public void Add(byte key, ColorABGR1555[] value) => _clut.Add(key, value);

        public void Clear() => _clut.Clear();

        public bool Contains(KeyValuePair<byte, ColorABGR1555[]> item) => _clut.Contains(item);
        public void CopyTo(KeyValuePair<byte, ColorABGR1555[]>[] array, int arrayIndex)
        {
            ((IDictionary<byte,ColorABGR1555[]>)_clut)?.CopyTo(array, arrayIndex);
        }

        public bool ContainsKey(byte key) => _clut.ContainsKey(key);



        public IEnumerator<KeyValuePair<byte, ColorABGR1555[]>> GetEnumerator() => _clut.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_clut).GetEnumerator();

        public bool Remove(KeyValuePair<byte, ColorABGR1555[]> item) => _clut.Remove(item.Key);

        public bool Remove(byte key) => _clut.Remove(key);

        public bool TryGetValue(byte key, out ColorABGR1555[] value) => _clut.TryGetValue(key, out value);

        #endregion Methods

        public IReadOnlyList<byte> ClutIDs => _clut.Keys.OrderBy(x => x).ToList().AsReadOnly();
        public int MaxColors => _clut.Values.Max(x => x.Length);
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

        public byte MaxClut => Keys.Max(x => x);

        

    }
}