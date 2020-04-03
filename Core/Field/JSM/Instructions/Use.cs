namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Opposite of Unuse.
    /// </summary>
    internal sealed class Use : JsmInstruction
    {
        #region Constructors

        public Use()
        {
        }

        public Use(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.IsActive))
                .Assign(true)
                .Comment(nameof(Use));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.IsActive = true;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(Use)}()";

        #endregion Methods
    }
}