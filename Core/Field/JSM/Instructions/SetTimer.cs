﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class SetTimer : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public SetTimer(IJsmExpression arg0) => _arg0 = arg0;

        public SetTimer(IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(SetTimer)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}