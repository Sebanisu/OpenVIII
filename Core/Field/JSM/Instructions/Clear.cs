namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Resets all variables and game data.
    /// Only used when starting a new game (and in debug rooms).
    /// </summary>
    internal sealed class Clear : JsmInstruction
    {
        #region Constructors

        public Clear()
        {
        }

        public Clear(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IGameplayService))
                .Method(nameof(IGameplayService.ResetAllData))
                .Comment(nameof(Clear));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Gameplay[services].ResetAllData();
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(Clear)}()";

        #endregion Methods
    }
}