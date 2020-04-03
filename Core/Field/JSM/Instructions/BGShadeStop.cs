namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// stop shade?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/0D1_BGSHADESTOP&action=edit&redlink=1"/>
    public sealed class BGShadeStop : JsmInstruction
    {
        #region Constructors

        public BGShadeStop()
        {
        }

        public BGShadeStop(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(BGShadeStop)}()";

        #endregion Methods
    }
}