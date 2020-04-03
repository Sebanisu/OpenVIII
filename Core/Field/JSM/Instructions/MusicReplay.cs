namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Replay music?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/141_MUSICREPLAY&action=edit&redlink=1"/>
    public sealed class MusicReplay : JsmInstruction
    {
        #region Constructors

        public MusicReplay()
        {
        }

        public MusicReplay(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(MusicReplay)}()";

        #endregion Methods
    }
}