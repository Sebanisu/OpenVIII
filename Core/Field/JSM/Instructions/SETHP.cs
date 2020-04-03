namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Set HP
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/146_SETHP&action=edit&redlink=1"/>
    public sealed class SetHP : JsmInstruction
    {
        #region Fields

        private readonly Characters _character;
        private readonly int _hp;

        #endregion Fields

        #region Constructors

        public SetHP(Characters character, int hp)
        {
            _character = character;
            _hp = hp;
        }

        public SetHP(int parameter, IStack<IJsmExpression> stack)
            : this(
                hp: ((IConstExpression)stack.Pop()).Int32(),
                character: ((IConstExpression)stack.Pop()).Characters())
        {
        }

        #endregion Constructors

        #region Methods

        public override string ToString() => $"{nameof(SetHP)}({nameof(_character)}: {_character}, {nameof(_hp)}: {_hp})";

        #endregion Methods
    }
}