namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Music Vol Sync?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/149_MUSICVOLSYNC&action=edit&redlink=1"/>
    public sealed class MusicVolSync : JsmInstruction
    {
        #region Constructors

        public MusicVolSync()
        {
        }

        public MusicVolSync(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MusicVolSync)}()";

        #endregion Methods
    }
}