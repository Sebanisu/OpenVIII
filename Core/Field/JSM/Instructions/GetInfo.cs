namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class GetInfo : JsmInstruction
    {
        #region Constructors

        public GetInfo()
        {
        }

        public GetInfo(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(GetInfo)}()";

        #endregion Methods
    }
}