namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FaceDirInit : JsmInstruction
    {
        #region Constructors

        public FaceDirInit()
        {
        }

        public FaceDirInit(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FaceDirInit)}()";

        #endregion Methods
    }
}