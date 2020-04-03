namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Turns on the display of salary alerts.
    /// </summary>
    internal sealed class SaralyDispOn : JsmInstruction
    {
        #region Constructors

        public SaralyDispOn()
        {
        }

        public SaralyDispOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(ISalaryService))
                .Property(nameof(ISalaryService.IsSalaryAlertEnabled))
                .Assign(true)
                .Comment(nameof(SaralyDispOn));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Salary[services].IsSalaryAlertEnabled = true;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(SaralyDispOn)}()";

        #endregion Methods
    }
}