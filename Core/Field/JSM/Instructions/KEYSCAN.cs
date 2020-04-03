﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Scan for pressed key</para>
    /// <para>Writes 1 to temporary variable 0 (access with PSHI_L 0) if the user is pressing any of the indicated keys. 0 otherwise. The script does not pause while doing this, so you have to run it in a touch or push script, or inside a looping subroutine.</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/06D_KEYSCAN"/>
    public sealed class KeyScan : Abstract.Key
    {
        #region Constructors

        public KeyScan(int parameter, KeyFlags flags) : base(parameter,flags)
        {
        }

        public KeyScan(int parameter, IStack<IJsmExpression> stack) : base(parameter, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(KeyScan)}({nameof(Flags)}: {Flags})";

        #endregion Methods
    }
}