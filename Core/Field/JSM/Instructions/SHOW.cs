namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class Show : JsmInstruction
    {
        #region Constructors

        public Show()
        {
        }

        public Show(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Model))
                .Method(nameof(FieldObjectModel.Show))
                .Comment(nameof(Show));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.Model.Show();
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(Show)}()";

        #endregion Methods
    }
}