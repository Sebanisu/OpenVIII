﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Shade set?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/0B3_SHADESET&action=edit&redlink=1"/>
    public sealed class ShadeSet : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public ShadeSet(IJsmExpression arg0) => _arg0 = arg0;

        public ShadeSet(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(ShadeSet)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}