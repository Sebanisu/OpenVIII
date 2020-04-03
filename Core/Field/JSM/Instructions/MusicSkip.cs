﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Music skip?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/144_MUSICSKIP&action=edit&redlink=1"/>
    public sealed class MusicSkip : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// i'm guessing this is time skipped?
        /// </summary>
        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public MusicSkip(IJsmExpression arg0) => _arg0 = arg0;

        public MusicSkip(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MusicSkip)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}