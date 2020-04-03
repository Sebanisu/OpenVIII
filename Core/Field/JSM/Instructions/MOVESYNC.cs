namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MoveSync : JsmInstruction
    {
        #region Constructors

        public MoveSync()
        {
        }

        public MoveSync(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MoveSync)}()";

        #endregion Methods
    }
}