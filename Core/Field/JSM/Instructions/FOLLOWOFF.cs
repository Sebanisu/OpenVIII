namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FollowOff : JsmInstruction
    {
        #region Constructors

        public FollowOff()
        {
        }

        public FollowOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(FollowOff)}()";

        #endregion Methods
    }
}