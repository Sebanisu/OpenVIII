namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class ThroughOff : JsmInstruction
    {
        #region Constructors

        public ThroughOff()
        {
        }

        public ThroughOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(ThroughOff)}()";

        #endregion Methods
    }
}