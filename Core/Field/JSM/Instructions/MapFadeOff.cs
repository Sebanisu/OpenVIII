﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class MapFadeOff : JsmInstruction
    {
        #region Constructors

        public MapFadeOff()
        {
        }

        public MapFadeOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IFieldService))
                .Method(nameof(IFieldService.FadeOff))
                .Comment(nameof(MapFadeOff));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Field[services].FadeOff();
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(MapFadeOff)}()";

        #endregion Methods
    }
}