﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.IO;

namespace OpenVIII
{
    /// <summary>
    /// Playstation TIM Texture format.
    /// </summary>
    /// <see cref="http://www.raphnet.net/electronique/psx_adaptor/Playstation.txt"/>
    /// <seealso cref="http://www.psxdev.net/forum/viewtopic.php?t=109"/>
    /// <seealso cref="https://mrclick.zophar.net/TilEd/download/timgfx.txt"/>
    /// <remarks>upgraded TIM class, because that first one is a trash</remarks>
    public class TIM2
    {

        #region Fields

        private const ushort blue_mask = 0x7C00;

        private const ushort green_mask = 0x3E0;

        private const ushort red_mask = 0x1F;

        /// <summary>
        /// Bits per pixel
        /// </summary>
        private sbyte bpp = -1;

        /// <summary>
        /// Raw Data buffer
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// Image has a CLUT
        /// </summary>
        private bool CLP;

        /// <summary>
        /// Texture Data
        /// </summary>
        private Texture texture;

        /// <summary>
        /// Start of Image Data
        /// </summary>
        private uint textureDataPointer;

        /// <summary>
        /// Start of Tim Data
        /// </summary>
        private uint timOffset;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initialize TIM class
        /// </summary>
        /// <param name="buffer">Raw Data buffer</param>
        /// <param name="offset">Start of Tim Data</param>
        public TIM2(byte[] buffer, uint offset = 0)
        {
            using (BinaryReader br = new BinaryReader(new MemoryStream(buffer)))
            {
                this.buffer = buffer;
                br.BaseStream.Seek(offset, SeekOrigin.Begin);
                Debug.Assert(br.ReadByte() == 0x10); //tag
                Debug.Assert(br.ReadByte() == 0); // version
                br.BaseStream.Seek(2, SeekOrigin.Current);
                Bppflag b = (Bppflag)br.ReadByte();
                timOffset = offset;
                if ((b & (Bppflag._24bpp)) >= (Bppflag._24bpp)) bpp = 24;
                else if ((b & Bppflag._16bpp) != 0) bpp = 16;
                else if ((b & Bppflag._8bpp) != 0) bpp = 8;
                else bpp = 4;
                CLP = (b & Bppflag.CLP) != 0;
                Debug.Assert(((bpp == 4 || bpp == 8) && CLP) || ((bpp == 16 || bpp == 24) && !CLP));
                ReadParameters(br);
            }
        }

        #endregion Constructors

        #region Enums

        /// <summary>
        /// BPP indicator
        /// <para>4 BPP is default</para>
        /// <para>If 8 and 16 are set then it's 24</para>
        /// <para>CLP should always be set for 4 and 8</para>
        /// </summary>
        [Flags]
        public enum Bppflag : byte
        {
            /// <summary>
            /// <para>4 BPP</para>
            /// <para>This is 0 so it will show as unset.</para>
            /// </summary>
            _4bpp = 0b0,

            /// <summary>
            /// <para>8 BPP</para>
            /// <para>if _8bpp and _16bpp are set then it's 24 bit</para>
            /// </summary>
            _8bpp = 0b1,

            /// <summary>
            /// <para>16 BPP</para>
            /// <para>if _8bpp and _16bpp are set then it's 24 bit</para>
            /// </summary>
            _16bpp = 0b10,

            /// <summary>
            /// <para>24 BPP</para>
            /// <para>Both flags must be set for this to be right</para>
            /// </summary>
            _24bpp = _8bpp | _16bpp,

            /// <summary>
            /// Color Lookup table Present
            /// </summary>
            CLP = 0b1000,
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Number of clut color palettes
        /// </summary>
        public int GetClutCount => texture.NumOfCluts;

        /// <summary>
        /// Height
        /// </summary>
        public int GetHeight => texture.Height;

        /// <summary>
        /// Gets origin texture coordinate X for VRAM buffer
        /// </summary>
        public int GetOrigX => texture.ImageOrgX;

        /// <summary>
        /// Gets origin texture coordinate Y for VRAM buffer
        /// </summary>
        public int GetOrigY => texture.ImageOrgY;

