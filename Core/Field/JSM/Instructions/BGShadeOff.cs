namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// turn off shade?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/117_BGSHADEOFF&action=edit&redlink=1"/>
    public sealed class BGShadeOff : JsmInstruction
    {
        #region Constructors

        public BGShadeOff()
        {
        }

        public BGShadeOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(BGShadeOff)}()";

        #endregion Methods
    }
}