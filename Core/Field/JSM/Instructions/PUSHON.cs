namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Enables "pushing" this entity. An entity's "push" script is run when the player walks into it. Detection range can presumably be set with PushRadius
    /// </summary>
    internal sealed class PushOn : JsmInstruction
    {
        #region Constructors

        public PushOn()
        {
        }

        public PushOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Model))
                .Property(nameof(FieldObjectInteraction.IsPushScriptActive))
                .Assign(true)
                .Comment(nameof(PushOn));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.Interaction.IsPushScriptActive = true;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(PushOn)}()";

        #endregion Methods
    }
}