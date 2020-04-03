namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Set Volume of all Sound Effects
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/0C3_ALLSEVOL"/>
    public sealed class AllSEVol : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// Volume (0-127)
        /// </summary>
        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public AllSEVol(IJsmExpression arg0) => _arg0 = arg0;

        public AllSEVol(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(AllSEVol)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}