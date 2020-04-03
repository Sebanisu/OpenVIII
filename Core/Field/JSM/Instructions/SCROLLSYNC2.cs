namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class ScrollSync2 : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public ScrollSync2(IJsmExpression arg0) => _arg0 = arg0;

        public ScrollSync2(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(ScrollSync2)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}