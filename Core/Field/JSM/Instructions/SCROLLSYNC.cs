namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class ScrollSync : JsmInstruction
    {
        #region Constructors

        public ScrollSync()
        {
        }

        public ScrollSync(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(ScrollSync)}()";

        #endregion Methods
    }
}