namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Enables user control. See UCOff for details.
    /// </summary>
    internal sealed class UCOn : JsmInstruction
    {
        #region Constructors

        public UCOn()
        {
        }

        public UCOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IGameplayService))
                .Property(nameof(IGameplayService.IsUserControlEnabled))
                .Assign(true)
                .Comment(nameof(UCOn));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Gameplay[services].IsUserControlEnabled = true;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(UCOn)}()";

        #endregion Methods
    }
}