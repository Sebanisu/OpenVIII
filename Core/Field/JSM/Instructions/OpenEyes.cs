using System;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Force Character's eyes open? Unused!
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/15C_OPENEYES&action=edit&redlink=1"/>
    /// <remarks>default state is open I think, seems closed will force closed but nothing ever forces back open.</remarks>
    public sealed class OpenEyes : JsmInstruction
    {
        #region Constructors

        public OpenEyes() => throw new NotImplementedException();

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(OpenEyes)}()";

        #endregion Methods
    }
}