﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class PHSEnable : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public PHSEnable(IJsmExpression arg0) => _arg0 = arg0;

        public PHSEnable(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(PHSEnable)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}