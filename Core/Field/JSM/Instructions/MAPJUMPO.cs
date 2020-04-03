namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Jump the player to the field with the given ID and starting on the given walkmesh triangle. The walkmesh is almost always 0 because MapJumpO is intended to be used for teleporting the player into a cutscene, and the cutscenes place the characters where they need to be on initialization, so it doesn't matter where they're initially teleported.
    /// </summary>
    internal sealed class MapJumpO : JsmInstruction
    {
        #region Fields

        private readonly int _fieldMapId;
        private readonly int _walkmeshId;

        #endregion Fields

        #region Constructors

        public MapJumpO(int fieldMapId, int walkmeshId)
        {
            _fieldMapId = fieldMapId;
            _walkmeshId = walkmeshId;
        }

        public MapJumpO(int parameter, IStack<IJsmExpression> stack)
            : this(
                walkmeshId: ((Jsm.Expression.PSHN_L)stack.Pop()).Int32(),
                fieldMapId: ((Jsm.Expression.PSHN_L)stack.Pop()).Int32())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .CommentLine(FieldName.Get(_fieldMapId))
                .StaticType(nameof(IFieldService))
                .Method(nameof(IFieldService.GoTo))
                .Enum(_fieldMapId)
                .Argument("walkmeshId", _walkmeshId)
                .Comment(nameof(MapJumpO));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Field[services].GoTo(_fieldMapId, _walkmeshId);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(MapJumpO)}({nameof(_fieldMapId)}: {_fieldMapId}, {nameof(_walkmeshId)}: {_walkmeshId})";

        #endregion Methods
    }
}