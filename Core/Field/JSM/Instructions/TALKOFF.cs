namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class TalkOff : JsmInstruction
    {
        #region Constructors

        public TalkOff()
        {
        }

        public TalkOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Model))
                .Property(nameof(FieldObjectInteraction.IsTalkScriptActive))
                .Assign(false)
                .Comment(nameof(TalkOff));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.Interaction.IsTalkScriptActive = false;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(TalkOff)}()";

        #endregion Methods
    }
}