namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FootStepOffAll : JsmInstruction
    {
        #region Constructors

        public FootStepOffAll()
        {
        }

        public FootStepOffAll(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FootStepOffAll)}()";

        #endregion Methods
    }
}