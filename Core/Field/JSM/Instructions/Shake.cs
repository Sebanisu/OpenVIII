﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class Shake : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;
        private readonly IJsmExpression _arg1;
        private readonly IJsmExpression _arg2;
        private readonly IJsmExpression _arg3;

        #endregion Fields

        #region Constructors

        public Shake(IJsmExpression arg0, IJsmExpression arg1, IJsmExpression arg2, IJsmExpression arg3)
        {
            _arg0 = arg0;
            _arg1 = arg1;
            _arg2 = arg2;
            _arg3 = arg3;
        }

        public Shake(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg3: stack.Pop(),
                arg2: stack.Pop(),
                arg1: stack.Pop(),
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(Shake)}({nameof(_arg0)}: {_arg0}, {nameof(_arg1)}: {_arg1}, {nameof(_arg2)}: {_arg2}, {nameof(_arg3)}: {_arg3})";

        #endregion Methods
    }
}