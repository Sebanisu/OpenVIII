namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MenuSave : JsmInstruction
    {
        #region Constructors

        public MenuSave()
        {
        }

        public MenuSave(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MenuSave)}()";

        #endregion Methods
    }
}