namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Sets this entity's movement speed.
    /// </summary>
    internal sealed class MSpeed : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _speed;

        #endregion Fields

        #region Constructors

        public MSpeed(IJsmExpression speed) => _speed = speed;

        public MSpeed(int parameter, IStack<IJsmExpression> stack)
            : this(
                speed: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Model))
                .Property(nameof(FieldObjectInteraction.MovementSpeed))
                .Assign(_speed)
                .Comment(nameof(MSpeed));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.Interaction.MovementSpeed = _speed.Int32(services);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(MSpeed)}({nameof(_speed)}: {_speed})";

        #endregion Methods
    }
}