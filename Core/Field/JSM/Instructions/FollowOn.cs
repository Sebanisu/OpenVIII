namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FollowOn : JsmInstruction
    {
        #region Constructors

        public FollowOn()
        {
        }

        public FollowOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FollowOn)}()";

        #endregion Methods
    }
}