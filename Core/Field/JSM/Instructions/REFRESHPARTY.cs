namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class RefreshParty : JsmInstruction
    {
        #region Constructors

        public RefreshParty()
        {
        }

        public RefreshParty(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(RefreshParty)}()";

        #endregion Methods
    }
}