        /// <summary>
        /// Width
        /// </summary>
        public int GetWidth => texture.Width;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Splash is 640x400 16BPP typical TIM with palette of ggg bbbbb a rrrrr gg
        /// </summary>
        /// <param name="buffer">raw 16bpp image</param>
        /// <returns>Texture2D</returns>
        /// <remarks>
        /// These files are just the image data with no header and no clut data. Tim class doesn't
        /// handle this.
        /// </remarks>
        public static Texture2D Overture(byte[] buffer)
        {
            using (MemoryStream ms = new MemoryStream(buffer))
            using (BinaryReader br = new BinaryReader(ms))
            {
                //var ImageOrgX = BitConverter.ToUInt16(buffer, 0x00);
                //var ImageOrgY = BitConverter.ToUInt16(buffer, 0x02);

                ms.Seek(0x04, SeekOrigin.Begin);
                ushort Width = br.ReadUInt16();
                ushort Height = br.ReadUInt16();
                Texture2D splashTex = new Texture2D(Memory.graphics.GraphicsDevice, Width, Height, false, SurfaceFormat.Color);
                lock (splashTex)
                {
                    Color[] rgbBuffer = new Color[Width * Height];
                    for (int i = 0; i < rgbBuffer.Length && ms.Position + 2 < ms.Length; i++)
                    {
                        rgbBuffer[i] = ABGR1555toRGBA32bit(br.ReadUInt16());
                    }
                    splashTex.SetData(rgbBuffer);
                }
                return splashTex;
            }
        }

        /// <summary>
        /// Create Texture from Tim image data.
        /// </summary>
        /// <param name="clut">Active clut data</param>
        /// <param name="bIgnoreSize">
        /// If true skip size check useful for files with more than just Tim
        /// </param>
        /// <returns>Texture2D</returns>
        public Texture2D GetTexture(ushort? clut = null, bool bIgnoreSize = false)
        {
            using (BinaryReader br = new BinaryReader(new MemoryStream(buffer)))
            {
                Texture2D image = new Texture2D(Memory.graphics.GraphicsDevice, GetWidth, GetHeight, false, SurfaceFormat.Color);
                image.SetData(CreateImageBuffer(br, clut == null ? null : GetClutColors(br, clut.Value), bIgnoreSize));
                return image;
            }
        }

        /// <summary>
        /// Convert ABGR1555 color to RGBA 32bit color
        /// </summary>
        /// <remarks>
        /// FromPsColor from TEX does the same thing I think. Unsure which is better. I like the masks
        /// </remarks>
        private static Color ABGR1555toRGBA32bit(ushort pixel)
        {
            if (pixel == 0) return Color.TransparentBlack;
            //https://docs.microsoft.com/en-us/windows/win32/directshow/working-with-16-bit-rgb
            // had the masks. though they were doing rgb but we are doing bgr so i switched red and blue.
            return new Color
            {
                R = (byte)MathHelper.Clamp((pixel & red_mask) << 3, 0, 255),
                G = (byte)MathHelper.Clamp(((pixel & green_mask) >> 5) << 3, 0, 255),
                B = (byte)MathHelper.Clamp(((pixel & blue_mask) >> 10) << 3, 0, 255),
                A = 255 //(byte)((pixel >> 11) & 1) // if bit on and not black possible semi-transparency
            };
            //http://www.raphnet.net/electronique/psx_adaptor/Playstation.txt
            // Says if color isn't black theres 4 modes psx could use for Semi-Transparency.
        }

        /// <summary>
        /// Output 32 bit Color data for image.
        /// </summary>
        /// <param name="br">Binaryreader pointing to memorystream of data.</param>
        /// <param name="palette">Color[] palette</param>
        /// <param name="bIgnoreSize">
        /// If true skip size check useful for files with more than just Tim
        /// </param>
        /// <returns>Color[]</returns>
        /// <remarks>
        /// This allows null palette but it doesn't seem to handle the palette being null
        /// </remarks>
        private Color[] CreateImageBuffer(BinaryReader br, Color[] palette = null, bool bIgnoreSize = false)
        {
            br.BaseStream.Seek(textureDataPointer, SeekOrigin.Begin);
            Color[] buffer = new Color[texture.Width * texture.Height]; //ARGB
            if (bpp == 8)
            {
                if (!bIgnoreSize)
                    if ((buffer.Length) != br.BaseStream.Length - br.BaseStream.Position)
                        throw new Exception("TIM_v2::CreateImageBuffer::TIM texture buffer has size incosistency.");
                for (int i = 0; i < buffer.Length; i++)
                    buffer[i] = palette[br.ReadByte()]; //colorkey
            }
            else if (bpp == 4)
            {
                if (!bIgnoreSize)
                    if ((buffer.Length) / 2 != br.BaseStream.Length - br.BaseStream.Position)
                        throw new Exception("TIM_v2::CreateImageBuffer::TIM texture buffer has size incosistency.");
                for (int i = 0; i < buffer.Length; i++)
                {
                    byte colorkey = br.ReadByte();
                    buffer[i] = palette[colorkey & 0xf];
                    buffer[++i] = palette[colorkey >> 4];
                }
            }
            else if (bpp == 16) //copied from overture
            {
                for (int i = 0; i < buffer.Length && br.BaseStream.Position + 2 < br.BaseStream.Length; i++)
                    buffer[i] = ABGR1555toRGBA32bit(br.ReadUInt16());
            }
            else if (bpp == 24) //could be wrong. // assuming it is BGR
            {
                for (int i = 0; i < buffer.Length && br.BaseStream.Position + 2 < br.BaseStream.Length; i++)
                {
                    byte[] pixel = br.ReadBytes(3);
                    buffer[i] = new Color
                    {
                        R = pixel[2],
                        G = pixel[1],
                        B = pixel[0],
                        A = 0xFF
                    };
                }
            }
            else
                throw new Exception($"TIM_v2::CreateImageBuffer::TIM unsupported bits per pixel = {bpp}");
            //Then in bs debug where ReadTexture store for all cluts
            //data and then create Texture2D from there. (array of e.g. 15 texture2D)
            return buffer;
        }

