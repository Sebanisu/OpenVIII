namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MapJumpOn : JsmInstruction
    {
        #region Constructors

        public MapJumpOn()
        {
        }

        public MapJumpOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MapJumpOn)}()";

        #endregion Methods
    }
}