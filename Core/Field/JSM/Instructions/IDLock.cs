namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Lock walkmesh ID</para>
    /// <para>Locks a walkmesh triangle so nothing can walk over it.</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/01F_IDLOCK"/>
    public sealed class IDLock : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// Walkmesh triangle ID
        /// </summary>
        private readonly int _parameter;

        #endregion Fields

        #region Constructors

        public IDLock(int parameter) => _parameter = parameter;

        public IDLock(int parameter, IStack<IJsmExpression> stack)
            : this(parameter)
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(IDLock)}({nameof(_parameter)}: {_parameter})";

        #endregion Methods
    }
}