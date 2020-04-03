namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// See if music is playing?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/140_MUSICSTATUS&action=edit&redlink=1"/>
    public sealed class MusicStatus : JsmInstruction
    {
        #region Constructors

        public MusicStatus()
        {
        }

        public MusicStatus(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MusicStatus)}()";

        #endregion Methods
    }
}