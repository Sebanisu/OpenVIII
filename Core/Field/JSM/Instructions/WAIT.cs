﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Pauses this script for some number of frames.
    /// </summary>
    internal sealed class Wait : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _frameNumber;

        #endregion Fields

        #region Constructors

        public Wait(IJsmExpression frameNumber) => _frameNumber = frameNumber;

        public Wait(int parameter, IStack<IJsmExpression> stack)
            : this(
                frameNumber: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Await()
                .StaticType(nameof(IInteractionService))
                .Method(nameof(IInteractionService.Wait))
                .Argument("frameNumber", _frameNumber)
                .Comment(nameof(Wait));

        public override IAwaitable TestExecute(IServices services)
        {
            var frameNumber = _frameNumber.Int32(services);
            return ServiceId.Interaction[services].Wait(frameNumber);
        }

        public override string ToString() => $"{nameof(Wait)}({nameof(_frameNumber)}: {_frameNumber})";

        #endregion Methods
    }
}