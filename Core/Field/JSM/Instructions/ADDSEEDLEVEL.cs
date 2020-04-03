namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Add to seed Level
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/153_ADDSEEDLEVEL&action=edit&redlink=1"/>
    public sealed class AddSeedLevel : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// Amount
        /// </summary>
        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public AddSeedLevel(IJsmExpression arg0) => _arg0 = arg0; //100,60,40,-100,150, GlobalValue

        public AddSeedLevel(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(AddSeedLevel)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}