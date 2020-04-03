namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Enable Running
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/0F6_RUNENABLE"/>
    /// <remarks>no arguments</remarks>
    internal sealed class RunEnable : JsmInstruction
    {
        #region Methods

        public override string ToString() => $"{nameof(RunEnable)}";

        #endregion Methods
    }
}