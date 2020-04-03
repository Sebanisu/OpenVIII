namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MenuEnable : JsmInstruction
    {
        #region Constructors

        public MenuEnable()
        {
        }

        public MenuEnable(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MenuEnable)}()";

        #endregion Methods
    }
}