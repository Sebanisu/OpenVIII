namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class RFaceDirP : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;
        private readonly IJsmExpression _arg1;

        #endregion Fields

        #region Constructors

        public RFaceDirP(IJsmExpression arg0, IJsmExpression arg1)
        {
            _arg0 = arg0;
            _arg1 = arg1;
        }

        public RFaceDirP(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg1: stack.Pop(),
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(RFaceDirP)}({nameof(_arg0)}: {_arg0}, {nameof(_arg1)}: {_arg1})";

        #endregion Methods
    }
}