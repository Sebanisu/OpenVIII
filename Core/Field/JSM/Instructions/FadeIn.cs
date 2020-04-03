namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FadeIn : JsmInstruction
    {
        #region Constructors

        public FadeIn()
        {
        }

        public FadeIn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IFieldService))
                .Method(nameof(IFieldService.FadeIn))
                .Comment(nameof(FadeIn));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Field[services].FadeIn();
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(FadeIn)}()";

        #endregion Methods
    }
}