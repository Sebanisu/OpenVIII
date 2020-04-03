namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class BGDraw : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _arg0;

        #endregion Fields

        #region Constructors

        public BGDraw(IJsmExpression arg0) => _arg0 = arg0;

        public BGDraw(int parameter, IStack<IJsmExpression> stack)
            : this(
                arg0: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IRenderingService))
                .Method(nameof(IRenderingService.DrawBackground))
                .Comment(nameof(BGDraw));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Rendering[services].DrawBackground();
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(BGDraw)}({nameof(_arg0)}: {_arg0})";

        #endregion Methods
    }
}