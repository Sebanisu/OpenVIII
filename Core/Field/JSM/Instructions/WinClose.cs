namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Close the last window created by AMES.
    /// I haven't tried this for other types of windows...
    /// </summary>
    internal sealed class WinClose : JsmInstruction
    {
        #region Fields

        private readonly int _channel;

        #endregion Fields

        #region Constructors

        public WinClose(int channel) => _channel = channel;

        public WinClose(int parameter, IStack<IJsmExpression> stack)
            : this(
                channel: ((Jsm.Expression.PSHN_L)stack.Pop()).Int32())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IMessageService))
                .Method(nameof(IMessageService.Close))
                .Argument("channel", _channel)
                .Comment(nameof(WinClose));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Message[services].Close(_channel);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(WinClose)}({nameof(_channel)}: {_channel})";

        #endregion Methods
    }
}