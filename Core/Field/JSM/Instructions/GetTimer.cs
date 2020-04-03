namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class GetTimer : JsmInstruction
    {
        #region Constructors

        public GetTimer()
        {
        }

        public GetTimer(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(GetTimer)}()";

        #endregion Methods
    }
}