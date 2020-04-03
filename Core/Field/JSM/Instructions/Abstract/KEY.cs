using System;

namespace OpenVIII.Fields.Scripts.Instructions.Abstract
{
    public abstract class Key : JsmInstruction
    {
        protected readonly int Parameter;

        #region Fields

        protected readonly KeyFlags Flags;

        #endregion Fields

        #region Constructors

        protected Key(int parameter, KeyFlags flags) => (Parameter,Flags) = (parameter,flags);

        protected Key(int parameter, IStack<IJsmExpression> stack)
            : this(parameter,
                (KeyFlags)((IConstExpression)stack.Pop()).Int32())
        {
        }

        #endregion Constructors

        #region Enums

        [Flags]
        public enum KeyFlags : byte
        {
            Cancel = 0x10,
            Menu = 0x20,
            Okay = 0x40,
            Card = 0x80,
        }

        #endregion Enums

        #region Methods

        public abstract override string ToString();

        #endregion Methods
    }
}