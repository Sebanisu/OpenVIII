namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class BattleResult : JsmInstruction
    {
        #region Constructors

        public BattleResult()
        {
        }

        public BattleResult(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(BattleResult)}()";

        #endregion Methods
    }
}