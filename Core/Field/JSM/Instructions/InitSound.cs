namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class InitSound : JsmInstruction
    {
        #region Constructors

        public InitSound()
        {
        }

        public InitSound(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(InitSound)}()";

        #endregion Methods
    }
}