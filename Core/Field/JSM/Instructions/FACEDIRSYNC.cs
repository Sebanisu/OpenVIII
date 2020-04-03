namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FaceDirSync : JsmInstruction
    {
        #region Constructors

        public FaceDirSync()
        {
        }

        public FaceDirSync(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FaceDirSync)}()";

        #endregion Methods
    }
}