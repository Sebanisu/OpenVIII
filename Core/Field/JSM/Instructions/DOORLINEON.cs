namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// door line on? enable door?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/143_DOORLINEON&action=edit&redlink=1"/>
    public sealed class DoorLineOn : JsmInstruction
    {
        #region Constructors

        public DoorLineOn()
        {
        }

        public DoorLineOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(DoorLineOn)}()";

        #endregion Methods
    }
}