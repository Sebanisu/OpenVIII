﻿using Microsoft.Xna.Framework;
using OpenVIII.Encoding.Tags;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace OpenVIII.IGMData
{
    public abstract class Base : Menu_Base
    {
        #region Fields

        public BitArray BLANKS;

        /// <summary>
        /// location of where pointer finger will point.
        /// </summary>
        public Point[] CURSOR;

        public Menu_Base[,] ITEM;
        public int PointerZIndex = byte.MaxValue;

        /// <summary>
        /// Size of the entire area
        /// </summary>
        public Rectangle[] SIZE;

        protected bool DepthFirst = false;

        protected bool skipdata = false;

        protected bool skipsnd = false;

        private byte _count = 0;

        private int _cursor_select;

        #endregion Fields

        #region Constructors

        public Base() => CONTAINER = new IGMDataItem.Empty();

        #endregion Constructors

        #region Properties

        public static Vector2 TextScale => Menu.TextScale;
        public byte Cols { get; protected set; } = 1;

        /// <summary>
        /// Total number of items
        /// </summary>
        public byte Count { get => _count; protected set => _count = checked((byte)(value + ExtraCount)); }

        public int CURSOR_SELECT
        {
            get => GetCursor_select(); set => SetCursor_select(value);
        }

        /// <summary>
        /// How many Peices per Item. Example 1 box could have 9 things to draw in it.
        /// </summary>
        public byte Depth { get; protected set; } = 0;

        public Dictionary<int, FF8String> Descriptions { get; protected set; }
        public byte ExtraCount { get; protected set; } = 0;

        /// <summary>
        /// Container's Height
        /// </summary>
        public override int Height => CONTAINER != null ? Pos.Height : 0;

        public override Rectangle Pos { get => CONTAINER?.Pos ?? Rectangle.Empty; set => CONTAINER.Pos = value; }

        public byte Rows { get; protected set; } = 1;

        public bool SkipSIZE { get; set; } = false;

        public Table_Options Table_Options { get; set; } = Table_Options.Default;

        /// <summary>
        /// Container's Width
        /// </summary>
        public override int Width => CONTAINER != null ? Pos.Width : 0;

        /// <summary>
        /// Container's X Position
        /// </summary>
        public override int X => CONTAINER != null ? Pos.X : 0;

        /// <summary>
        /// Container's Y Position
        /// </summary>
        public override int Y => CONTAINER != null ? Pos.Y : 0;

        #endregion Properties

        #region Indexers

        public Menu_Base this[int pos, int i] { get => ITEM[pos, i]; set => ITEM[pos, i] = value; }

        #endregion Indexers

        #region Methods

        public static T Create<T>(int count = 0, int depth = 0, Menu_Base container = null, int? cols = null, int? rows = null, Damageable damageable = null, sbyte? partypos = null, bool battle = false) where T : Base, new()
        {
            var r = Create<T>(damageable, partypos);
            r.Battle = battle;
            r.Init(count, depth, container, cols, rows);
            return r;
        }

        /// <summary>
        /// Convert to rectangle based on container.
        /// </summary>
        /// <param name="v">Input data</param>
        public static implicit operator Rectangle(Base v) => v.CONTAINER ?? Rectangle.Empty;

        //public object PrevSetting { get; protected set; } = null;
        //public object Setting { get; protected set; } = null;
        public virtual int CURSOR_NEXT()
        {
            if ((Cursor_Status & Cursor_Status.Enabled) != 0)
            {
                var value = GetCursor_select();
                var loop = 0;
                while (true)
                {
                    if (++value >= CURSOR.Length)
                    {
                        value = 0;
                        if (loop++ > 1) break;
                    }
                    if ((CURSOR[value] != Point.Zero && !BLANKS[value])) break;
                }
                SetCursor_select(value);
            }
            return GetCursor_select();
        }

        public virtual int CURSOR_PREV()
        {
            if ((Cursor_Status & Cursor_Status.Enabled) != 0)
            {
                var value = GetCursor_select();
                var loop = 0;
                while (true)
                {
                    if (--value < 0)
                    {
                        value = CURSOR.Length - 1;
                        if (loop++ > 1) break;
                    }
                    if ((CURSOR[value] != Point.Zero && !BLANKS[value])) break;
                }
                SetCursor_select(value);
            }
            return GetCursor_select();
        }

        /// <summary>
        /// Draw all items
        /// </summary>
        public override void Draw()
        {
            if (Enabled)
            {
                if (CONTAINER != null)
                    CONTAINER.Draw();
                var pointer = false;
                Target.Group targetgroup = null;
                if (!skipdata && ITEM != null)
                    if (DepthFirst)
                        for (var d = 0; d < Depth; d++)
                            for (var i = 0; i < Count; i++)
                            {
                                if (i == PointerZIndex && !pointer)
                                    pointer = DrawPointer();
                                if (ITEM[i, d] != null && (ITEM[i, d].GetType()).Equals(typeof(Target.Group)))
                                    targetgroup = (Target.Group)(ITEM[i, d]);
                                else
                                    DrawITEM(i, d);
                            }
                    else
                        for (var i = 0; i < Count; i++)
                            for (var d = 0; d < Depth; d++)
                            {
                                if (i == PointerZIndex && !pointer)
                                    pointer = DrawPointer();
                                if (ITEM[i, d]!=null && (ITEM[i, d].GetType()).Equals(typeof(Target.Group)))
                                    targetgroup = (Target.Group)(ITEM[i, d]);
                                else
                                    DrawITEM(i, d);
                            }
                if (!pointer)
                {
                    pointer = DrawPointer();
                }
                targetgroup?.Draw();
            }
        }

        public void DrawPointer(Point cursor, Vector2? offset = null, bool blink = false) => Menu.DrawPointer(cursor, offset, blink);

        public override void HideChildren()
        {
            if (Enabled)
            {
                //base.Hide();
                //maybe overkill to run hide on items. if group is hidden it won't draw.
                if (!skipdata)
                {
                    foreach (var i in ITEM)
                    {
                        if (i != null)
                        {
                            i.HideChildren();
                            i.Hide();
                        }
                    }
                }
            }
        }

        public void InitSize(bool force = false)
        {
            var cellcount = Rows * Cols;
            //SetSize(cellcount);
            if (((SIZE != null && SIZE.Length > 0) || force))
            {
                if (cellcount > 1)
                {
                    InitRowsSize(force);
                }
                else
                {
                    SIZE[0] = new Rectangle(X, Y, Width, Height);
                    CURSOR[0] = Point.Zero;
                    BLANKS[0] = false;
                    InitShift(0, 0, 0);
                    InitCursor(0, 0, 0);
                }
            }
        }

        /// <summary>
        /// Check inputs
        /// </summary>
        /// <returns>True = input detected</returns>
        public override bool Inputs()
        {
            var ret = false;
            var mouse = false;
            if ((Cursor_Status & Cursor_Status.Enabled) != 0)
            {
                Cursor_Status &= ~Cursor_Status.Blinking;
                if ((Cursor_Status & Cursor_Status.Static) == 0)
                    for (var i = 0; i < SIZE.Length; i++)
                    {
                        if (SIZE[i].Contains(MouseLocation) && !SIZE[i].IsEmpty && CURSOR[i] != Point.Zero && !BLANKS[i])
                        {
                            CURSOR_SELECT = i;
                            ret = true;
                            mouse = true;
                        }
                    }
                if (!ret && (Cursor_Status & Cursor_Status.Horizontal) != 0 && (Cursor_Status & Cursor_Status.Static) == 0)
                {
                    if (Input2.DelayedButton(FF8TextTagKey.Left))
                    {
                        CURSOR_PREV();
                        ret = true;
                    }
                    else if (Input2.DelayedButton(FF8TextTagKey.Right))
                    {
                        CURSOR_NEXT();
                        ret = true;
                    }
                }
                if ((!ret && (Cursor_Status & Cursor_Status.Horizontal) == 0 || (Cursor_Status & Cursor_Status.Vertical) != 0) && (Cursor_Status & Cursor_Status.Static) == 0)
                {
                    if (Input2.DelayedButton(FF8TextTagKey.Up))
                    {
                        CURSOR_PREV();
                        ret = true;
                    }
                    else if (Input2.DelayedButton(FF8TextTagKey.Down))
                    {
                        CURSOR_NEXT();
                        ret = true;
                    }
                }
                if (mouse || !ret)
                {
                    if (Input2.DelayedButton(FF8TextTagKey.Confirm))
                    {
                        return Inputs_OKAY();
                    }
                    else if (Input2.DelayedButton(FF8TextTagKey.Cancel))
                    {
                        return Inputs_CANCEL();
                    }
                    else if (Input2.DelayedButton(FF8TextTagKey.RotateRight))
                    {
                        Inputs_RotateRight();
                        return true;
                    }
                    else if (Input2.DelayedButton(FF8TextTagKey.Cards))
                    {
                        Inputs_Cards();
                        return true;
                    }
                    else if (Input2.DelayedButton(FF8TextTagKey.Menu))
                    {
                        Inputs_Menu();
                        return true;
                    }
                    else if ((Cursor_Status & Cursor_Status.Horizontal) == 0 && (Cursor_Status & Cursor_Status.Static) == 0)
                    {
                        if (Input2.DelayedButton(FF8TextTagKey.Left))
                        {
                            Inputs_Left();
                            return true;
                        }
                        else if (Input2.DelayedButton(FF8TextTagKey.Right))
                        {
                            Inputs_Right();
                            return true;
                        }
                    }
                }
                if (ret && !mouse)
                {
                    if (!skipsnd)
                        AV.Sound.Play(0);
                }
            }
            skipsnd = false;
            return ret;
        }

        public virtual bool Inputs_CANCEL()
        {
            if (!skipsnd)
                AV.Sound.Play(8);
            return false;
        }

        public virtual void Inputs_Cards()
        {
            if (!skipsnd)
                AV.Sound.Play(0);
        }

        public virtual void Inputs_Left()
        {
            if (!skipsnd)
                AV.Sound.Play(0);
        }

        public virtual void Inputs_Menu()
        {
            if (!skipsnd)
                AV.Sound.Play(31);
        }

        public virtual bool Inputs_RotateRight()
        {
            if (!skipsnd)
                AV.Sound.Play(0);
            return false;
        }
        public virtual bool Inputs_OKAY()
        {
            if (!skipsnd)
                AV.Sound.Play(0);
            return false;
        }

        public virtual void Inputs_Right()
        {
            if (!skipsnd)
                AV.Sound.Play(0);
        }

        public override void Refresh()
        {
            var count = Memory.State?.PartyData.Count ?? 0;
            if (Memory.State?.PartyData != null &&
                Damageable == null &&
                PartyPos >= 0 &&
                PartyPos < count)
            {
                Damageable = Memory.State[Memory.State.PartyData[PartyPos]];
            }

            base.Refresh();
        }

        public override void Reset()
        {
            foreach (var i in ITEM)
            {
                i?.Reset();
            }
            base.Reset();
        }

        /// <summary>
        /// Things that change on every update.
        /// </summary>
        /// <returns>True = signifigant change</returns>
        public override bool Update()
        {
            var ret = false;
            if (!skipdata && ITEM != null)
                foreach (var i in ITEM)
                {
                    if (i != null)
                        ret = i.Update() || ret;
                }
            return ret;
        }

        protected void AutoAdjustContainerWidth(Rectangle DataSize)
        {
            if (DataSize.Right > Pos.Right)
            {
                CONTAINER.Width += DataSize.Right - Pos.Right + Math.Abs(DataSize.Left - Pos.Left);
            }
        }

        protected bool CheckBounds(ref Rectangle DataSize, Rectangle input)
        {
            if (input.Right > Pos.Right && input.Right > DataSize.Right)
            {
                DataSize = input;
                return true;
            }
            return false;
        }

        protected bool CheckBounds(ref Rectangle DataSize, int pos) => CheckBounds(ref DataSize, ((IGMDataItem.Text)ITEM[pos, 0]).DataSize);

        protected virtual void DrawITEM(int i, int d) => ITEM[i, d]?.Draw();

        protected virtual bool DrawPointer()
        {
            if ((Cursor_Status & (Cursor_Status.Enabled | Cursor_Status.Draw)) != 0 &&
                (Cursor_Status & Cursor_Status.Hidden) == 0)
            {
                if ((Cursor_Status & Cursor_Status.All) != 0)
                {
                    for (var i = 0; i < CURSOR.Length; i++)
                        if (!BLANKS[i])
                            DrawPointer(CURSOR[i], blink: true);
                }
                else
                    DrawPointer(CURSOR[CURSOR_SELECT], blink: ((Cursor_Status & Cursor_Status.Blinking) != 0));
                return true;
            }
            return false;
        }

        protected int GetCursor_select() => _cursor_select;

        /// <summary>
        /// Most objects set all these values. also Init Refresh and Update
        /// </summary>
        /// <param name="count"></param>
        /// <param name="depth"></param>
        /// <param name="container"></param>
        /// <param name="cols"></param>
        /// <param name="rows"></param>
        protected void Init(int count, int depth, Menu_Base container = null, int? cols = null, int? rows = null)
        {
            if (count >= 0)
                Count = checked((byte)count);
            if (depth >= 0)
                Depth = checked((byte)depth);
            if (container != null)
                CONTAINER = container;
            if (cols.HasValue && cols.Value > 0)
                Cols = checked((byte)cols.Value);
            if (rows.HasValue && rows.Value > 0)
                Rows = checked((byte)rows.Value);
            Init();
            Refresh();
            Update();
        }

        /// <summary>
        /// Things that are fixed values at startup.
        /// </summary>
        protected override void Init()
        {
            if (Count <= 0 || Depth <= 0)
            {
                if (CONTAINER.Pos == Rectangle.Empty)
                {
                    Debug.WriteLine($"{this}:: Count {Count} or depth {Depth}, is invalid must be >= 1, or a CONTAINER {CONTAINER} and CONTAINER.Pos { Pos.ToString() } must be set instead, Skipping Init()");
                    return;
                }
            }
            else
            {
                //if (SIZE == null)
                //    SIZE = new Rectangle[Count];
                if (ITEM == null)
                    ITEM = new Menu_Base[Count, Depth];
                //if (CURSOR == null)
                //    CURSOR = new Point[Count];
                //if (BLANKS == null)
                //    BLANKS = new bool[Count];
                if (Descriptions == null)
                    Descriptions = new Dictionary<int, FF8String>(Count);

                SetSize(Math.Max(Rows * Cols, Count));
            }
            if (!SkipSIZE)
                InitSize();
            SkipSIZE = false;
        }

        protected virtual void InitCursor(int i, int col, int row, bool zero = false)
        {
            if (zero) CURSOR[i] = Point.Zero;
            CURSOR[i].Y += (int)(SIZE[i].Y + 6 * TextScale.Y);
            CURSOR[i].X += SIZE[i].X;
        }

        protected virtual void InitShift(int i, int col, int row)
        {
        }

        protected bool InputITEM(Menu_Base menuitem, ref bool ret)
        {
            if (menuitem != null && menuitem.Enabled)
            {
                Cursor_Status |= (Cursor_Status.Enabled | Cursor_Status.Blinking);
                ret = menuitem.Inputs();
                return true;
            }
            return false;
        }

        protected override void RefreshChild()
        {
            base.RefreshChild();
            if (!skipdata)
            {
                if (CONTAINER != null)
                {
                    if (ForceNullDamageable)
                        CONTAINER.ForceNullDamageable = ForceNullDamageable;
                    CONTAINER.Refresh(Damageable);
                }
                if (ITEM != null)
                    for (var i = 0; i < Count; i++)
                        for (var d = 0; d < Depth; d++)
                        {
                            if (ForceNullDamageable && ITEM[i, d] != null)
                                ITEM[i, d].ForceNullDamageable = ForceNullDamageable;
                            ITEM[i, d]?.Refresh(Damageable);
                        }
            }
        }

        protected virtual void SetCursor_select(int value)
        {
            if (value >= 0 && CURSOR != null && value < CURSOR.Length && CURSOR[value] != Point.Zero)
                _cursor_select = value;
        }

        //protected Base(int Count = 0, int depth = 0, Menu_Base container = null, int? cols = null, int? rows = null, Damageable damageable = null, sbyte? PartyPos = null)
        //{
        //    Init(damageable, PartyPos);
        //    Init(Count, depth, container, cols, rows);
        //}
        private static T Create<T>(Damageable damageable = null, sbyte? partypos = null) where T : Base, new()
        {
            var r = new T();
            r.SetDamageable(damageable, partypos);
            return r;
        }

        private void InitRowsSize(bool force)
        {
            for (var i = 0; i < SIZE.Length; i++)
            {
                var col = (Table_Options & Table_Options.FillRows) != 0 ? i % Cols : i / Rows;
                var row = (Table_Options & Table_Options.FillRows) != 0 ? i / Cols : i % Rows;
                if (col < Cols && row < Rows)
                {
                    if (SIZE[i].IsEmpty || force) //allows for override a size value before the loop.
                    {
                        SIZE[i] = new Rectangle
                        {
                            X = X + (Width * col) / Cols,
                            Y = Y + (Height * row) / Rows,
                            Width = Width / Cols,
                            Height = Height / Rows,
                        };
                    }
                    CURSOR[i] = Point.Zero;
                    InitShift(i, col, row);
                    InitCursor(i, col, row);
                }
            }
        }

        private void SetSize(int cellcount)
        {
            cellcount = cellcount > 1 ? cellcount : 1;
            if (CURSOR == null || CURSOR.Length == 0 ||
                SIZE == null || SIZE.Length == 0 ||
                BLANKS == null || BLANKS.Length == 0)
            {
                CURSOR = new Point[cellcount];
                SIZE = new Rectangle[cellcount];
                BLANKS = new BitArray(cellcount,false);
            }
        }

        #endregion Methods
    }
}