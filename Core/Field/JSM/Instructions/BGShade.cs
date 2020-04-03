﻿using Microsoft.Xna.Framework;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Shade between two colors
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/0D0_BGSHADE&action=edit&redlink=1"/>
    public sealed class BGShade : JsmInstruction
    {
        #region Fields

        private readonly Color _c0;
        private readonly Color _c1;
        private readonly int _fadeFrames;

        #endregion Fields

        #region Constructors

        public BGShade(int fadeFrames, byte red0, byte green0, byte blue0, byte red1, byte green1, byte blue1)
        {
            _fadeFrames = fadeFrames; //I think it's fade duration
            (_c0.R, _c0.G, _c0.B, _c0.A) = (red0, green0, blue0, 0xFF); //red and blue could be reversed.
            (_c1.R, _c1.G, _c1.B, _c1.A) = (red1, green1, blue1, 0xFF); //red and blue could be reversed.
        }

        public BGShade(int parameter, IStack<IJsmExpression> stack)
            : this(
                blue1: ((IConstExpression)stack.Pop()).Byte(),
                green1: ((IConstExpression)stack.Pop()).Byte(),
                red1: ((IConstExpression)stack.Pop()).Byte(),
                blue0: ((IConstExpression)stack.Pop()).Byte(),
                green0: ((IConstExpression)stack.Pop()).Byte(),
                red0: ((IConstExpression)stack.Pop()).Byte(),
                fadeFrames: ((IConstExpression)stack.Pop()).Int32())
        {
        }

        #endregion Constructors

        #region Properties

        public Color C0 => _c0;
        public Color C1 => _c1;
        public int FadeFrames => _fadeFrames;

        #endregion Properties

        #region Methods

        public override string ToString() => $"{nameof(BGShade)}({nameof(_fadeFrames)}: {_fadeFrames}, {nameof(_c0)}: {_c0}, {nameof(_c1)}: {_c1})";

        #endregion Methods
    }
}