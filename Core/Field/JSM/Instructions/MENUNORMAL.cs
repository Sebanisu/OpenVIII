namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MenuNormal : JsmInstruction
    {
        #region Constructors

        public MenuNormal()
        {
        }

        public MenuNormal(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MenuNormal)}()";

        #endregion Methods
    }
}