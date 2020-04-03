namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Turn Particleoff
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/14F_PARTICLEOFF&action=edit&redlink=1"/>
    public sealed class ParticleOff : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public ParticleOff(IJsmExpression arg0) => _arg0 = arg0;

        public ParticleOff(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(ParticleOff)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}