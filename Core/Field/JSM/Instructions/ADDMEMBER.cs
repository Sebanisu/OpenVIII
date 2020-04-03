﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Adds a PC to the available party (not to the active party).
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/08C_ADDMEMBER"/>
    public sealed class AddMember : JsmInstruction
    {
        #region Fields

        /// <summary>
        /// Character ID
        /// </summary>
        private readonly Characters _characterId;

        #endregion Fields

        #region Constructors

        public AddMember(Characters characterId) => _characterId = characterId;

        public AddMember(int parameter, IStack<IJsmExpression> stack)
            : this(
                characterId: (Characters)((Jsm.Expression.PSHN_L)stack.Pop()).Int32())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IPartyService))
                .Method(nameof(IPartyService.AddPlayableCharacter))
                .Enum(_characterId)
                .Comment(nameof(AddMember));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Party[services].AddPlayableCharacter(_characterId);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(AddMember)}({nameof(_characterId)}: {_characterId})";

        #endregion Methods
    }
}