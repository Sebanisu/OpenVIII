﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Make this entity walk/run to the given coordinates.
    /// </summary>
    internal sealed class Move : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _unknown;
        private readonly IJsmExpression _x;
        private readonly IJsmExpression _y;
        private readonly IJsmExpression _z;

        #endregion Fields

        #region Constructors

        public Move(IJsmExpression x, IJsmExpression y, IJsmExpression z, IJsmExpression unknown)
        {
            _x = x;
            _y = y;
            _z = z;
            _unknown = unknown;
        }

        public Move(int parameter, IStack<IJsmExpression> stack)
            : this(
                unknown: stack.Pop(),
                z: stack.Pop(),
                y: stack.Pop(),
                x: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Model))
                .Method(nameof(FieldObjectInteraction.Move))
                .Argument("x", _x)
                .Argument("y", _y)
                .Argument("z", _z)
                .Argument("unknown", _unknown)
                .Comment(nameof(Move));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;

            var coords = new Coords3D(
                _x.Int32(services),
                _y.Int32(services),
                _z.Int32(services));
            var unknown = _unknown.Int32(services);

            currentObject.Interaction.Move(coords, unknown);

            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(Move)}({nameof(_x)}: {_x}, {nameof(_y)}: {_y}, {nameof(_z)}: {_z}, {nameof(_unknown)}: {_unknown})";

        #endregion Methods
    }
}