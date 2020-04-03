using System;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Requests that the entity associated with a character in the current party executes one of its member functions at a specified priority.
    /// If the specified priority is already busy executing, the request will block until it becomes available and only then return.
    /// The remote execution is still carried out asynchronously, with no notification of completion.
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/018_PREQSW"/>
    public sealed class PREQSW : Abstract.PREQ
    {
        #region Constructors

        public PREQSW(int objectIndex, IStack<IJsmExpression> stack) : base(objectIndex, stack)
        {
        }

        public PREQSW(int objectIndex, int priority, int scriptId) : base(objectIndex, priority, scriptId)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services)
        {
            formatterContext.GetObjectScriptNamesById(ScriptID, out var typeName, out var methodName);

            sw.AppendLine($"{nameof(PREQSW)}(priority: {Priority}, GetObject<{typeName}>().{methodName}());");
        }

        public override IAwaitable TestExecute(IServices services)
        {
            var targetObject = ServiceId.Party[services].FindPartyCharacterObject(PartyID);
            if (targetObject == null)
                throw new NotSupportedException($"Unknown expected behavior when trying to call a method of a nonexistent party character (Slot: {PartyID}).");

            if (!targetObject.IsActive)
                throw new NotSupportedException($"Unknown expected behavior when trying to call a method of the inactive object (Slot: {PartyID}).");

            targetObject.Scripts.Execute(ScriptID, Priority);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(PREQSW)}({nameof(PartyID)}: {PartyID}, {nameof(Priority)}: {Priority}, {nameof(ScriptID)}: {ScriptID})";

        #endregion Methods
    }
}