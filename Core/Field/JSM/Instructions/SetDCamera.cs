namespace OpenVIII.Fields.Scripts.Instructions
{
    public sealed class SetDCamera : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public SetDCamera(IJsmExpression arg0) => _arg0 = arg0;

        public SetDCamera(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Properties

        public IJsmExpression Arg => _arg0;

        #endregion Properties

        #region Methods

        public override string ToString() => $"{nameof(SetDCamera)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}