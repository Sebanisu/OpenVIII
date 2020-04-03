namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Set Particle?
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/154_PARTICLESET&action=edit&redlink=1"/>
    public sealed class ParticleSet : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public ParticleSet(IJsmExpression arg0) => _arg0 = arg0;

        public ParticleSet(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(ParticleSet)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}