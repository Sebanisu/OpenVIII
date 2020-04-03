namespace OpenVIII.Fields.Scripts.Instructions
{
    public sealed class KeyScan2 : Abstract.Key
    {
        #region Constructors

        public KeyScan2(int parameter, KeyFlags flags) : base(parameter,flags)
        {
        }

        public KeyScan2(int parameter, IStack<IJsmExpression> stack) : base(parameter, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(KeyScan2)}({nameof(Flags)}: {Flags})";

        #endregion Methods
    }
}