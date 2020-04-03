﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Swap?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/162_SWAP&action=edit&redlink=1"/>
    public sealed class Swap : JsmInstruction
    {
        #region Constructors

        public Swap()
        {
        }

        public Swap(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(Swap)}()";

        #endregion Methods
    }
}