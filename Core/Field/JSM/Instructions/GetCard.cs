namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class GetCard : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public GetCard(IJsmExpression arg0) => _arg0 = arg0;

        public GetCard(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(GetCard)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}