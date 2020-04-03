namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FootStepCut : JsmInstruction
    {
        #region Constructors

        public FootStepCut()
        {
        }

        public FootStepCut(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FootStepCut)}()";

        #endregion Methods
    }
}