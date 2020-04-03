namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class LineOn : JsmInstruction
    {
        #region Constructors

        public LineOn()
        {
        }

        public LineOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(LineOn)}()";

        #endregion Methods
    }
}