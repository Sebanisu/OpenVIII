namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FootStepCopy : JsmInstruction
    {
        #region Constructors

        public FootStepCopy()
        {
        }

        public FootStepCopy(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FootStepCopy)}()";

        #endregion Methods
    }
}