namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MenuDisable : JsmInstruction
    {
        #region Constructors

        public MenuDisable()
        {
        }

        public MenuDisable(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MenuDisable)}()";

        #endregion Methods
    }
}