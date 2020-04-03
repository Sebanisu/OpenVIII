namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class ThroughOn : JsmInstruction
    {
        #region Constructors

        public ThroughOn()
        {
        }

        public ThroughOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(ThroughOn)}()";

        #endregion Methods
    }
}