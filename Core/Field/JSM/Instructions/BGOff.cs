namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class BGOff : JsmInstruction
    {
        #region Constructors

        public BGOff()
        {
        }

        public BGOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(BGOff)}()";

        #endregion Methods
    }
}