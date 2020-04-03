﻿namespace OpenVIII.Fields.Scripts.Instructions
{
    internal sealed class PHSPower : JsmInstruction
    {
        #region Fields

        private readonly bool _isPartySwitchEnabled;

        #endregion Fields

        #region Constructors

        public PHSPower(bool isPartySwitchEnabled) => _isPartySwitchEnabled = isPartySwitchEnabled;

        public PHSPower(int parameter, IStack<IJsmExpression> stack)
            : this(
                isPartySwitchEnabled: ((Jsm.Expression.PSHN_L)stack.Pop()).Boolean())
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services) => sw.Format(formatterContext, services)
                .StaticType(nameof(IPartyService))
                .Property(nameof(IPartyService.IsPartySwitchEnabled))
                .Assign(_isPartySwitchEnabled)
                .Comment(nameof(PHSPower));

        public override IAwaitable TestExecute(IServices services)
        {
            ServiceId.Party[services].IsPartySwitchEnabled = _isPartySwitchEnabled;
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(PHSPower)}({nameof(_isPartySwitchEnabled)}: {_isPartySwitchEnabled})";

        #endregion Methods
    }
}