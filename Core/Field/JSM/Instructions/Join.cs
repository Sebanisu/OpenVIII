namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class Join : JsmInstruction
    {
        #region Constructors

        public Join()
        {
        }

        public Join(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(Join)}()";

        #endregion Methods
    }
}