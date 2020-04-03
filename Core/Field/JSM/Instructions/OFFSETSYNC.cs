namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class OffsetSync : JsmInstruction
    {
        #region Constructors

        public OffsetSync()
        {
        }

        public OffsetSync(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(OffsetSync)}()";

        #endregion Methods
    }
}