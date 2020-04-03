namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Set Pan for all Sound Effects, (Never Used In Game)
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/0C5_ALLSEPOS"/>
    public sealed class AllSEPos : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// PAN Amount
        /// </summary>
        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public AllSEPos(IJsmExpression arg0) => _arg0 = arg0;

        public AllSEPos(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(AllSEPos)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}