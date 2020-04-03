namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Make this entity face "Angle" in degrees.
    /// </summary>
    internal sealed class Dir : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _angle;

        #endregion Fields

        #region Constructors

        public Dir(IJsmExpression angle) => _angle = angle;

        public Dir(int parameter, IStack<IJsmExpression> stack)
            : this(
                angle: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Model))
                .Method(nameof(FieldObjectModel.SetDirection))
                .Argument("angle256", _angle)
                .Comment(nameof(Set3));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.Model.SetDirection(Degrees.FromAngle256(_angle.Int32(services)));
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(Dir)}({nameof(_angle)}: {_angle})";

        #endregion Methods
    }
}