namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FadeBlack : JsmInstruction
    {
        #region Constructors

        public FadeBlack()
        {
        }

        public FadeBlack(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FadeBlack)}()";

        #endregion Methods
    }
}