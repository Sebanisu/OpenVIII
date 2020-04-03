namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Turns off the display of salary alerts.
    /// </summary>
    internal sealed class SaralyDispOff : JsmInstruction
    {
        #region Constructors

        public SaralyDispOff()
        {
        }

        public SaralyDispOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(ISalaryService))
                .Property(nameof(ISalaryService.IsSalaryAlertEnabled))
                .Assign(false)
                .Comment(nameof(SaralyDispOff));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Salary[services].IsSalaryAlertEnabled = false;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(SaralyDispOff)}()";

        #endregion Methods
    }
}