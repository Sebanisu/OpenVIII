﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MenuName : JsmInstruction
    {
        #region Fields

        private readonly IJsmExpression _entityName;

        #endregion Fields

        #region Constructors

        public MenuName(IJsmExpression entityName) => _entityName = entityName;

        public MenuName(int parameter, IStack<IJsmExpression> stack)
            : this(
                entityName: stack.Pop())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Await()
                .StaticType(nameof(IMenuService))
                .Method(nameof(IMenuService.ShowEnterNameDialog))
                .Argument("entityName", _entityName)
                .Comment(nameof(MenuName));

        public override IAwaitable TestExecute(IServices services)
        {
            var targetEntity = (NamedEntity)_entityName.Int32(services);
            return ServiceId.Menu[services].ShowEnterNameDialog(targetEntity);
        }

        public override string ToString() => $"{nameof(MenuName)}({nameof(_entityName)}: {_entityName})";

        #endregion Methods
    }
}