namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// <para>Unlock walkmesh ID</para>
    /// <para>Unlocks a walkmesh triangle so things can walk over it.</para>
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/020_IDUNLOCK"/>
    public sealed class IDUnlock : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// Walkmesh triangle ID
        /// </summary>
        private readonly int _parameter;

        #endregion Fields

        #region Constructors

        public IDUnlock(int parameter) => _parameter = parameter;

        public IDUnlock(int parameter, IStack<IJsmExpression> stack)
            : this(parameter)
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(IDUnlock)}({nameof(_parameter)}: {_parameter})";

        #endregion Methods
    }
}