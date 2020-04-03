﻿using System;

namespace OpenVIII.Fields.Scripts.Instructions
{
    /// <summary>
    /// Requests that the entity associated with a character in the current party executes one of its member functions at a specified priority.
    /// The request is asynchronous and returns immediately without waiting for the remote execution to start or finish.
    /// If the specified priority is already busy executing, the request will fail silently.
    /// </summary>
    /// <see cref="http://wiki.ffrtt.ru/index.php?title=FF8/Field/Script/Opcodes/017_PREQ"/>
    public sealed class PREQ : Abstract.PREQ
    {
        #region Constructors

        public PREQ(int objectIndex, int priority, int scriptId) : base(objectIndex, priority, scriptId)
        {
        }

        public PREQ(int objectIndex, IStack<IJsmExpression> stack) : base(objectIndex, stack)
        {
        }

        #endregion Constructors

        #region Methods

        public override void Format(ScriptWriter sw, IScriptFormatterContext formatterContext, IServices services)
        {
            formatterContext.GetObjectScriptNamesById(ScriptID, out var typeName, out var methodName);

            sw.AppendLine($"{nameof(PREQ)}(priority: {Priority}, GetObject<{typeName}>().{methodName}());");
        }

        public override IAwaitable TestExecute(IServices services)
        {
            var targetObject = ServiceId.Party[services].FindPartyCharacterObject(PartyID);
            if (targetObject == null)
                throw new NotSupportedException($"Unknown expected behavior when trying to call a method of a nonexistent party character (Slot: {PartyID}).");

            if (!targetObject.IsActive)
                throw new NotSupportedException($"Unknown expected behavior when trying to call a method of the inactive object (Slot: {PartyID}).");

            targetObject.Scripts.TryExecute(ScriptID, Priority);
            return DummyAwaitable.Instance;
        }

        public override string ToString() => $"{nameof(PREQ)}({nameof(PartyID)}: {PartyID}, {nameof(Priority)}: {Priority}, {nameof(ScriptID)}: {ScriptID})";

        #endregion Methods
    }
}