namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Set the volume of the music.
    /// All the music functions have a parameter that's either 0 or 1.
    /// </summary>
    internal sealed class MusicVol : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _flag;
        private readonly IJsmExpression _volume;

        #endregion Fields

        #region Constructors

        public MusicVol(IJsmExpression flag, IJsmExpression volume)
        {
            _flag = flag;
            _volume = volume;
        }

        public MusicVol(int parameter, IStack<IJsmExpression> stack)
            : this(
                volume: stack.Pop(),
                flag: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IMusicService))
                .Method(nameof(IMusicService.ChangeMusicVolume))
                .Argument("volume", _volume)
                .Argument("flag", _flag)
                .Comment(nameof(MusicVol));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Music[services].ChangeMusicVolume(
                _volume.Int32(services),
                _flag.Boolean(services));
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(MusicVol)}({nameof(_flag)}: {_flag}, {nameof(_volume)}: {_volume})";

        #endregion Methods
    }
}