namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Animates a background object on the field.
    /// </summary>
    public sealed class BGAnime : Abstract.BGAnime
    {
        #region Constructors

        public BGAnime(IJsmExpression firstFrame, IJsmExpression lastFrame) : base(firstFrame, lastFrame)
        {
        }

        public BGAnime(int parameter, IStack<IJsmExpression> stack) : base(parameter, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IRenderingService))
                .Method(nameof(IRenderingService.AnimateBackground))
                .Argument("lastFrame", LastFrame)
                .Argument("firstFrame", FirstFrame)
                .Comment(nameof(BGAnime));

        public override IAwaitable TestExecute(IServices services)
        {
            var firstFrame = LastFrame.Int32(services);
            var lastFrame = FirstFrame.Int32(services);
            ServiceId.Rendering[services].AnimateBackground(firstFrame, lastFrame);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(BGAnime)}({nameof(LastFrame)}: {LastFrame}, {nameof(FirstFrame)}: {FirstFrame})";

        #endregion Methods
    }
}