namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Disable Running
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/0F7_RUNDISABLE"/>
    /// <remarks>no arguments</remarks>
    internal sealed class RunDisable : JsmInstruction
    {
        #region Methods

        public override string ToString() => $"{nameof(RunDisable)}()";

        #endregion Methods
    }
}