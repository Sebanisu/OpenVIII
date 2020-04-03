﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Disable user control.
    /// Player will only be able to press "ok" (and pause?) to advance through dialogue. Ends when UCOn is called.
    /// </summary>
    internal sealed class UCOff : JsmInstruction
    {
        #region Constructors

        public UCOff()
        {
        }

        public UCOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IGameplayService))
                .Property(nameof(IGameplayService.IsUserControlEnabled))
                .Assign(false)
                .Comment(nameof(UCOff));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Gameplay[services].IsUserControlEnabled = false;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(UCOff)}()";

        #endregion Methods
    }
}