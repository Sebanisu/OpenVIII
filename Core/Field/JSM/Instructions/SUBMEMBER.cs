namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Removes a PC from the available party and the active party.
    /// </summary>
    internal sealed class SubMember : JsmInstruction
    {
        #region Fields

        private readonly Characters _characterId;

        #endregion Fields

        #region Constructors

        public SubMember(Characters characterId) => _characterId = characterId;

        public SubMember(int parameter, IStack<IJsmExpression> stack)
            : this(
                characterId: (Characters)((Jsm.Expression.PSHN_L)stack.Pop()).Int32())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IPartyService))
                .Method(nameof(IPartyService.RemovePlayableCharacter))
                .Enum(_characterId)
                .Comment(nameof(SubMember));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Party[services].RemovePlayableCharacter(_characterId);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(SubMember)}({nameof(_characterId)}: {_characterId})";

        #endregion Methods
    }
}