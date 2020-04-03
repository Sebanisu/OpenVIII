﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Turns this entity.
    /// </summary>
    internal sealed class CTurnL : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _angle;
        private readonly IJsmExpression _frameDuration;

        #endregion Fields

        #region Constructors

        public CTurnL(IJsmExpression angle, IJsmExpression frameDuration)
        {
            _angle = angle;
            _frameDuration = frameDuration;
        }

        public CTurnL(int parameter, IStack<IJsmExpression> stack)
            : this(
                frameDuration: stack.Pop(),
                angle: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Await()
                .Property(nameof(FieldObject.Model))
                .Method(nameof(FieldObjectModel.Rotate))
                .Argument("angle", _angle)
                .Argument("frameDuration", _frameDuration)
                .Comment(nameof(CTurnL));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;

            var degrees = Degrees.FromAngle256(_angle.Int32(services));
            var frameDuration = _frameDuration.Int32(services);
            currentObject.Model.Rotate(-degrees, frameDuration);

            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(CTurnL)}({nameof(_angle)}: {_angle}, {nameof(_frameDuration)}: {_frameDuration})";

        #endregion Methods
    }
}