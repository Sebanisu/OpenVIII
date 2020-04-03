namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class SetModel : JsmInstruction
    {
        #region Fields

        private readonly int _modelId;

        #endregion Fields

        #region Constructors

        public SetModel(int modelId) => _modelId = modelId;

        public SetModel(int parameter, IStack<IJsmExpression> stack)
            : this(parameter)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Model))
                .Method(nameof(FieldObjectModel.Change))
                .Argument("modelId", _modelId)
                .Comment(nameof(SetModel));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.Model.Change(_modelId);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(SetModel)}({nameof(_modelId)}: {_modelId})";

        #endregion Methods
    }
}