namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MapJumpOff : JsmInstruction
    {
        #region Constructors

        public MapJumpOff()
        {
        }

        public MapJumpOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MapJumpOff)}()";

        #endregion Methods
    }
}