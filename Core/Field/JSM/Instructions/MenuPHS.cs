namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MenuPHS : JsmInstruction
    {
        #region Constructors

        public MenuPHS()
        {
        }

        public MenuPHS(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MenuPHS)}()";

        #endregion Methods
    }
}