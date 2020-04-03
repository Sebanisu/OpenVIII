namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Force Character's eyes closed
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/15C_CLOSEEYES&action=edit&redlink=1"/>
    /// <remarks>Has no arguments.</remarks>
    public sealed class CloseEyes : JsmInstruction
    {
        #region Methods

        public override string ToString() => $"{nameof(CloseEyes)}";

        #endregion Methods
    }
}