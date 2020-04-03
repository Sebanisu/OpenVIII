namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class Rest : JsmInstruction
    {
        #region Constructors

        public Rest()
        {
        }

        public Rest(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(Rest)}()";

        #endregion Methods
    }
}