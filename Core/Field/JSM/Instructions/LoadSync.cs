namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class LoadSync : JsmInstruction
    {
        #region Constructors

        public LoadSync()
        {
        }

        public LoadSync(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(LoadSync)}()";

        #endregion Methods
    }
}