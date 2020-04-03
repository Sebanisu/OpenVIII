namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class GameOver : JsmInstruction
    {
        #region Constructors

        public GameOver()
        {
        }

        public GameOver(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(GameOver)}()";

        #endregion Methods
    }
}