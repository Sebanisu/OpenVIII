namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// pop animation off stack?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/14B_POPANIME&action=edit&redlink=1"/>
    public sealed class PopAnime : JsmInstruction
    {
        #region Constructors

        public PopAnime()
        {
        }

        public PopAnime(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(PopAnime)}()";

        #endregion Methods
    }
}