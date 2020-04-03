namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class TalkOn : JsmInstruction
    {
        #region Constructors

        public TalkOn()
        {
        }

        public TalkOn(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Model))
                .Property(nameof(FieldObjectInteraction.IsTalkScriptActive))
                .Assign(true)
                .Comment(nameof(TalkOn));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.Interaction.IsTalkScriptActive = true;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(TalkOn)}()";

        #endregion Methods
    }
}