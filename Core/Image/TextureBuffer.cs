using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace OpenVIII
{
    public class TextureBuffer : ITextureBase, ICloneable, ICollection, IStructuralComparable, IStructuralEquatable
    {

        #region Fields

        #endregion Fields

        #region Constructors

        public TextureBuffer(int width, int height, bool alert = true, IColorData[] colors = null)
        {
            Height = height;
            Width = width;
            Colors = colors ?? new IColorData[height * width];
            Debug.Assert(colors == null || colors.Length == height * width);
            Alert = alert;
        }

        #endregion Constructors

        #region Properties

        public bool Alert { get; set; }
        public IColorData[] Colors { get; private set; }
        public int Count => ((ICollection)Colors).Count;
        public byte GetBytesPerPixel => 4;
        public byte GetClutCount => 0;
        public uint GetClutSize => 0;
        public byte GetColorsCountPerPalette => 0;
        public  int GetHeight => Height;
        public int GetOrigX => 0;
        public  int GetOrigY => 0;
        public  int GetWidth => Width;
        public int Height { get; }
        public bool IsSynchronized => Colors.IsSynchronized;
        public int Length => Colors?.Length ?? 0;
        public object SyncRoot => Colors.SyncRoot;
        public int Width { get; }

        #endregion Properties

        #region Indexers

        public IColorData this[int i]
        {
            get => Colors[i]; set
            {
                if (Colors?[i] != null && Alert && !Colors[i].Equals(Color.TransparentBlack))
                    throw new Exception("Color is set!");
                if (Colors != null) Colors[i] = value;
            }
        }

        public IColorData this[int x, int y]
        {
            get
            {
                var i = x + (y * Width);
                if (i < Count && i >= 0)
                    return Colors[i];
                Memory.Log.WriteLine($"{nameof(TextureBuffer)} :: this[int x, int y] => get :: {nameof(IndexOutOfRangeException)} :: {new Point(x, y)} = {i}");
                return (ColorRGBA8888)Color.TransparentBlack; // fail silent...
            }
            set
            {
                var i = x + (y * Width);
                if (i < Count && i >= 0)
                    this[i] = value;
                else
                    Memory.Log.WriteLine($"{nameof(TextureBuffer)} :: this[int x, int y] => set :: {nameof(IndexOutOfRangeException)} :: {new Point(x, y)} = {i} :: {nameof(value)} :: {value}");
            }
        }

        public IColorData[] this[Rectangle rectangle]
        {
            get => this[rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height];
            set => this[rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height] = value;
        }

        public IColorData[] this[int x, int y, int width, int height]
        {
            get
            {
                var pos = (x + y * Width);
                var r = new List<IColorData>(width * height);
                var row = 0;
                while (r.Count < width * height)
                {
                    r.AddRange(Colors.Skip(pos + row * Width).Take(width));
                    row++;
                }
                return r.ToArray();
            }
            set
            {
                for (var loopY = y; (loopY - y) < height; loopY++)
                    for (var loopX = x; (loopX - x) < width; loopX++)
                    {
                        var pos = (loopX + loopY * Width);
                        Colors[pos] = value[(loopX - x) + (loopY - y) * width];
                    }
            }
        }

        #endregion Indexers

        #region Methods

        public static explicit operator Texture2D(TextureBuffer @in)
        {
            if (Memory.Graphics?.GraphicsDevice == null || @in.Width <= 0 || @in.Height <= 0) return null;
            var tex = new Texture2D(Memory.Graphics.GraphicsDevice, @in.Width, @in.Height);
            @in.SetData(tex);
            return tex;
        }

        public static explicit operator Texture2DWrapper(TextureBuffer @in) => new Texture2DWrapper(@in.GetTexture());

        public static explicit operator TextureBuffer(Texture2D @in)
        {
            var v = new ColorRGBA8888[@in.Width * @in.Height];

            @in.GetData(v);
            var texture = new TextureBuffer(@in.Width, @in.Height, false, v.Cast<IColorData>().ToArray());
            
            return texture;
        }

        public static explicit operator TextureBuffer(Texture2DWrapper @in)
        {
            return (TextureBuffer) @in.GetTexture();
        }

        public static implicit operator IColorData[] (TextureBuffer @in) => @in.Colors;

        public object Clone() => Colors.Clone();

        public int CompareTo(object other, IComparer comparer) => ((IStructuralComparable)Colors).CompareTo(other, comparer);

        public void CopyTo(Array array, int index) => Colors.CopyTo(array, index);

        public bool Equals(object other, IEqualityComparer comparer) => ((IStructuralEquatable)Colors).Equals(other, comparer);

        public void ForceSetClutColors(byte newNumOfColors)
        {
        }

        public void ForceSetClutCount(byte newClut)
        {
        }

        public IColorData[] GetClutColors(byte clut) => null;
        public Texture2D GetTexture(Dictionary<int, IColorData> colorOverride, sbyte clut = -1)
        {
            throw new NotImplementedException();
        }

        public void GetData(Texture2D tex)
        {
            var v = new ColorRGBA8888[Height*Width];

            tex.GetData(v);
            Colors = v.Cast<IColorData>().ToArray();
        }

        public IEnumerator GetEnumerator() => Colors.GetEnumerator();

        public int GetHashCode(IEqualityComparer comparer) => ((IStructuralEquatable)Colors).GetHashCode(comparer);

        public Texture2D GetTexture() => (Texture2D)this;

        public Texture2D GetTexture(IColorData[] colors) => (Texture2D)this;

        public Texture2D GetTexture(byte clut) => (Texture2D)this;

        public void Load(byte[] buffer, uint offset = 0) => throw new NotImplementedException();

        public void Save(string path)
        {
            using (var tex = GetTexture())
            using (var fs = File.Create(path))
                tex.SaveAsPng(fs, tex.Width, tex.Height);
        }

        public void SaveClut(string path)
        {
        }

        public void SavePNG(string path, short clut = -1)
        {
            throw new NotImplementedException();
        }

        public void SetData(Texture2D tex) => tex.SetData(Colors.GetColors());

        #endregion Methods
    }
}