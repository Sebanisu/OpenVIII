﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Sets the active party to be the members with the input IDs. These IDs also work with the other party related functions.
    /// </summary>
    internal sealed class SetParty : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _character1;
        private readonly IJsmExpression _character2;
        private readonly IJsmExpression _character3;

        #endregion Fields

        #region Constructors

        public SetParty(IJsmExpression character1, IJsmExpression character2, IJsmExpression character3)
        {
            _character1 = character1;
            _character2 = character2;
            _character3 = character3;
        }

        public SetParty(int parameter, IStack<IJsmExpression> stack)
            : this(
                character3: stack.Pop(),
                character2: stack.Pop(),
                character1: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IPartyService))
                .Method(nameof(IPartyService.ChangeParty))
                .Enum<Characters>(_character1)
                .Enum<Characters>(_character2)
                .Enum<Characters>(_character3)
                .Comment(nameof(SetParty));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Party[services].ChangeParty(
                (Characters)_character1.Int32(services),
                (Characters)_character1.Int32(services),
                (Characters)_character1.Int32(services));
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(SetParty)}({nameof(_character1)}: {_character1}, {nameof(_character2)}: {_character2}, {nameof(_character3)}: {_character3})";

        #endregion Methods
    }
}