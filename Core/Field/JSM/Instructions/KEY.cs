namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Key
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/139_KEY&action=edit&redlink=1"/>
    public sealed class Key : Abstract.Key
    {
        #region Constructors

        public Key(int parameter, KeyFlags flags) : base(parameter,flags)
        {
        }

        public Key(int parameter, IStack<IJsmExpression> stack) : base(parameter, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(Key)}({nameof(Flags)}: {Flags})";

        #endregion Methods
    }
}