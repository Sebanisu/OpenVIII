namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Push animation on stack?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/14A_PUSHANIME&action=edit&redlink=1"/>
    public sealed class PushAnime : JsmInstruction
    {
        #region Constructors

        public PushAnime()
        {
        }

        public PushAnime(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(PushAnime)}()";

        #endregion Methods
    }
}