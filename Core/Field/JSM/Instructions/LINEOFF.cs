namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class LineOff : JsmInstruction
    {
        #region Constructors

        public LineOff()
        {
        }

        public LineOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(LineOff)}()";

        #endregion Methods
    }
}