namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class SetOdin : JsmInstruction
    {
        #region Constructors

        public SetOdin()
        {
        }

        public SetOdin(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(SetOdin)}()";

        #endregion Methods
    }
}