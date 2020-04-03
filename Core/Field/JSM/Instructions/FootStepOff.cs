﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class FootStepOff : JsmInstruction
    {
        #region Constructors

        public FootStepOff()
        {
        }

        public FootStepOff(int parameter, IStack<IJsmExpression> stack)
            : this()
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .Property(nameof(FieldObject.Model))
                .Property(nameof(FieldObjectInteraction.SoundFootsteps))
                .Assign(false)
                .Comment(nameof(FootStepOff));

        public override IAwaitable TestExecute(IServices services)
        {
            var currentObject = ServiceId.Field[services].Engine.CurrentObject;
            currentObject.Interaction.SoundFootsteps = false;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(FootStepOff)}()";

        #endregion Methods
    }
}