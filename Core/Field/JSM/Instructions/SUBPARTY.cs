namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class SubParty : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _characterId;

        #endregion Fields

        #region Constructors

        public SubParty(IJsmExpression characterId) => _characterId = characterId;

        public SubParty(int parameter, IStack<IJsmExpression> stack)
            : this(
                characterId: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IPartyService))
                .Method(nameof(IPartyService.RemovePartyCharacter))
                .Enum<Characters>(_characterId)
                .Comment(nameof(SubParty));

        public override IAwaitable TestExecute(IServices services)
        {
            var characterId = (Characters)_characterId.Int32(services);
            ServiceId.Party[services].RemovePartyCharacter(characterId);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(SubParty)}({nameof(_characterId)}: {_characterId})";

        #endregion Methods
    }
}