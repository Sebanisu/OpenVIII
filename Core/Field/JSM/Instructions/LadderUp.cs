﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class LadderUp : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;
        private readonly IJsmExpression _arg1;
        private readonly IJsmExpression _arg2;
        private readonly IJsmExpression _arg3;
        private readonly int _parameter;

        #endregion Fields

        #region Constructors

        public LadderUp(int parameter, IJsmExpression arg0, IJsmExpression arg1, IJsmExpression arg2, IJsmExpression arg3)
        {
            _parameter = parameter;
            _arg0 = arg0;
            _arg1 = arg1;
            _arg2 = arg2;
            _arg3 = arg3;
        }

        public LadderUp(int parameter, IStack<IJsmExpression> stack)
            : this(parameter,
                arg3: stack.Pop(),
                arg2: stack.Pop(),
                arg1: stack.Pop(),
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(LadderUp)}({nameof(_parameter)}: {_parameter}, {nameof(_arg0)}: {_arg0}, {nameof(_arg1)}: {_arg1}, {nameof(_arg2)}: {_arg2}, {nameof(_arg3)}: {_arg3})";

        #endregion Methods
    }
}