        /// <summary>
        /// Get clut color palette
        /// </summary>
        /// <param name="br">Binaryreader pointing to memorystream of data.</param>
        /// <param name="clut">Active clut data</param>
        /// <returns>Color[]</returns>
        private Color[] GetClutColors(BinaryReader br, ushort clut)
        {
            if (clut > texture.NumOfCluts)
                throw new Exception("TIM_v2::GetClutColors::given clut is bigger than texture number of cluts");

            Color[] colorPixels = new Color[texture.NumOfColours];
            if (CLP)
            {
                br.BaseStream.Seek(timOffset + 20 + (texture.NumOfColours * 2 * clut), SeekOrigin.Begin);
                for (int i = 0; i < texture.NumOfColours; i++)
                    colorPixels[i] = ABGR1555toRGBA32bit(br.ReadUInt16());
            }
            else if (bpp > 8) throw new Exception("TIM that has bpp mode higher than 8 has no clut data!");

            return colorPixels;
        }

        /// <summary>
        /// Populate Texture structure
        /// </summary>
        /// <param name="br">Binaryreader pointing to memorystream of data.</param>
        /// <param name="_bpp">bits per pixel</param>
        private void ReadParameters(BinaryReader br)
        {
            texture = new Texture();
            texture.Read(br, (byte)bpp, CLP);
            textureDataPointer = (uint)br.BaseStream.Position;
        }

        #endregion Methods

        #region Structs

        private struct Texture
        {

            #region Fields

            public byte[] ClutData;

            public int clutdataSize;

            /// <summary>
            /// length, in bytes, of the entire CLUT block (including the header)
            /// </summary>
            public uint clutSize;

            public ushort Height;
            public int ImageDataSize;
            public ushort ImageOrgX;
            public ushort ImageOrgY;
            public uint ImageSize;
            public ushort NumOfCluts;
            public ushort NumOfColours;
            public ushort PaletteX;
            public ushort PaletteY;
            public ushort Width;

            #endregion Fields

            #region Methods

            /// <summary>
            /// Populate Texture structure
            /// </summary>
            /// <param name="br">Binaryreader pointing to memorystream of data.</param>
            /// <param name="_bpp">bits per pixel</param>
            public void Read(BinaryReader br, byte _bpp, bool clp)
            {
                br.BaseStream.Seek(3, SeekOrigin.Current);
                if (clp)
                {
                    //long start = br.BaseStream.Position;
                    clutSize = br.ReadUInt32();
                    PaletteX = br.ReadUInt16();
                    PaletteY = br.ReadUInt16();
                    NumOfColours = br.ReadUInt16();
                    NumOfCluts = br.ReadUInt16();
                    clutdataSize = (int)(clutSize - 12);//(NumOfColours * NumOfCluts*2);

                    Debug.Assert(PaletteX % 16 == 0);
                    Debug.Assert(PaletteY >= 0 && PaletteY <= 511);
                    ClutData = br.ReadBytes(clutdataSize);
                    //br.BaseStream.Seek(start+clutSize, SeekOrigin.Begin);
                }
                //wmsetus uses 4BPP, but sets 256 colours, but actually is 16, but num of clut is 2* 256/16 WTF?

                ImageSize = br.ReadUInt32(); // image size + header in bytes
                ImageOrgX = br.ReadUInt16();
                ImageOrgY = br.ReadUInt16();
                if (_bpp == 4)
                    Width = (ushort)(br.ReadUInt16() * 4);
                if (_bpp == 8)
                    Width = (ushort)(br.ReadUInt16() * 2);
                if (_bpp == 16)
                    Width = br.ReadUInt16();
                if (_bpp == 24)
                    Width = (ushort)(br.ReadUInt16() / 1.5);
                Height = br.ReadUInt16();
                ImageDataSize = (int)(ImageSize - 12);//(NumOfColours * NumOfCluts*2);
            }

            #endregion Methods

        }

        #endregion Structs
    }
}