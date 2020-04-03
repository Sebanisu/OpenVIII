namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class InitTrace : JsmInstruction
    {
        #region Constructors

        public InitTrace()
        {
        }

        public InitTrace(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(InitTrace)}()";

        #endregion Methods
    }
}