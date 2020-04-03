namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Last dungeon in</para>
    /// <para>Disables features of the game pertaining to the last dungeon's mechanic (items, saving, etc)?</para>
    /// <para>test6, ffbrdg1</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/157_LASTIN"/>
    public sealed class LastIn : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// 1 or 0 ?
        /// </summary>
        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public LastIn(IJsmExpression arg0) => _arg0 = arg0;

        public LastIn(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(LastIn)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}