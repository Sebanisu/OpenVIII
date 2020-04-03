namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Enables the payment of salaries.
    /// </summary>
    internal sealed class SaralyOn : JsmInstruction
    {
        #region Constructors

        public SaralyOn()
        {
        }

        public SaralyOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(ISalaryService))
                .Property(nameof(ISalaryService.IsSalaryEnabled))
                .Assign(true)
                .Comment(nameof(SaralyOn));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Salary[services].IsSalaryEnabled = true;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(SaralyOn)}()";

        #endregion Methods
    }
}