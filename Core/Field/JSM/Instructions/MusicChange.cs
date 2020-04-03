namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MusicChange : JsmInstruction
    {
        #region Constructors

        public MusicChange()
        {
        }

        public MusicChange(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IMusicService))
                .Method(nameof(IMusicService.PlayFieldMusic))
                .Comment(nameof(MusicChange));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Music[services].PlayFieldMusic();
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(MusicChange)}()";

        #endregion Methods
    }
}