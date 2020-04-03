namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class BattleCut : JsmInstruction
    {
        #region Constructors

        public BattleCut()
        {
        }

        public BattleCut(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(BattleCut)}()";

        #endregion Methods
    }
}