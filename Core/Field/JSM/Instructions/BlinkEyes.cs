using System;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Force Character's eyes to blink? Unused!
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/15C_BLINKEYES&action=edit&redlink=1"/>
    public sealed class BlinkEyes : JsmInstruction
    {
        #region Constructors

        public BlinkEyes() => throw new NotImplementedException();

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(BlinkEyes)}()";

        #endregion Methods
    }
}