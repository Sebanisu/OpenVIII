using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenVIII
{
    public class TextureBuffer : ITextureBase, ICloneable, ICollection, IStructuralComparable, IStructuralEquatable
    {

        #region Fields

        #endregion Fields

        #region Constructors

        public TextureBuffer(int width, int height, bool alert = true)
        {
            Height = height;
            Width = width;
            Colors = new Color[height * width];
            Alert = alert;
        }

        #endregion Constructors

        #region Properties

        public bool Alert { get; set; }
        public Color[] Colors { get; }
        public int Count => ((ICollection)Colors).Count;
        public byte GetBytesPerPixel => 4;
        public byte GetClutCount => 0;
        public byte GetClutSize => 0;
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

        public Color this[int i]
        {
            get => Colors[i]; set
            {
                if (Alert && Colors[i] != Color.TransparentBlack)
                    throw new Exception("Color is set!");
                Colors[i] = value;
            }
        }

        public Color this[int x, int y]
        {
            get
            {
                var i = x + (y * Width);
                if (i < Count && i >= 0)
                    return Colors[i];
                Memory.Log.WriteLine($"{nameof(TextureBuffer)} :: this[int x, int y] => get :: {nameof(IndexOutOfRangeException)} :: {new Point(x, y)} = {i}");
                return Color.TransparentBlack; // fail silent...
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

        public Color[] this[Rectangle rectangle]
        {
            get => this[rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height];
            set => this[rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height] = value;
        }

        public Color[] this[int x, int y, int width, int height]
        {
            get
            {
                var pos = (x + y * Width);
                var r = new List<Color>(width * height);
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
            var texture = new TextureBuffer(@in.Width, @in.Height);

            @in.GetData(texture.Colors);
            return texture;
        }

        public static explicit operator TextureBuffer(Texture2DWrapper @in)
        {
            var texture = new TextureBuffer(@in.GetWidth, @in.GetHeight);
            var tex = @in.GetTexture();
            tex.GetData(texture.Colors);
            return texture;
        }

        public static implicit operator Color[] (TextureBuffer @in) => @in.Colors;

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

        public Color[] GetClutColors(byte clut) => null;
        public Texture2D GetTexture(Dictionary<int, Color> colorOverride, sbyte clut = -1)
        {
            throw new NotImplementedException();
        }

        public void GetData(Texture2D tex) => tex.GetData(Colors);

        public IEnumerator GetEnumerator() => Colors.GetEnumerator();

        public int GetHashCode(IEqualityComparer comparer) => ((IStructuralEquatable)Colors).GetHashCode(comparer);

        public Texture2D GetTexture() => (Texture2D)this;

        public Texture2D GetTexture(Color[] colors) => (Texture2D)this;

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

        public void SetData(Texture2D tex) => tex.SetData(Colors);

        #endregion Methods
    }
}