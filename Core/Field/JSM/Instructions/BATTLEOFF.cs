﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Disable random battles.
    /// </summary>
    internal sealed class BattleOff : JsmInstruction
    {
        #region Constructors

        public BattleOff()
        {
        }

        public BattleOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IGameplayService))
                .Property(nameof(IGameplayService.IsRandomBattlesEnabled))
                .Assign(false)
                .Comment(nameof(BattleOff));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Gameplay[services].IsRandomBattlesEnabled = false;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(BattleOff)}()";

        #endregion Methods
    }
}