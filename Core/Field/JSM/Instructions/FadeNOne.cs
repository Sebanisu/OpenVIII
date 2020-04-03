namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FadeNOne : JsmInstruction
    {
        #region Constructors

        public FadeNOne()
        {
        }

        public FadeNOne(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FadeNOne)}()";

        #endregion Methods
    }
}