﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class LadderDown2 : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;
        private readonly IJsmExpression _arg1;
        private readonly IJsmExpression _arg2;
        private readonly IJsmExpression _arg3;
        private readonly IJsmExpression _arg4;
        private readonly IJsmExpression _arg5;
        private readonly IJsmExpression _arg6;
        private readonly IJsmExpression _arg7;
        private readonly IJsmExpression _arg8;
        private readonly int _parameter;

        #endregion Fields

        #region Constructors

        public LadderDown2(int parameter, IJsmExpression arg0, IJsmExpression arg1, IJsmExpression arg2, IJsmExpression arg3, IJsmExpression arg4, IJsmExpression arg5, IJsmExpression arg6, IJsmExpression arg7, IJsmExpression arg8)
        {
            _parameter = parameter;
            _arg0 = arg0;
            _arg1 = arg1;
            _arg2 = arg2;
            _arg3 = arg3;
            _arg4 = arg4;
            _arg5 = arg5;
            _arg6 = arg6;
            _arg7 = arg7;
            _arg8 = arg8;
        }

        public LadderDown2(int parameter, IStack<IJsmExpression> stack)
            : this(parameter,
                arg8: stack.Pop(),
                arg7: stack.Pop(),
                arg6: stack.Pop(),
                arg5: stack.Pop(),
                arg4: stack.Pop(),
                arg3: stack.Pop(),
                arg2: stack.Pop(),
                arg1: stack.Pop(),
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(LadderDown2)}({nameof(_parameter)}: {_parameter}, {nameof(_arg0)}: {_arg0}, {nameof(_arg1)}: {_arg1}, {nameof(_arg2)}: {_arg2}, {nameof(_arg3)}: {_arg3}, {nameof(_arg4)}: {_arg4}, {nameof(_arg5)}: {_arg5}, {nameof(_arg6)}: {_arg6}, {nameof(_arg7)}: {_arg7}, {nameof(_arg8)}: {_arg8})";

        #endregion Methods
    }
}