namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class DirA : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public DirA(IJsmExpression arg0) => _arg0 = arg0;

        public DirA(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(DirA)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}