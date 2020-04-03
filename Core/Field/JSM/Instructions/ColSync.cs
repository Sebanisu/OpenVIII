namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class ColSync : JsmInstruction
    {
        #region Constructors

        public ColSync()
        {
        }

        public ColSync(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IRenderingService))
                .Method(nameof(IRenderingService.Wait))
                .Comment(nameof(ColSync));

        public override IAwaitable TestExecute(IServices services) => ServiceId.Rendering[services].Wait();

        public override string ToString() => $"{nameof(ColSync)}()";

        #endregion Methods
    }
}