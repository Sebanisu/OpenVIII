namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Last dungeon out</para>
    /// <para>Ends the effects of LastIn.</para>
    /// <para>fehall1</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/158_LASTOUT"/>
    public sealed class LastOut : JsmInstruction
    {
        #region Constructors

        public LastOut()
        {
        }

        public LastOut(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(LastOut)}()";

        #endregion Methods
    }
}