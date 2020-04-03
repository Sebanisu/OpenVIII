namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Disables the payment of salaries.
    /// </summary>
    internal sealed class SaralyOff : JsmInstruction
    {
        #region Constructors

        public SaralyOff()
        {
        }

        public SaralyOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(ISalaryService))
                .Property(nameof(ISalaryService.IsSalaryEnabled))
                .Assign(false)
                .Comment(nameof(SaralyOff));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Salary[services].IsSalaryEnabled = false;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(SaralyOff)}()";

        #endregion Methods
    }
}