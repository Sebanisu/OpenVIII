namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class KillTimer : JsmInstruction
    {
        #region Constructors

        public KillTimer()
        {
        }

        public KillTimer(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(KillTimer)}()";

        #endregion Methods
    }
}