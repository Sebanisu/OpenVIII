namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class ShakeOff : JsmInstruction
    {
        #region Constructors

        public ShakeOff()
        {
        }

        public ShakeOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(ShakeOff)}()";

        #endregion Methods
    }
}