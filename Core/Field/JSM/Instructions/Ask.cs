﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Opens a field message window and lets player choose a single line.
    /// Ask saves the chosen line index into a temp variable which you can retrieve with PSHI_L 0.
    /// AASK is an upgrade that also lets you set the window position.
    /// </summary>
    internal sealed class Ask : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _beginLine;
        private readonly IJsmExpression _cancelLine;
        private readonly IJsmExpression _channel;
        private readonly IJsmExpression _firstLine;
        private readonly IJsmExpression _lastLine;
        private readonly IJsmExpression _messageId;

        #endregion Fields

        #region Constructors

        public Ask(IJsmExpression channel, IJsmExpression messageId, IJsmExpression firstLine, IJsmExpression lastLine, IJsmExpression beginLine, IJsmExpression cancelLine)
        {
            _channel = channel;
            _messageId = messageId;
            _firstLine = firstLine;
            _lastLine = lastLine;
            _beginLine = beginLine;
            _cancelLine = cancelLine;
        }

        public Ask(int parameter, IStack<IJsmExpression> stack)
            : this(
                cancelLine: stack.Pop(),
                beginLine: stack.Pop(),
                lastLine: stack.Pop(),
                firstLine: stack.Pop(),
                messageId: stack.Pop(),
                channel: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services)
        {
            if (_messageId is IConstExpression message)
                FormatHelper.FormatAnswers(sw, formatterContext.GetMessage(message.Int32()), _firstLine, _lastLine, _beginLine, _cancelLine);

            sw.Format(formatterContext, services)
                .Await()
                .StaticType(nameof(IMessageService))
                .Method(nameof(IMessageService.ShowDialog))
                .Argument("channel", _channel)
                .Argument("messageId", _messageId)
                .Argument("firstLine", _firstLine)
                .Argument("lastLine", _lastLine)
                .Argument("beginLine", _beginLine)
                .Argument("cancelLine", _cancelLine)
                .Comment(nameof(AASK));
        }

        public override IAwaitable TestExecute(IServices services) => ServiceId.Message[services].ShowQuestion(
                _channel.Int32(services),
                _messageId.Int32(services),
                _firstLine.Int32(services),
                _lastLine.Int32(services),
                _beginLine.Int32(services),
                _cancelLine.Int32(services));

        public override string ToString() => $"{nameof(Ask)}({nameof(_channel)}: {_channel}, {nameof(_messageId)}: {_messageId}, {nameof(_firstLine)}: {_firstLine}, {nameof(_lastLine)}: {_lastLine}, {nameof(_beginLine)}: {_beginLine}, {nameof(_cancelLine)}: {_cancelLine})";

        #endregion Methods
    }
}